using System.Collections.Specialized;
using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay;

public class AuthResponseParser
{
    public AuthorizationResponse Parse(NameValueCollection queryString)
    {
        var response = new AuthorizationResponse();
        // Checks for errors.
        if (queryString.Get("error") != null)
        {
            response.IsSuccessful = false;

            response.ErrorMessage = String.Format("OAuth authorization error: {0}.", queryString.Get("error"));
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