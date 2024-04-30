using System.Text;
using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay.Clients;

public class PublicClientApp
{
    private readonly string _redirectUri;
    private readonly string _clientId;
    private readonly LocalCallbackListener _localCallbackListener;

    internal PublicClientApp(string redirectUri, string clientId)
    {
        _redirectUri = redirectUri;
        _clientId = clientId;
        _localCallbackListener = new LocalCallbackListener(redirectUri);
    }

    public LocalCallbackListener LocalCallbackListener => _localCallbackListener;

    public async Task RequestAuthorizationCode(IAuthorizationServer authorizationServer)
    {
        var authRequest = GetAuthorizationRequest(_redirectUri, _clientId);
        await authorizationServer.RequestAuthorizationCode(authRequest);
        
    }
    internal static string GetAuthorizationRequest(string redirectUri, string clientId)
    {
        var stringBuilder = new StringBuilder("?response_type=code");
        stringBuilder.Append($"&redirect_uri={Uri.EscapeDataString(redirectUri)}");
        stringBuilder.Append($"&client_id={clientId}");
        stringBuilder.Append("&scope=openid%20profile");

        return stringBuilder.ToString();
    }
}