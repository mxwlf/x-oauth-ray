using System.Net.Http.Headers;
using System.Text;
using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay.Clients;

public class PrivateService
{
    private readonly string _redirectUri;
    private readonly string _clientId;
    private readonly string _clientSecret;

    internal PrivateService(string redirectUri, string clientId, string clientSecret)
    {
        _redirectUri = redirectUri;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }
    public async Task<TokenResponse> RequestToken(string authorizationCode, IAuthorizationServer authorizationServer)
    {
        var redirectUriEscaped = Uri.EscapeDataString(_redirectUri);
        var tokenRequestBody = $"code={authorizationCode}&redirect_uri={redirectUriEscaped}&client_id={_clientId}&client_secret={_clientSecret}&scope=&grant_type=authorization_code";

        var requestMessage = new HttpRequestMessage();
        requestMessage.Method = HttpMethod.Post;
        requestMessage.Content = new StringContent(tokenRequestBody, Encoding.ASCII,
            MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded"));

        var response = await authorizationServer.RequestToken(requestMessage).ConfigureAwait(false);

        return response;

    }
}