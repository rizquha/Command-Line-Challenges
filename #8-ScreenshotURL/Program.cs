using System;
using PuppeteerSharp;
using System.Threading.Tasks;


namespace ScreenshotURL
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless=false
            });


            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("https://google.com");
                var input = await page.WaitForSelectorAsync("input[name='q']");
                await input.TypeAsync("Hello World");
                await input.PressAsync("Enter");
                await page.WaitForTimeoutAsync(5000);
                await page.ScreenshotAsync("google.png");

            } 
        }
    }
}
