using System.Diagnostics;
using Net.Mxwlf.xOAuthRay.Abstractions;

namespace Net.Mxwlf.xOAuthRay.BrowserLaunchers;

public class GoogleChromeBrowserLauncher : IBrowserLauncher
{
    public Task Launch(string address)
    {
        var procStartInfo = new ProcessStartInfo("/../../../../../../../../../Applications/Google Chrome.app/Contents/MacOS/Google Chrome", address)
        {
            RedirectStandardOutput = false,
            UseShellExecute = true,
            CreateNoWindow = false
        };

        var proc = new Process { StartInfo = procStartInfo };
        proc.Start();
        
        return Task.CompletedTask;
    }
}