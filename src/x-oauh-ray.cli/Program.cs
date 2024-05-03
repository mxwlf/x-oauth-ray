using Net.Mxwlf.xOAuthRay.Servers;

namespace Net.Mxwlf.xOAuthRay.Cli
{
    internal class Program : ProgramBase
    {
        static async Task Main(string[] args)
        {
            // Get an auth server and client 
            var redirectUri = "http://localhost:56612/";
            var clientId = "";
            var clientSecret = "";
            
            var authServer = AuthorizationServerFactory.GetServer(KnownAuthServers.MicrosoftAd);
            var appClient = ClientFactory.GetPublicClientApp(redirectUri, clientId);
            var serverClient = ClientFactory.GetPrivateService(redirectUri, clientId, clientSecret);
            
            // Start the local http server that will listen from responses from the auth server when is done authenticating the user.
            appClient.LocalCallbackListener.Start();
            
            // Send the request to the authorization server to challenge the user to authenticate
            await appClient.RequestAuthorizationCode(authServer);

            // Wait until the user is authenticated and the authorization server sends the auth code to the redirect uri.
            var response = await appClient.LocalCallbackListener.AwaitForAuthorizationCodeResponse();
            
            if (response.IsSuccessful.HasValue && response.IsSuccessful.Value)
            {
                Console.WriteLine("Success! the code is " + response.AuthorizationCode);
            }
            else
            {
                Console.WriteLine("Not successful, the error code is " + response.ErrorMessage);
            }

            var tokenResponse = await serverClient.RequestToken(response.AuthorizationCode, authServer);
            
            Console.ReadLine();
        }
    }
}