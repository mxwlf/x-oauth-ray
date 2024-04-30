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
}