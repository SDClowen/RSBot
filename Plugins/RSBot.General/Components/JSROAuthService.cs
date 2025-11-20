using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;

namespace RSBot.General.Components;

internal static class JSROAuthService
{
    public static async Task<bool> GetTokenAsync()
    {
        var cookies = new CookieContainer();
        var handler = new HttpClientHandler
        {
            CookieContainer = cookies,
            UseCookies = true,
            AllowAutoRedirect = true,
            AutomaticDecompression = DecompressionMethods.All,
        };

        HttpClient client = new(handler);

        client.DefaultRequestHeaders.TryAddWithoutValidation(
            "User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/141.0.0.0 Safari/537.36"
        );
        client.DefaultRequestHeaders.TryAddWithoutValidation(
            "Accept",
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
        );
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");

        var selectedAccount = Accounts.SavedAccounts?.Find(p =>
            p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername")
        );

        if (selectedAccount == null)
        {
            MessageBox.Show("No account selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        string username = selectedAccount.Username;
        string password = selectedAccount.Password;

        string pattern = @"(?<=WebLauncher\.execute\("")[^""]+(?= WMO""\);)";

        try
        {
            var content = new FormUrlEncodedContent([
                new KeyValuePair<string, string>("txtPortalID", username),
                new KeyValuePair<string, string>("txtPortalPW", password),
            ]);

            string body = await content.ReadAsStringAsync();

            var response = await client.PostAsync("https://customer.gamecom.jp/Login/Login.aspx", content);
            response.EnsureSuccessStatusCode();

            var request = new HttpRequestMessage(HttpMethod.Post, "http://silkroad.gamecom.jp/Launcher/Start.php");

            response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Match match = Regex.Match(responseBody, pattern);
            if (match.Success)
            {
                GlobalConfig.Set("RSBot.JSRO.token", match.Value);
                GlobalConfig.Save();
                return true;
            }
            else
            {
                Log.Error("[JSROAuthService]: Couldn't get token from response.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Log.Error("[JSROAuthService]: " + ex.Message);
            return false;
        }
    }
}
