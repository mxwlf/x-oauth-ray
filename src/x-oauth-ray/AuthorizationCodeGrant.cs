using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay;

public class AuthorizationCodeGrant : GrantBase
{
    private readonly AuthorizationServerFactory _serverFactory;
    public AuthorizationCodeGrant(AuthorizationServerFactory serverFactory)
    {
        ArgumentNullException.ThrowIfNull(serverFactory);
        _serverFactory = serverFactory;

    }
    public override async Task<AuthorizationResponse> Execute(AuthorizationRequestOptions authOptions, AuthServerInfo authServerInfo)
    {
        var authServer = _serverFactory.GetServer(KnownAuthServers.Google);

        var response = await authServer.GetAuthorizationCode(authOptions);

        return response;
    }
}