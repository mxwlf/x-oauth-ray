namespace Net.Mxwlf.xOAuthRay.Clients;

public class ClientFactory
{
    public PublicClientApp GetPublicClientApp(string redirectUri, string clientId)
    {
        return new PublicClientApp(redirectUri, clientId);
    }

    public PrivateService GetPrivateService(string redirectUri, string clientId, string clientSecret)
    {
        return new PrivateService(redirectUri, clientId, clientSecret);
    }
}