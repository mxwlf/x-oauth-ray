using System.Collections.Specialized;
using System.Net;

namespace Net.Mxwlf.xOAuthRay;

public class LocalCallbackListener
{
    private HttpListener http;
    private readonly string _redirectUri;

    public LocalCallbackListener(string redirectUri)
    {
        _redirectUri = redirectUri;
        http = new HttpListener();
        http.Prefixes.Add(redirectUri);
    }

    public void Start()
    {
        // http = new HttpListener();
        // http.Prefixes.Add(redirectUrl);
        http.Start();
    }

    public async Task<AuthorizationCodeResponse> AwaitForAuthorizationCodeResponse()
    {
        var response = await AwaitResponse();

        var codeResponse = AuthResponseParser.Parse(response);

        return codeResponse;
    }

    internal async Task<NameValueCollection> AwaitResponse()
    {
        var context = await http.GetContextAsync();
        
        // Sends an HTTP response to the browser.
        var response = context.Response;
        string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://github.com/mxwlf/x-oauth-ray'></head><body>You can now return to the app.</body></html>");
        var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        var responseOutput = response.OutputStream;
        Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
        {
            responseOutput.Close();
            http.Stop();
            Console.WriteLine("HTTP server stopped.");
        });

        return context.Request.QueryString;
    }
    
}