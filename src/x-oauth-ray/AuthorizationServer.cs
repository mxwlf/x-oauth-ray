using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay;

public class AuthorizationServer
{
    private readonly AuthServerInfo _authServerInfo;
    private readonly AuthorizationRequester _authRequester;

    public AuthorizationServer(AuthServerInfo authServerInfo, AuthorizationRequester authRequester)
    {
        _authServerInfo = authServerInfo;
        _authRequester = authRequester;
    }

    public async Task<AuthorizationResponse> GetAuthorizationCode(AuthorizationRequestOptions authOptions)
    {
        var response = await _authRequester.Request(_authServerInfo.AuthorizationEndpoint, authOptions.RedirectUri, authOptions.ClientId, CancellationToken.None);
        return response;
    }
}