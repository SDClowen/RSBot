using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.General.Components;

internal static class RuSroAuthService
{
    private static readonly HttpClient client = new();
    private static readonly Random _random = new();
    private static readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static string randomHwid = GenerateRandomString();
    private static string randomLauncherId = GenerateLauncherId();

    public static async Task<bool> Auth()
    {
        var selectedAccount = Accounts.SavedAccounts?.Find(p =>
            p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername"));

        Log.Debug(selectedAccount?.Username);

        if (selectedAccount == null)
        {
            MessageBox.Show("No account selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        string username = selectedAccount.Username;
        string password = selectedAccount.Password;

        try
        {
            string accessToken = await GetAccessTokenAsync(username, password);
            Log.Debug("Access Token: " + accessToken);
            if (!string.IsNullOrEmpty(accessToken))
            {
                await ConnectToWSAndSend();
                return true;
            }
        }
        catch (Exception ex)
        {
            Log.Debug("Error: " + ex.Message);
        }

        return false;
    }

    private static async Task<SESSION_STATE> Activate()
    {
        var sessionId = GlobalConfig.Get<string>("RSBot.RuSro.sessionId", "").Trim();
        string confirmationCode = GlobalConfig.Get("RSBot.RuSro.Pin", "").Trim();
        Log.Debug($"Sessions ID: {sessionId}");
        Log.Debug($"PIN: {confirmationCode}");

        if (string.IsNullOrEmpty(sessionId))
        {
            var msgBoxTitle = LanguageManager.GetLang("RuSroUpdatePinMsgTitle");
            var msgBoxContent = LanguageManager.GetLang("RuSroUpdatePinMsgContent");
            MessageBox.Show("No Session ID Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return SESSION_STATE.NO_SESSION_ID;
        }

        if (string.IsNullOrEmpty(confirmationCode))
        {
            var msgBoxTitle = LanguageManager.GetLang("RuSroUpdatePinMsgTitle");
            var msgBoxContent = LanguageManager.GetLang("RuSroUpdatePinMsgContent");
            MessageBox.Show("PIN is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return SESSION_STATE.NO_PIN;
        }

        var confirmationRequestContent = new StringContent(JsonConvert.SerializeObject(new
        {
            sessionId,
            code = confirmationCode
        }), Encoding.UTF8, "application/json");

        var confirmationResponse = await client.PostAsync("https://webbff.ru.4game.ru/api/guard/accesscodes/activate",
            confirmationRequestContent);
        var confirmationResponseContent = await confirmationResponse.Content.ReadAsStringAsync();

        Log.Debug("Activation Response:");
        Log.Debug(confirmationResponseContent);

        if (confirmationResponse.IsSuccessStatusCode)
        {
            MessageBox.Show("Successfully activated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return SESSION_STATE.SUCCESSFULLY_ACTIVATED;
        }

        if (confirmationResponse.StatusCode == HttpStatusCode.Forbidden)
        {
            Log.Debug("Session already activated.");
            return SESSION_STATE.ALREADY_ACTIVATED;
        }

        MessageBox.Show(confirmationResponseContent,"Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
        return SESSION_STATE.INVALID_REQUEST;
    }

    public static async Task<string> TokenResponse(string username, string password)
    {
        var tokenRequestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("username", username),
            new KeyValuePair<string, string>("password", password),
            new KeyValuePair<string, string>("secure", "true"),
            new KeyValuePair<string, string>("grant_type", "password")
        });
        var hwid = GlobalConfig.Get<string>("RSBot.RuSro.hwid", randomHwid);
        var launcherId = GlobalConfig.Get<string>("RSBot.RuSro.launcherid", randomLauncherId);

        GlobalConfig.Set("RSBot.RuSro.hwid", hwid);
        GlobalConfig.Set("RSBot.RuSro.launcherid", launcherId);
        GlobalConfig.Save();

        Log.Debug($"HWID: {hwid}");
        Log.Debug($"Launcher ID: {launcherId}");

        client.DefaultRequestHeaders.Add("Hardware-Id", hwid);
        client.DefaultRequestHeaders.Add("Launcher-Id", launcherId);

        var tokenResponse =
            await client.PostAsync("https://launcherbff.ru.4game.com/connect/token", tokenRequestContent);
        var tokenResponseContent = await tokenResponse.Content.ReadAsStringAsync();
        // var tokenResponseContent =
        // "{\"error\":{\"data\":{\"length\":6,\"alphabet\":\"0123456789\",\"isResend\":false,\"contact\":\"b.s*******@outlook.de\",\"sessionId\":\"8756c1eb-0ba5-4404-bf9a-3e9c4274e46d\",\"requester\":\"guard\",\"resendTimeout\":\"00:00:30\",\"method\":\"^login$\"},\"description\":\"Need to confirm with code from email\",\"code\":\"guard.emailcoderequired\"}}";
        return tokenResponseContent;
    }

    private static async Task<string> GetAccessTokenAsync(string username, string password)
    {
        SESSION_STATE sessionState = await Activate();
        Log.Debug("Sessions State: " + sessionState);
        string tokenResponseContent = await TokenResponse(username, password);

        if (tokenResponseContent.Contains("Need to confirm with code from email"))
        {
            GlobalConfig.Set("RSBot.RuSro.sessionId", ExtractSessionId(tokenResponseContent));
            MessageBox.Show("You have got an email with PIN", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return "";
        }

        string accessToken = ExtractAccessToken(tokenResponseContent);
        GlobalConfig.Set("RSBot.RuSro.accessToken", accessToken);
        return accessToken;
    }

    private static string ExtractSessionId(string responseContent)
    {
        var jsonResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);
        var sessionId = jsonResponse?.Error?.Data?.SessionId;
        return sessionId;
    }

    private static string ExtractAccessToken(string responseContent)
    {
        // Extract the access_token from the response
        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
        return jsonResponse.access_token;
    }

    private static string GenerateRandomString(int length = 64)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            var index = _random.Next(_chars.Length);
            sb.Append(_chars[index]);
        }

        return sb.ToString();
    }

    private static string GenerateLauncherId()
    {
        Guid guid = Guid.NewGuid();
        return guid.ToString();
    }

    private class ErrorDetails
    {
        public int Length { get; set; }
        public string Alphabet { get; set; }
        public bool IsResend { get; set; }
        public string Contact { get; set; }
        public string SessionId { get; set; }
        public string Requester { get; set; }
        public string ResendTimeout { get; set; }
        public string Method { get; set; }
    }

    private class ErrorData
    {
        public ErrorDetails Data { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }

    private class ErrorResponse
    {
        public ErrorData Error { get; set; }
    }

    enum SESSION_STATE
    {
        NO_SESSION_ID,
        NO_PIN,
        ALREADY_ACTIVATED,
        INVALID_REQUEST,
        SUCCESSFULLY_ACTIVATED
    }


    private static async Task ConnectToWSAndSend()
    {
        string launcherId = GlobalConfig.Get<string>("RSBot.RuSro.launcherid");
        string hwid = GlobalConfig.Get<string>("RSBot.RuSro.hwid");
        string accessToken = GlobalConfig.Get<string>("RSBot.RuSro.accessToken");
        string sub = ExtractSubFromToken(accessToken);

        Log.Debug("Sub: " + sub);

        string wsUrl = BuildWebSocketUrl(accessToken, hwid, launcherId);
        var serverUri = new Uri(wsUrl);

        using (var clientWebSocket = new ClientWebSocket())
        {
            try
            {
                await ConnectToWebSocket(clientWebSocket, serverUri);

                string login = await SendGetGameAccountRequest(clientWebSocket, sub);
                (string extractedLogin, string password) =
                    await SendCreateGameTokenCodeRequest(clientWebSocket, accessToken, login, sub);

                SaveCredentials(extractedLogin, password);

                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                Log.Debug("Connection closed.");
            }
            catch (WebSocketException ex)
            {
                Log.Debug($"WebSocket error: {ex.Message}");
            }
        }
    }

    private static string ExtractSubFromToken(string accessToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(accessToken);
        return jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
    }

    private static string BuildWebSocketUrl(string accessToken, string hwid, string launcherId)
    {
        return string.Format(
            "wss://launcherbff.ru.4game.com/?token={0}&hardware-id={1}&launcher-id={2}&computer-name={3}",
            accessToken, hwid, launcherId, GenerateRandomString(8)
        );
    }

    private static async Task ConnectToWebSocket(ClientWebSocket clientWebSocket, Uri serverUri)
    {
        Log.Debug("Connecting to WebSocket server...");
        await clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);
        Log.Debug("Connected!");
    }

    private static async Task<string> SendGetGameAccountRequest(ClientWebSocket clientWebSocket, string sub)
    {
        string payload = string.Format(
            "{{\"jsonrpc\":\"2.0\",\"method\":\"getGameAccount\",\"params\":{{\"masterId\":\"{0}\",\"toPartnerId\":\"silk-ru\",\"lang\":\"ru\"}},\"id\":\"{1}\"}}",
            sub, Guid.NewGuid().ToString()
        );

        Log.Debug($"Sending payload: {payload}");
        await SendMessage(clientWebSocket, payload);

        string response = await ReceiveMessage(clientWebSocket);
        Log.Debug($"Received: {response}");

        using (JsonDocument document = JsonDocument.Parse(response))
        {
            return document.RootElement.GetProperty("result")[0].GetProperty("login").GetString();
        }
    }

    private static async Task<(string, string)> SendCreateGameTokenCodeRequest(ClientWebSocket clientWebSocket,
        string accessToken, string login, string sub)
    {
        string payload = $"{{\"jsonrpc\":\"2.0\",\"method\":\"createGameTokenCode\",\"params\":{{\"accessToken\":\"{accessToken}\",\"ignoreLicenseAcceptance\":false,\"login\":\"{login}\",\"masterId\":\"{sub}\",\"toPartnerId\":\"silk-ru\",\"lang\":\"ru\"}},\"id\":\"{Guid.NewGuid()}\"}}";

        Log.Debug($"Sending first payload: {payload}");
        await SendMessage(clientWebSocket, payload);

        while (true)
        {
            string response = await ReceiveMessage(clientWebSocket);
            Log.Debug($"Received response: {response}");

            using (JsonDocument document = JsonDocument.Parse(response))
            {
                if (document.RootElement.TryGetProperty("notification", out JsonElement notification) &&
                    notification.GetString() == "invalidate")
                {
                    Log.Debug("Received 'invalidate' notification, resending payload...");
                    await SendMessage(clientWebSocket, payload);
                    continue;
                }

                if (document.RootElement.TryGetProperty("error", out JsonElement error) &&
                    error.TryGetProperty("code", out JsonElement errorCode) &&
                    errorCode.GetString() == "license.agreement.not.accepted")
                {
                    Log.Debug("License agreement not accepted, attempting to accept it...");

                    var errorData = error.GetProperty("data");
                    int licenseAgreementId = errorData.GetProperty("licenseAgreementId").GetInt32();

                    string acceptLicensePayload = $"{{\"jsonrpc\":\"2.0\",\"method\":\"acceptLicense\",\"params\":{{\"userId\":{sub},\"licenseAgreementId\":{licenseAgreementId},\"lang\":\"ru\"}},\"id\":\"{Guid.NewGuid()}\"}}";

                    Log.Debug($"Sending acceptLicense payload: {acceptLicensePayload}");
                    await SendMessage(clientWebSocket, acceptLicensePayload);

                    string acceptResponse = await ReceiveMessage(clientWebSocket);
                    Log.Debug($"Received acceptLicense response: {acceptResponse}");

                    using (JsonDocument acceptDocument = JsonDocument.Parse(acceptResponse))
                    {
                        if (acceptDocument.RootElement.TryGetProperty("result", out JsonElement result) && result.ValueKind == JsonValueKind.Object)
                        {
                            Log.Debug("License agreement accepted, retrying createGameTokenCode...");
                            await SendMessage(clientWebSocket, payload);
                            continue;
                        }
                        else
                        {
                            Log.Error("Failed to accept license agreement");
                            throw new Exception("License agreement acceptance failed");
                        }
                    }
                }

                var resultElement = document.RootElement.GetProperty("result");
                string extractedLogin = resultElement.GetProperty("login").GetString();
                string password = resultElement.GetProperty("password").GetString();
                return (extractedLogin, password);
            }
        }
    }

    private static async Task SendMessage(ClientWebSocket clientWebSocket, string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        await clientWebSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true,
            CancellationToken.None);
    }

    private static async Task<string> ReceiveMessage(ClientWebSocket clientWebSocket)
    {
        var buffer = new byte[4096];
        var responseSegment = new ArraySegment<byte>(buffer);
        var result = await clientWebSocket.ReceiveAsync(responseSegment, CancellationToken.None);
        return Encoding.UTF8.GetString(buffer, 0, result.Count);
    }

    private static void SaveCredentials(string login, string password)
    {
        Log.Debug($"Extracted login: {login}");
        Log.Debug($"Extracted password: {password}");

        GlobalConfig.Set("RSBot.RuSro.login", login);
        GlobalConfig.Set("RSBot.RuSro.password", password);
    }
}