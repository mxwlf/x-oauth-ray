namespace Net.Mxwlf.xOAuthRay;

public class AuthOptionsBuilder
{
    private string _clientId;
    private string _redirectProtocol;
    private string _redirectAddress;
    private int _redirectPort;
    
    public AuthOptionsBuilder WithClientId(string clientId)
    {
        this._clientId = clientId;
        return this;
    }

    public AuthOptionsBuilder WithRedirect(string protocol, string address, int port)
    {

        this._redirectProtocol = protocol;
        this._redirectAddress = address;
        this._redirectPort = port;

        return this;
    }

    public AuthorizationRequestOptions Build()
    {
        var redirectUri = $"{_redirectProtocol}{this._redirectAddress}:{this._redirectPort}/";
        return new AuthorizationRequestOptions { ClientId = _clientId, RedirectUri = redirectUri };
    }
}