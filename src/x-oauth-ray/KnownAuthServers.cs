namespace Net.Mxwlf.xOAuthRay;

public static class KnownAuthServers
{
    private static readonly AuthServerInfo _google = new AuthServerInfo()
        { AuthorizationEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize" };

    public static AuthServerInfo Google => _google;
}