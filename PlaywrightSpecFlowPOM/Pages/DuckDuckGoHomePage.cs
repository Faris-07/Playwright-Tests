using Microsoft.Playwright;
using FluentAssertions;

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
        private ILocator SearchInput => _user.GetByPlaceholder("Search without being tracked");
        private ILocator SearchButton => _user.Locator("button[type='submit']");

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