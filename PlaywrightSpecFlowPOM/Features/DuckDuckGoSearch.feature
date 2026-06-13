Feature: DuckDuckGo Search

Scenario: Search for Playwright on DuckDuckGo
	Given the user is on the DuckDuckGo homepage
	When the user searches for 'Playwright'
	Then the first search result title contains 'Playwright'

Scenario Outline: Search for multiple tech terms on DuckDuckGo
	Given the user is on the DuckDuckGo homepage
	When the user searches for '<SearchTerm>'
	Then the first search result title contains '<ExpectedResult>'

	Examples: 
	| SearchTerm | ExpectedResult |
	| SpecFlow   | SpecFlow       |
	| Selenium   | Selenium       |
	| C# .NET    | C#             |