using System.Text;
using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay;

public class AuthorizationRequester
{
    private readonly IBrowserLauncher _browserLauncher;

    public AuthorizationRequester(IBrowserLauncher browserLauncher)
    {
        
        ArgumentNullException.ThrowIfNull(browserLauncher);
        _browserLauncher = browserLauncher;
    }

    public async Task<AuthorizationResponse> Request(string authorizationEndpoint, string redirectUri, string clientId,CancellationToken cancellationToken)
    {
        if (!cancellationToken.IsCancellationRequested)
        {
            var listener = new LocalCallbackListener();
            listener.Start(redirectUri);
            var authRequest = GetAuthorizationRequest(authorizationEndpoint, redirectUri, clientId);
            await _browserLauncher.Launch(authRequest);

            var queryStringValues = await listener.AwaitResponse();

            var response = new AuthResponseParser().Parse(queryStringValues);

            return response;
        }

        return new AuthorizationResponse();
    }

    internal static string GetAuthorizationRequest(string authorizationEndpoint, string redirectUri, string clientId)
    {
        var stringBuilder = new StringBuilder($"{authorizationEndpoint}?");
        stringBuilder.Append("response_type=code");
        stringBuilder.Append($"&redirect_uri={Uri.EscapeDataString(redirectUri)}");
        stringBuilder.Append($"&client_id={clientId}");
        stringBuilder.Append("&scope=openid%20profile");

        return stringBuilder.ToString();
    }

}