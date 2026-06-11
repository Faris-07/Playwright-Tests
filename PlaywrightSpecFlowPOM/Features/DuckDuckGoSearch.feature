Feature: DuckDuckGo Search

Scenario: Search for Playwright on DuckDuckGo
	Given the user is on the DuckDuckGo homepage
	When the user searches for 'Playwright'
	Then the first search result title contains 'Playwright'