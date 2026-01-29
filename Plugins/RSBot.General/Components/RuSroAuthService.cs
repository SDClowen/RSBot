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
using SDUI.Controls;

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
            p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername")
        );

        if (selectedAccount == null)
        {
            MessageBox.Show("No account selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        Log.Debug(selectedAccount?.Username);

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

    private static async Task<SESSION_STATE> Activate(string confirmationCode)
    {
        var sessionId = GlobalConfig.Get<string>("RSBot.RuSro.sessionId", "").Trim();
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

        var confirmationRequestContent = new StringContent(
            JsonConvert.SerializeObject(new { sessionId, code = confirmationCode }),
            Encoding.UTF8,
            "application/json"
        );

        var confirmationResponse = await client.PostAsync(
            "https://webbff.ru.4game.ru/api/guard/accesscodes/activate",
            confirmationRequestContent
        );
        var confirmationResponseContent = await confirmationResponse.Content.ReadAsStringAsync();

        Log.Debug("Activation Response:");
        Log.Debug(confirmationResponseContent);

        if (confirmationResponse.IsSuccessStatusCode)
        {
            Log.Notify("Successfully activated");
            return SESSION_STATE.SUCCESSFULLY_ACTIVATED;
        }

        if (confirmationResponse.StatusCode == HttpStatusCode.Forbidden)
        {
            Log.Debug("Session already activated.");
            return SESSION_STATE.ALREADY_ACTIVATED;
        }

        MessageBox.Show(confirmationResponseContent, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return SESSION_STATE.INVALID_REQUEST;
    }

    public static async Task<string> TokenResponse(string username, string password)
    {
        var parameters = new List<KeyValuePair<string, string>>();
        string refreshToken = GlobalConfig.Get<string>("RSBot.RuSro.refreshToken");
        string accessToken = GlobalConfig.Get<string>("RSBot.RuSro.accessToken");
        if (
            !string.IsNullOrEmpty(refreshToken)
            && !string.IsNullOrEmpty(accessToken)
            && ExtractUsernameEmailFromToken(accessToken).Contains(username.ToLower())
        )
        {
            parameters.Add(new KeyValuePair<string, string>("grant_type", "refresh_token"));
            parameters.Add(new KeyValuePair<string, string>("refresh_token", refreshToken));
        }
        else
        {
            parameters.Add(new KeyValuePair<string, string>("username", username));
            parameters.Add(new KeyValuePair<string, string>("password", password));
            parameters.Add(new KeyValuePair<string, string>("secure", "true"));
            parameters.Add(new KeyValuePair<string, string>("grant_type", "password"));
        }
        var tokenRequestContent = new FormUrlEncodedContent(parameters);

        var hwid = GlobalConfig.Get<string>("RSBot.RuSro.hwid", randomHwid);
        var launcherId = GlobalConfig.Get<string>("RSBot.RuSro.launcherid", randomLauncherId);

        GlobalConfig.Set("RSBot.RuSro.hwid", hwid);
        GlobalConfig.Set("RSBot.RuSro.launcherid", launcherId);
        GlobalConfig.Save();

        Log.Debug($"HWID: {hwid}");
        Log.Debug($"Launcher ID: {launcherId}");

        client.DefaultRequestHeaders.Add("Hardware-Id", hwid);
        client.DefaultRequestHeaders.Add("Launcher-Id", launcherId);

        var tokenResponse = await client.PostAsync(
            "https://launcherbff.ru.4game.com/connect/token",
            tokenRequestContent
        );
        var tokenResponseContent = await tokenResponse.Content.ReadAsStringAsync();
        return tokenResponseContent;
    }

    private static async Task<string> GetAccessTokenAsync(string username, string password)
    {
        string tokenResponseContent = await TokenResponse(username, password);

        if (tokenResponseContent.Contains("guard.emailcoderequired"))
        {
            GlobalConfig.Set("RSBot.RuSro.sessionId", ExtractSessionId(tokenResponseContent));

            string dialogFormTitle = LanguageManager.GetLangBySpecificKey(
                "RSBot.General",
                "RuSroConfirmationCodeFormTitle",
                "Confirmation code"
            );
            string dialogTitle = LanguageManager.GetLangBySpecificKey(
                "RSBot.General",
                "RuSroConfirmationCodeTitle",
                "You have got an email with PIN"
            );
            string dialogContent = LanguageManager.GetLangBySpecificKey(
                "RSBot.General",
                "RuSroConfirmationCodeContent",
                "Enter it and press OK"
            );

            var inputDialog = new InputDialog(dialogFormTitle, dialogTitle, dialogContent);
            if (inputDialog.ShowDialog() != DialogResult.OK)
                return string.Empty;

            string confirmationCode = (string)inputDialog.Value;
            SESSION_STATE sessionState = await Activate(confirmationCode);
            Log.Debug("Sessions State: " + sessionState);

            if (sessionState == SESSION_STATE.SUCCESSFULLY_ACTIVATED)
                tokenResponseContent = await TokenResponse(username, password);
            else
                return string.Empty;
        }

        string accessToken = ExtractAccessToken(tokenResponseContent);
        string refreshToken = ExtractRefreshToken(tokenResponseContent);
        GlobalConfig.Set("RSBot.RuSro.accessToken", accessToken);
        GlobalConfig.Set("RSBot.RuSro.refreshToken", refreshToken);
        GlobalConfig.Save();

        if (tokenResponseContent.Contains("unauthorized"))
        {
            MessageBox.Show(
                $"Session is expired, try again!\n4game error: {ExtractErrorDescription(tokenResponseContent)}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return string.Empty;
        }

        if (tokenResponseContent.Contains("auth.datanotfound"))
        {
            MessageBox.Show(
                $"Check your login and password!\n4game error: {ExtractErrorDescription(tokenResponseContent)}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return string.Empty;
        }

        if (string.IsNullOrEmpty(accessToken))
        {
            MessageBox.Show(tokenResponseContent, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return string.Empty;
        }

        return accessToken;
    }

    private static string ExtractSessionId(string responseContent)
    {
        var jsonResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);
        var sessionId = jsonResponse?.Error?.Data?.SessionId;
        return sessionId;
    }

    private static string ExtractErrorDescription(string responseContent)
    {
        var jsonResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);
        var errorDescription = jsonResponse?.Error?.Description;
        return errorDescription;
    }

    private static string ExtractAccessToken(string responseContent)
    {
        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
        return jsonResponse.access_token;
    }

    private static string ExtractRefreshToken(string responseContent)
    {
        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
        return jsonResponse.refresh_token;
    }

    private static string[] ExtractUsernameEmailFromToken(string accessToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(accessToken);

        string[] result =
        [
            jwtToken.Claims.FirstOrDefault(c => c.Type == "username")?.Value.ToLower(),
            jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value.ToLower(),
        ];
        return result;
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
        SUCCESSFULLY_ACTIVATED,
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
                (string extractedLogin, string password) = await SendCreateGameTokenCodeRequest(
                    clientWebSocket,
                    accessToken,
                    login,
                    sub
                );

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
            accessToken,
            hwid,
            launcherId,
            GenerateRandomString(8)
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
            sub,
            Guid.NewGuid().ToString()
        );

        Log.Debug($"Sending payload: {payload}");
        await SendMessage(clientWebSocket, payload);

        int attempts = 0;
        const int maxAttempts = 10;
        while (attempts < maxAttempts)
        {
            attempts++;
            string response = await ReceiveMessage(clientWebSocket);
            Log.Debug($"Received: {response}");

            using (JsonDocument document = JsonDocument.Parse(response))
            {
                if (
                    document.RootElement.TryGetProperty("notification", out var notification)
                    && notification.GetString() == "invalidate"
                    && document.RootElement.TryGetProperty("params", out var paramsElement)
                    && paramsElement
                        .EnumerateArray()
                        .Any(p => p.TryGetProperty("type", out var type) && type.GetString() == "webshopOwnPromoCodes")
                )
                {
                    //string getWebshopOwnPromoCodesPayload = $"{{\"jsonrpc\":\"2.0\",\"method\":\"getWebshopOwnPromoCodes\",\"params\":{{ \"userId\":{sub},\"from\":0,\"count\":20,\"lang\":\"ru\"}},\"id\":\"{Guid.NewGuid()}\"}}";
                    //Log.Debug($"Some promocodes has experied. Sending promocodes update request: {getWebshopOwnPromoCodesPayload}");
                    await SendMessage(clientWebSocket, payload);

                    //string getWebshopOwnPromoCodesResponse = await ReceiveMessage(clientWebSocket);
                    //Log.Debug($"getWebshopOwnPromoCodesResponse: {getWebshopOwnPromoCodesResponse}");
                    continue;
                }

                if (
                    document.RootElement.TryGetProperty("notification", out notification)
                    && notification.GetString() == "invalidate"
                    && document.RootElement.TryGetProperty("params", out paramsElement)
                    && paramsElement
                        .EnumerateArray()
                        .Any(p => p.TryGetProperty("type", out var type) && type.GetString() == "pushNotification")
                )
                {
                    Log.Notify($"4game pushed notification: {response}");
                    continue;
                }

                if (!document.RootElement.TryGetProperty("result", out JsonElement resultElement))
                {
                    Log.Error($"Response does not contain 'result': {response}");
                    throw new Exception("Unexpected response format: 'result' key is missing");
                }

                return resultElement[0].GetProperty("login").GetString();
            }
        }
        throw new Exception("Max attempts reached, exiting getGameAccount loop.");
    }

    private static async Task<(string, string)> SendCreateGameTokenCodeRequest(
        ClientWebSocket clientWebSocket,
        string accessToken,
        string login,
        string sub
    )
    {
        string payload =
            $"{{\"jsonrpc\":\"2.0\",\"method\":\"createGameTokenCode\",\"params\":{{\"accessToken\":\"{accessToken}\",\"ignoreLicenseAcceptance\":false,\"login\":\"{login}\",\"masterId\":\"{sub}\",\"toPartnerId\":\"silk-ru\",\"lang\":\"ru\"}},\"id\":\"{Guid.NewGuid()}\"}}";

        Log.Debug($"Sending first payload: {payload}");
        await SendMessage(clientWebSocket, payload);

        int attempts = 0;
        const int maxAttempts = 10;
        while (attempts < maxAttempts)
        {
            attempts++;
            string response = await ReceiveMessage(clientWebSocket);
            Log.Debug($"Received response: {response}");

            using (JsonDocument document = JsonDocument.Parse(response))
            {
                if (
                    document.RootElement.TryGetProperty("notification", out var notification)
                    && notification.GetString() == "invalidate"
                    && document.RootElement.TryGetProperty("params", out var paramsElement)
                    && paramsElement
                        .EnumerateArray()
                        .Any(p => p.TryGetProperty("type", out var type) && type.GetString() == "webshopOwnPromoCodes")
                )
                {
                    //string getWebshopOwnPromoCodesPayload = $"{{\"jsonrpc\":\"2.0\",\"method\":\"getWebshopOwnPromoCodes\",\"params\":{{ \"userId\":{sub},\"from\":0,\"count\":20,\"lang\":\"ru\"}},\"id\":\"{Guid.NewGuid()}\"}}";
                    //Log.Debug($"Some promocodes has experied. Sending promocodes update request: {getWebshopOwnPromoCodesPayload}");
                    await SendMessage(clientWebSocket, payload);

                    //string getWebshopOwnPromoCodesResponse = await ReceiveMessage(clientWebSocket);
                    //Log.Debug($"getWebshopOwnPromoCodesResponse: {getWebshopOwnPromoCodesResponse}");
                    continue;
                }

                if (
                    document.RootElement.TryGetProperty("notification", out notification)
                    && notification.GetString() == "invalidate"
                    && document.RootElement.TryGetProperty("params", out paramsElement)
                    && paramsElement
                        .EnumerateArray()
                        .Any(p => p.TryGetProperty("type", out var type) && type.GetString() == "serviceStatusChanged")
                )
                {
                    Log.Notify($"4game service status changed: {response}");
                    continue;
                }

                if (
                    document.RootElement.TryGetProperty("notification", out notification)
                    && notification.GetString() == "invalidate"
                    && document.RootElement.TryGetProperty("params", out paramsElement)
                    && paramsElement
                        .EnumerateArray()
                        .Any(p => p.TryGetProperty("type", out var type) && type.GetString() == "pushNotification")
                )
                {
                    Log.Notify($"4game pushed notification: {response}");
                    continue;
                }

                if (
                    document.RootElement.TryGetProperty("error", out JsonElement error)
                    && error.TryGetProperty("code", out JsonElement errorCode)
                    && errorCode.GetString() == "license.agreement.not.accepted"
                )
                {
                    Log.Debug("License agreement not accepted, attempting to accept it...");

                    var errorData = error.GetProperty("data");
                    int licenseAgreementId = errorData.GetProperty("licenseAgreementId").GetInt32();

                    string acceptLicensePayload =
                        $"{{\"jsonrpc\":\"2.0\",\"method\":\"acceptLicense\",\"params\":{{\"userId\":{sub},\"licenseAgreementId\":{licenseAgreementId},\"lang\":\"ru\"}},\"id\":\"{Guid.NewGuid()}\"}}";

                    Log.Debug($"Sending acceptLicense payload: {acceptLicensePayload}");
                    await SendMessage(clientWebSocket, acceptLicensePayload);

                    string acceptResponse = await ReceiveMessage(clientWebSocket);
                    Log.Debug($"Received acceptLicense response: {acceptResponse}");

                    using (JsonDocument acceptDocument = JsonDocument.Parse(acceptResponse))
                    {
                        if (
                            acceptDocument.RootElement.TryGetProperty("result", out JsonElement result)
                            && result.ValueKind == JsonValueKind.Object
                        )
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

                if (!document.RootElement.TryGetProperty("result", out JsonElement resultElement))
                {
                    Log.Error($"Response does not contain 'result': {response}");
                    throw new Exception("Unexpected response format: 'result' key is missing");
                }

                string extractedLogin = resultElement.GetProperty("login").GetString();
                string password = resultElement.GetProperty("password").GetString();
                return (extractedLogin, password);
            }
        }
        throw new Exception("Max attempts reached, exiting createGameTokenCode loop.");
    }

    private static async Task SendMessage(ClientWebSocket clientWebSocket, string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        await clientWebSocket.SendAsync(
            new ArraySegment<byte>(messageBytes),
            WebSocketMessageType.Text,
            true,
            CancellationToken.None
        );
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
