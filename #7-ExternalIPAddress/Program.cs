using System;
using System.Net.Http;
using McMaster.Extensions.CommandLineUtils;


namespace ExternalIPAddress
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "External IP Address",
                Description = "Digunakan untuk mendapatkan IP Address public",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("ip-external",app=>
            {
                app.Description = "Get Public IP Address";
                var str = app.Argument("string","Input text");
                app.OnExecute(()=>
                {
                    string url = "http://checkip.dyndns.org/";
                    string ip = "";

                    using (var client = new HttpClient())
                    {
                        var result = client.GetAsync(url)
                                       .Result
                                       .Content
                                       .ReadAsStringAsync()
                                       .Result;

                        ip = result.Split(':')[1].Split('<')[0].Replace(" ",string.Empty);
                    }
                    Console.WriteLine(ip);
                });

            });
            rootApp.OnExecute(()=>
            {
                rootApp.ShowHelp();
            });
            return rootApp.Execute(args);
        }
    }
}
