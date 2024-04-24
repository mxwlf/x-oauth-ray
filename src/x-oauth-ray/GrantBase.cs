namespace Net.Mxwlf.xOAuthRay;

public abstract class GrantBase
{
    public abstract Task Execute(AuthorizationRequestOptions authOptions, AuthServerInfo authServerInfo);
}