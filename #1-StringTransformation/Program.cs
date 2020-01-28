using System;
using System.Globalization;
using McMaster.Extensions.CommandLineUtils;

namespace StringTransformation
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "String Transformation",
                Description = "Digunakan untuk mengubah text menjadi lowercase, uppercase dan capitalize",
                ShortVersionGetter = () => "1.0.0"
            };

            rootApp.Command("lowercase",app=>
            {
                app.Description = "Mengecilkan Text";
                var str = app.Argument("string","Input text");
                app.OnExecute(()=>
                {
                    Console.WriteLine(str.Value.ToLower());
                });
            });
            rootApp.Command("uppercase",app=>
            {
                app.Description = "Membesarkan Text";
                var str = app.Argument("string","Input text");
                app.OnExecute(()=>
                {
                    Console.WriteLine(str.Value.ToUpper());
                });
            });

            rootApp.Command("capitalize",app=>
            {
                app.Description = "Capitalize Text Pertama";
                var str = app.Argument("string","Input text");
                app.OnExecute(()=>
                {
                    var textLower = str.Value.ToLower();
                    string[] split = textLower.Split(' ');
                    bool firstChar = true;
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    foreach(string str in split)
                    {
                        if (firstChar)
                        {
                            Console.Write(textInfo.ToTitleCase(str)+" ");
                        }
                        else
                        {
                            Console.Write(str);
                        }
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
