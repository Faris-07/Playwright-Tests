using PlaywrightSpecFlowPOM.Pages;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlowPOM.Steps
{
    [Binding] // Tells SpecFlow this file maps Gherkin to C# code blocks
    public class SearchSteps
    {
        private readonly DuckDuckGoHomePage _homePage;
        private readonly SearchResultsPage _searchResultsPage;

        // Constructor handles Dependency Injection automatically
        public SearchSteps(DuckDuckGoHomePage homePage, SearchResultsPage searchResultsPage)
        {
            _homePage = homePage;
            _searchResultsPage = searchResultsPage;
        }

        [Given(@"the user is on the DuckDuckGo homepage")]
        public async Task GivenTheUserIsOnTheDuckDuckGoHomepage()
        {
            await _homePage.NavigateAsync();
        }

        [When(@"the user searches for '(.*)'")]
        public async Task WhenTheUserSearchesFor(string searchTerm)
        {
            await _homePage.SearchForTermAsync(searchTerm);
        }

        [Then(@"the first search result title contains '(.*)'")]
        public async Task ThenTheFirstSearchResultTitleContains(string expectedText)
        {
            await _searchResultsPage.AssertFirstResultContainsText(expectedText);
        }
    }
}