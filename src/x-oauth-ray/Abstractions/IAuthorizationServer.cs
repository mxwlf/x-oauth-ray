namespace Net.Mxwlf.xOAuthRay.Abstractions;

public interface IAuthorizationServer
{
   Task RequestAuthorizationCode(string authRequest);
   
   Task<TokenResponse> RequestToken(HttpRequestMessage requestMessage);
}