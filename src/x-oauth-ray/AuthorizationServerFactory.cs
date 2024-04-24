namespace Net.Mxwlf.xOAuthRay;

public class AuthorizationServerFactory
{
    private readonly AuthorizationRequester _authorizationRequester;

    public AuthorizationServerFactory(AuthorizationRequester authorizationRequester)
    {
        _authorizationRequester = authorizationRequester;
    }
    public AuthorizationServer GetServer(AuthServerInfo serverInfo)
    {
        return new AuthorizationServer(serverInfo, _authorizationRequester);
    }
}