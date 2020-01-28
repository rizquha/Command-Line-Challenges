using System;
using McMaster.Extensions.CommandLineUtils;

namespace RandomString
{
    class Program
    {
        public static string random(int length, bool letters, bool numbers, bool uppercase, bool lowercase)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var strChars = new char[length];
            var random = new Random();

            if(!letters==true)
            {
                for (int i = 0; i < strChars.Length; i++)
                {
                 strChars[i] = chars[random.Next(chars.Length-10,chars.Length)];
                }
                return new String(strChars);
            }
            else if(!numbers==true)
            {
                for (int i = 0; i < strChars.Length; i++)
                {
                 strChars[i] = chars[random.Next(0,chars.Length-10)];
                }

                if(uppercase == true)
                {
                    return new String(strChars).ToUpper();
                }
                else if(lowercase == true)
                { 
                    return new String(strChars).ToLower();
                }

                return new String(strChars);
            }
            else
            {
                for (int i = 0; i < strChars.Length; i++)
                {
                 strChars[i] = chars[random.Next(chars.Length)];
                }
                
                if(uppercase == true && lowercase==false)
                {
                    return new String(strChars).ToUpper();
                }
                else if(lowercase == true && uppercase == false)
                {
                    return new String(strChars).ToLower();
                }
                else
                {
                    return new String(strChars);
                }
            }
        }
        static int Main(string[] args)
        {
            
            var rootApp = new CommandLineApplication()
            {
                Name = "Random String",
                Description = "Digunakan untuk generate random string",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("random",app=>
            {

                app.Description = "Generate Random String";
                var text = app.Argument("Text","Input Text");

                var length = app.Option("--length","Random Lengths",CommandOptionType.SingleOrNoValue);
                var letters = app.Option("--letters","Random Lengths",CommandOptionType.SingleOrNoValue);
                var numbers = app.Option("--numbers","Random Lengths",CommandOptionType.SingleOrNoValue);
                var uppercase = app.Option("--uppercase","Random Lengths",CommandOptionType.NoValue);
                var lowercase = app.Option("--lowercase","Random Lengths",CommandOptionType.NoValue);

                int length_ = 32;
                bool letters_ = true;
                bool numbers_ = true;
                bool uppercase_=true;
                bool lowercase_ = true;
                app.OnExecute(()=>
                {
                    if (length.HasValue())
                    {
                        length_ = Convert.ToInt32(length.Value());
                    }
                    if(letters.HasValue())
                    {
                        if(Convert.ToBoolean(letters.Value()) == false)
                        {
                            letters_ = false;
                        }
                    }
                    if(numbers.HasValue())
                    {
                        if(Convert.ToBoolean(numbers.Value()) == false)
                        {
                            numbers_ = false;
                        }
                    }
                    if(uppercase.HasValue())
                    {
                            uppercase_ = true;
                            lowercase_ = false;
                    }
                    if(lowercase.HasValue())
                    {
                            lowercase_ = true;
                            uppercase_=false;
                    }
                    Console.WriteLine(random(length_,letters_,numbers_,uppercase_,lowercase_));

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
