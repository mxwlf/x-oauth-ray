using System.Collections.Specialized;

namespace Net.Mxwlf.xOAuthRay;

public class AuthResponseParser
{
    public static AuthorizationCodeResponse Parse(NameValueCollection queryString)
    {
        var response = new AuthorizationCodeResponse();
        // Checks for errors.
        if (queryString.Get("error") != null)
        {
            response.IsSuccessful = false;

            response.ErrorMessage = $"OAuth authorization error: {queryString.Get("error")}.";
            return response;
        }
        // if (queryString.Get("code") == null
        //     || queryString.Get("state") == null)
        // {
        //     response.IsSuccessful = false;
        //     
        //    response.ErrorMessage = ("Malformed authorization response. " + queryString);
        //
        //    return response;
        // }
        
        // extracts the code
        response.AuthorizationCode = queryString.Get("code");
        response.IsSuccessful = true;

        return response;

    }
}