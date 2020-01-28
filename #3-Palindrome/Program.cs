using System;
using McMaster.Extensions.CommandLineUtils;


namespace Palindrome
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "Palindrome",
                Description = "Digunakan untuk mendeteksi suatu string termasuk palindrome atau bukan",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("palindrome",app=>
            {
                app.Description = "Palindrome Text";
                var str = app.Argument("string","Input text");
                app.OnExecute(()=>
                {
                    var input = str.Value;
                    var replace = input.Replace(@",",string.Empty)
                                       .Replace(@" ",string.Empty)
                                       .Replace(@".",string.Empty).ToLower();
                    Console.WriteLine("String : "+input);
                    string reverse="";
                   int length = replace.Length-1;
                   while(length>=0)
                   {
                       reverse +=replace[length];
                       length--;
                   }
                   if(reverse==replace)
                   {
                       Console.WriteLine("Is Palindrome ? Yes");
                   }else
                   {
                       Console.WriteLine("Is Palindrome ? No");

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
