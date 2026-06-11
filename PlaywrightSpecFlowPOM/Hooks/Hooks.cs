using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlowPOM.Hooks
{
    [Binding]
    public class Hooks
    {
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
            if (User != null) await User.CloseAsync();
            if (Context != null) await Context.DisposeAsync();
            if (Browser != null) await Browser.DisposeAsync();
            PlaywrightInstance?.Dispose();
        }
    }
}