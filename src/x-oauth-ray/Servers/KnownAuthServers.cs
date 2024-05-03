namespace Net.Mxwlf.xOAuthRay.Servers;

public static class KnownAuthServers
{
    private static readonly AuthServerInfo _microsoftAd = new AuthServerInfo()
    {
        AuthorizationEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize",
        TokenEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/token"
    };
    
    

    public static AuthServerInfo MicrosoftAd => _microsoftAd;
}