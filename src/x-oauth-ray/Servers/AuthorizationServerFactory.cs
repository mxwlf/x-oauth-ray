using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay.Servers;

public class AuthorizationServerFactory
{
    private readonly IBrowserLauncher _browserLauncher;

    public AuthorizationServerFactory(IBrowserLauncher browserLauncher)
    {
        _browserLauncher = browserLauncher;
    }
    public IAuthorizationServer GetServer(AuthServerInfo serverInfo)
    {
        return new AuthorizationServerWithBrowserLaunch(_browserLauncher, serverInfo);
    }
}