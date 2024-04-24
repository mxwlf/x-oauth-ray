
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.Mxwlf.xOAuthRay.Abstractions;
using Net.Mxwlf.xOAuthRay.BrowserLaunchers;

namespace Net.Mxwlf.xOAuthRay.Cli
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var codeGrant = GetServiceInstance();
            
            var authOptionsBuilder = new AuthOptionsBuilder();
            authOptionsBuilder.WithRedirect("http://", "localhost", 56612);
            authOptionsBuilder.WithClientId("cc08bfaf-4f8a-4b13-ab98-6a73bb46d501");
            
            var authOptions = authOptionsBuilder.Build();

            var response = await codeGrant.Execute(authOptions, KnownAuthServers.Google);

            if (response.IsSuccessful.HasValue && response.IsSuccessful.Value)
            {
                Console.WriteLine("Success! the code is " + response.AuthorizationCode);
            }
            else
            {
                Console.WriteLine("Not successful, the error code is " + response.ErrorMessage);
            }
            Console.ReadLine();
        }

        static AuthorizationCodeGrant GetServiceInstance()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton<AuthorizationCodeGrant>();
            builder.Services.AddSingleton<IBrowserLauncher, GoogleChromeBrowserLauncher>();
            builder.Services.AddSingleton<AuthorizationRequester>();
            builder.Services.AddSingleton<AuthorizationServerFactory>();

            var host = builder.Build();

            return host.Services.GetService<AuthorizationCodeGrant>();
        }
    }
}