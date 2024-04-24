using System.Collections.Specialized;
using System.Net;
using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay;

public class LocalCallbackListener
{
    private HttpListener http;
    public void Start(string redirectUrl)
    {
        http = new HttpListener();
        http.Prefixes.Add(redirectUrl);
        http.Start();
    }

    public async Task<NameValueCollection> AwaitResponse()
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