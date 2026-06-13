using Microsoft.Playwright;
using FluentAssertions;
using System.Threading.Tasks;

namespace PlaywrightSpecFlowPOM.Pages
{
    public class DuckDuckGoHomePage
    {
        private readonly IPage _user;

        public DuckDuckGoHomePage(Hooks.Hooks hooks)
        {
            _user = hooks.User;
        }

        // Playwright Locators
        private ILocator SearchInput => _user.GetByPlaceholder("Search privately");
        private ILocator SearchButton => _user.Locator("button[type='submit'][class*='searchButton']");

        public async Task NavigateAsync()
        {
            await _user.GotoAsync("https://duckduckgo.com/");
        }

        public async Task SearchForTermAsync(string searchTerm)
        {
            await SearchInput.WaitForAsync();
            await SearchInput.FillAsync(searchTerm);
            await SearchButton.ClickAsync();
        }
    }
}