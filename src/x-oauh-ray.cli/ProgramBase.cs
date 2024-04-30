using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.Mxwlf.xOAuthRay.Abstractions;
using Net.Mxwlf.xOAuthRay.BrowserLaunchers;
using Net.Mxwlf.xOAuthRay.Clients;
using Net.Mxwlf.xOAuthRay.Servers;

namespace Net.Mxwlf.xOAuthRay.Cli;

public class ProgramBase
{

    private static IHost _host;
    private static AuthorizationServerFactory _authorizationServerFactory;
    private static ClientFactory _clientFactory;
    public static AuthorizationServerFactory AuthorizationServerFactory
    {
        get
        {
            if (_authorizationServerFactory == null)
            {
                _authorizationServerFactory = _host.Services.GetService<AuthorizationServerFactory>();
            }

            return _authorizationServerFactory;
        }
    }

    public static ClientFactory ClientFactory
    {
        get
        {
            if (_clientFactory == null)
            {
                _clientFactory = _host.Services.GetService<ClientFactory>();
            }

            return _clientFactory;
        }
    }

    static ProgramBase()
    {
        Startup();
    }
    private static void Startup()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddSingleton<IBrowserLauncher, GoogleChromeBrowserLauncher>();
        builder.Services.AddSingleton<AuthorizationServerFactory>();
        builder.Services.AddSingleton<ClientFactory>();

        _host = builder.Build();

    }
    
}