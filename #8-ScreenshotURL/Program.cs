using System;
using PuppeteerSharp;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using System.IO;

namespace ScreenshotURL
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "Screenshot From a URL",
                Description = "Digunakan untuk melakukan screenshot dari URL",
                ShortVersionGetter = () => "1.0.0",
            };

            rootApp.Command("screenshot",app => 
            {
                app.Description = "Get Screenshot From a URL";

                var text = app.Argument("Text","Input Text");
                var format = app.Option("--format","Random Lengths",CommandOptionType.SingleOrNoValue);
                var output = app.Option("--output","Random Lengths",CommandOptionType.SingleOrNoValue);
                
                
                app.OnExecuteAsync(async cancellationToken => 
                {
                    if(format.HasValue())
                    {
                        await SsFormat(text.Value,format.Value());
                    }
                    if(output.HasValue())
                    {
                        await SsOutput(text.Value,output.Value());
                    }
                });
            });

            return rootApp.Execute(args);
        }

        public static async Task SsFormat(string URL,string Format)
        {

            if(Format == "jpg")
            {
                string pathFiles = "D:/Users/bsi50129/.vscode/Task Command Line/#8-ScreenshotURL/";
                string[] newFile = Directory.GetFiles(pathFiles,"*.jpg");
                await screenshotFormat(newFile,Format,URL);
            }
            else if (Format == "png")
            {
                string pathFiles = "D:/Users/bsi50129/.vscode/Task Command Line/#8-ScreenshotURL/";
                string[] newFile = Directory.GetFiles(pathFiles,"*.png");
                await screenshotFormat(newFile,Format,URL);
            }
            else if(Format =="pdf")
            {
                string pathFiles = "D:/Users/bsi50129/.vscode/Task Command Line/#8-ScreenshotURL/";
                string[] newFile = Directory.GetFiles(pathFiles,"*.pdf");
                await screenshotFormat(newFile,Format,URL);
            }
        }

        public static async Task screenshotFormat(string[] newFile, string Format,string URL)
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

            foreach(string fl in newFile)
            {
                if(fl.Contains("screenshot"))
                {
                    var result = Path.GetFileNameWithoutExtension(fl);
                    var Replace = result.Replace("screenshot-","");
                    var counter = int.Parse(Replace)+1;
                    if(Format=="png" || Format=="jpg")
                    {
                        await page.ScreenshotAsync($"screenshot-0{counter}.{Format}",ScreenShot);
                    }else{
                        await page.PdfAsync($"screenshot-0{counter}.{Format}");
                    } 
                }
            }

            if(Format=="png" || Format=="jpg")
            {
                await page.ScreenshotAsync($"screenshot-0{1}.{Format}",ScreenShot); 
            }
            else
            {
                await page.PdfAsync($"screenshot-0{1}.{Format}");
            }
            await page.CloseAsync();
        }

        public static async Task SsOutput(string URL,string Output)
        {
            var index = Output.LastIndexOf(".")+1;
            var format = Output.Substring(index,3);

            if(format == "jpg")
            {
                string pathFiles = "D:/Users/bsi50129/.vscode/Task Command Line/#8-ScreenshotURL/";
                string[] newFile = Directory.GetFiles(pathFiles,"*.jpg");
                await screenshotOutput(newFile,Output,URL,format);
 
            }
            else if(format == "png")
            {
                string pathFiles = "D:/Users/bsi50129/.vscode/Task Command Line/#8-ScreenshotURL/";
                string[] newFile = Directory.GetFiles(pathFiles,"*.png");
                await screenshotOutput(newFile,Output,URL,format);
            }
            else if(format == "pdf")
            {
                string pathFiles = "D:/Users/bsi50129/.vscode/Task Command Line/#8-ScreenshotURL/";
                string[] newFile = Directory.GetFiles(pathFiles,"*.pdf");
                await screenshotOutput(newFile,Output,URL,format);
            }
        }

        public static async Task screenshotOutput(string[] newFile, string Output,string URL,string Format)
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

            foreach(string fl in newFile)
            {
                if(File.Exists(fl))
                {
                    if (Format=="png" || Format=="jpg")
                    {
                        await page.ScreenshotAsync($"{Output}",ScreenShot);
                    }else{
                        await page.PdfAsync($"{Output}");
                    }
                }
            }
            
            if (Format=="png" || Format=="jpg")
            {
                await page.ScreenshotAsync($"{Output}",ScreenShot);
            }else{
                await page.PdfAsync($"{Output}");   
            }
            await page.CloseAsync();
        }

    }
}
