using System;
using System.Diagnostics;

namespace EdgeToChrome.NET {

    public class EdgeToChrome {

        public static void Main(string[] args) {
            if (args.Length > 1) {
                ProcessStartInfo processStartInfo;
                if (args[0].ToLower().Equals("--")) {
                    String url = args[1];
                    url = url.Replace("\"", "");
                    url = url.Replace("microsoft-edge:", "");

                    if (url.Contains("url=")) {
                        foreach (String value in url.Split('&')) {
                            if (value.StartsWith("url=")) {
                                url = value.Replace("url=", "");
                                url = Uri.UnescapeDataString(url);
                            }
                        }
                    }

                    Console.WriteLine(url);

                    processStartInfo = new ProcessStartInfo() {
                        FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                        UseShellExecute = true,
                        RedirectStandardInput = false,
                        RedirectStandardOutput = false,
                        Arguments = String.Format(url)
                    };
                    Process.Start(processStartInfo);
                    return;
                }
            }
            Console.WriteLine("Usage: <EdgeToChrome|msedge> -- \"microsoft-edge:URL\"");
        }

    }
}
