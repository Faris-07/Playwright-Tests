using Microsoft.Playwright;
using TechTalk.SpecFlow;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PlaywrightSpecFlowPOM.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IPlaywright PlaywrightInstance { get; private set; }
        public IBrowser Browser { get; private set; }
        public IBrowserContext Context { get; private set; }
        public IPage User { get; private set; }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
            Browser = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, 
                SlowMo = 400
            });
            Context = await Browser.NewContextAsync();
            User = await Context.NewPageAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                // Handle test error
                Directory.CreateDirectory("TestingScreenshots");

                string Title = string.Join("_", _scenarioContext.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars()));
                string screenshotPath = $"TestingScreenshots/{Title}.png";

                await User.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath, FullPage = true });

                Console.WriteLine($"Screenshot saved to: {screenshotPath}");
                Console.WriteLine($"Error: {_scenarioContext.TestError.Message}");
            }
            
            if (User != null) await User.CloseAsync();
            if (Context != null) await Context.DisposeAsync();
            if (Browser != null) await Browser.DisposeAsync();
            PlaywrightInstance?.Dispose();
        }
    }
}