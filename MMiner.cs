using System;
using System.Net;
using System.Diagnostics;

class MoneroMiner {
    static void Main(string[] args) {
        // Gather dependencies
        string minerUrl = "https://github.com/xmrig/xmrig/releases/download/v6.7.1/xmrig-6.7.1-win64.zip";
        string configUrl = "https://raw.githubusercontent.com/xmrig/xmrig/master/src/config.json";

        // Download miner
        using (WebClient client = new WebClient()) {
            client.DownloadFile(minerUrl, "xmrig.zip");
        }

        // Extract miner
        Process.Start("powershell.exe", "-Command Expand-Archive -Path xmrig.zip -DestinationPath xmrig");

        // Download config file
        using (WebClient client = new WebClient()) {
            client.DownloadFile(configUrl, "xmrig/config.json");
        }

        // Set sending address
        string address = "YOUR_MONERO_WALLET_ADDRESS";
        Process.Start("powershell.exe", "-Command (Get-Content xmrig/config.json) -replace 'YOUR_WALLET_ADDRESS', '" + address + "' | Set-Content xmrig/config.json");

        // Start miner
        Process.Start("xmrig/xmrig.exe", "--config=xmrig/config.json");
    }
}
