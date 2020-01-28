using System;
using McMaster.Extensions.CommandLineUtils;
using System.Text;

namespace Obfuscator
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "Obfuscator",
                Description = "Digunakan untuk mengenkripsi text",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("obfuscator",app=>
            {
                app.Description = "Mengubah Isi Text";
                var str = app.Argument("string","Input text");
                app.OnExecute(()=>
                {
                    var value = str.Value;
                    Encoding encoding = Encoding.ASCII;
                    Byte[] bt = encoding.GetBytes(value);
                    foreach(Byte item in bt)
                    {
                        Console.Write("&#{0};",item);
                    }
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
