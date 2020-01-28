using System;
using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;


namespace InfiniteInputs
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "Infinite Inputs",
                Description = "Menjumlahkan infinite inputs sampai bertemu empty input",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("infiniteinputs",app=>
            {
                app.Description = "Sum every numeric inputs until it get empty input";
                int counter = 1;
                int sum =0;
                app.OnExecute(()=>
                {
                    for(int i=1;i<=counter;i++)
                    {
                        Console.Write("Insert {0} number : ",i);
                        string input = Console.ReadLine();
                        if(input!="")
                        {
                            sum+=Convert.ToInt32(input);
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("===========================");
                            Console.WriteLine("Result : {0}",sum);
                            
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
