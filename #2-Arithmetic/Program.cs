using System;
using System.Linq;
using McMaster.Extensions.CommandLineUtils;

namespace Arithmetic
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "Arithmetic",
                Description = "Digunakan untuk mengubah melakukan add, substract, multiply, divide pada numbers",
                ShortVersionGetter = () => "1.0.0"
            };

            rootApp.Command("add",app=>
            {
                app.Description = "Menambahkan Bilangan";
                var str = app.Argument("string","Input Numbers");
                app.OnExecute(()=>
                {
                    int add= 0;
                    string[] value = str.Value.Split(' ').ToArray();
                    int[] numbers = Array.ConvertAll(value,Int32.Parse);
                    for(int i=0;i<numbers.Length;i++)
                    {
                        add+=numbers[i];
                    }
                    Console.WriteLine("Result Of Add Numbers : "+add);
                });
            });

            rootApp.Command("substract",app=>
            {
                app.Description = "Mengurangi Bilangan";
                var str = app.Argument("string","Input Numbers");
                app.OnExecute(()=>
                {
                    string[] value = str.Value.Split(' ').ToArray();
                    int[] numbers = Array.ConvertAll(value,Int32.Parse);
                    int subs= numbers[0];
                    for(int i=1;i<numbers.Length;i++)
                    {
                        subs-=numbers[i];
                    }
                    Console.WriteLine("Result Of Add Numbers : "+subs);
                });
            });
            rootApp.Command("multiply",app=>
            {
                app.Description = "Mengalikan Bilangan";
                var str = app.Argument("string","Input Numbers");
                app.OnExecute(()=>
                {
                    string[] value = str.Value.Split(' ').ToArray();
                    int[] numbers = Array.ConvertAll(value,Int32.Parse);
                    int multiply= numbers[0];
                    for(int i=1;i<numbers.Length;i++)
                    {
                        multiply*=numbers[i];
                    }
                    Console.WriteLine("Result Of Add Numbers : "+multiply);
                });
            });
            rootApp.Command("divide",app=>
            {
                app.Description = "Mengalikan Bilangan";
                var str = app.Argument("string","Input Numbers");
                app.OnExecute(()=>
                {
                    string[] value = str.Value.Split(' ').ToArray();
                    int[] numbers = Array.ConvertAll(value,Int32.Parse);
                    int divide= numbers[0];
                    for(int i=1;i<numbers.Length;i++)
                    {
                        divide/=numbers[i];
                    }
                    Console.WriteLine("Result Of Add Numbers : "+divide);
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
