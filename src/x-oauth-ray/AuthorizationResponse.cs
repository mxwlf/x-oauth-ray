namespace Net.Mxwlf.xOAuthRay.Abstractions;

public class AuthorizationResponse
{
    public string AuthorizationCode { get; set; }

    public bool? IsSuccessful { get; set; }

    public string ErrorMessage { get; set; }
}