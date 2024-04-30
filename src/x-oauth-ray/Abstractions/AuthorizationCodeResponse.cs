namespace Net.Mxwlf.xOAuthRay;

public class AuthorizationCodeResponse
{
    public string AuthorizationCode { get; set; }

    public bool? IsSuccessful { get; set; }

    public string ErrorMessage { get; set; }
    
}