using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay;

public class AuthorizationRequesterFactory
{
    private readonly IBrowserLauncher _browserLauncher;

    public AuthorizationRequesterFactory(IBrowserLauncher browserLauncher)
    {
        _browserLauncher = browserLauncher;
    }

    public AuthorizationRequester GetRequester()
    {
        return new AuthorizationRequester(this._browserLauncher);
    }
}