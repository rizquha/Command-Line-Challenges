using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using McMaster.Extensions.CommandLineUtils;


namespace IPAddress
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "IP Address",
                Description = "Digunakan untuk mendapatkan Private IP Address",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("ip",app=>
            {
                app.Description = "Get Private IP Address";
                app.OnExecute(()=>
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    var ip= host.AddressList
                                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                    Console.WriteLine("IP Address : "+ip);
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
