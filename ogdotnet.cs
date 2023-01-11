using System;
using System.Diagnostics;
using System.Net;

class NetFrameworkInstaller {
    static void Main(string[] args) {
        // URL for the .NET Framework installer
        string dotNetFrameworkUrl = "https://download.microsoft.com/download/9/3/A/93A9307D-F6A4-49B6-B5B6-3C8C03D8C7E1/dotnet-framework-runtime-4.0.0-web-x86-enu.exe";

        // Download the installer
        using (WebClient client = new WebClient()) {
            client.DownloadFile(dotNetFrameworkUrl, "dotnet-framework.exe");
        }

        // Start the installer
        Process.Start("dotnet-framework.exe", "/quiet /norestart");

        // Run the installer 
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet-framework.exe",
                Arguments = "/quiet /norestart",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        process.WaitForExit();
    }
}
