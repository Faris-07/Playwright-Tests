using Microsoft.Playwright;
using FluentAssertions;
using System.Threading.Tasks;

namespace PlaywrightSpecFlowPOM.Pages
{
    public class SearchResultsPage
    {
        private readonly IPage _user;

        public SearchResultsPage(Hooks.Hooks hooks)
        {
            _user = hooks.User;
        }

        // Private Locator: Grabs the inner text of the very first search result card heading
        private ILocator FirstResultHeading => _user.Locator("article").First.Locator("h2");

        // Public Assertion: Validates text state directly using FluentAssertions
        public async Task AssertFirstResultContainsText(string expectedText)
        {
            await FirstResultHeading.WaitForAsync();
            string actualText = await FirstResultHeading.InnerTextAsync();
            
            // C# FluentAssertion assertion check
            actualText.Should().ContainEquivalentOf(expectedText);
        }
    }
}