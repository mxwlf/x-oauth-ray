namespace Net.Mxwlf.xOAuthRay.Clients;

public class ClientFactory
{
    public PublicClientApp GetPublicClientApp(string redirectUri, string clientId)
    {
        return new PublicClientApp(redirectUri, clientId);
    }
}