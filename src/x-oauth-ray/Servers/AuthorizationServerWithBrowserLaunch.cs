using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay.Servers;

public class AuthorizationServerWithBrowserLaunch : IAuthorizationServer
{
    private readonly IBrowserLauncher _browserLauncher;
    private readonly AuthServerInfo _authServerInfo;
    public AuthorizationServerWithBrowserLaunch(IBrowserLauncher browserLauncher, AuthServerInfo authServerInfo)
    {
        _browserLauncher = browserLauncher;
        _authServerInfo = authServerInfo;
    }
    public async Task RequestAuthorizationCode(string authRequest)
    {
        // Append the authorization endpoint of the server
        authRequest = $"{_authServerInfo.AuthorizationEndpoint}/{authRequest}";
        await _browserLauncher.Launch(authRequest);
    }

    public async Task<TokenResponse> RequestToken(HttpRequestMessage requestMessage)
    {
        requestMessage.RequestUri = new Uri(_authServerInfo.TokenEndpoint);

        var client = new HttpClient();
        var response = await client.SendAsync(requestMessage).ConfigureAwait(false);

        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        throw new NotImplementedException();
    }
}