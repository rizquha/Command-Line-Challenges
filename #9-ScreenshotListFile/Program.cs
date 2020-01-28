using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using McMaster.Extensions.CommandLineUtils;
using System.IO;

namespace ScreenshotListFile
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
           var rootApp = new CommandLineApplication()
            {
                Name = "Screenshoot From a List Of File",
                Description = "Digunakan untuk mendapatkan screenshot dari list sebuah file",
                ShortVersionGetter = () => "1.0.0",
            };

            rootApp.Command("screenshot-list",app => 
            {
                app.Description = "Get Screenshoot From a List Of File";

                var text = app.Argument("Text","Input Text");
                var format = app.Option("--format","Format Lengths",CommandOptionType.SingleOrNoValue);
                
                app.OnExecuteAsync(async cancellationToken => 
                {
                    if(format.HasValue())
                    {
                        var list = File.ReadLines(text.Value);
                        foreach(var lt in list)
                        {
                            await SsList(lt,format.Value());
                        }
                    }
                });
            });

            return rootApp.Execute(args);
        }

        public static async Task SsList(string URL ,string Format)
          {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(URL);

            var ScreenShot = new ScreenshotOptions()
            {
                FullPage = true
                
            };

            if(Format == "jpg" || Format=="png")
            {
                var change = URL.Replace("/","_").Replace(":","_");
                await page.ScreenshotAsync($"{change}.{Format}",ScreenShot);
                await page.CloseAsync();
            }
            else if(Format =="pdf")
            {
                var change = URL.Replace("/","_").Replace(":","_");
                await page.PdfAsync($"{change}.{Format}");
                await page.CloseAsync();
            }
        }
    }
}
