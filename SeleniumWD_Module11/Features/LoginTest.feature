@NotLoggedUser
Feature: SpecFlowLoginTest
	In order to use Yandex mailbox
	As a Yandex Mailbox user
	I want to be able to Login to Yandex mailbox

@Smoke
Scenario Outline: The logged in user should be on YandexHomePage
    When I click on LoginButton
	And I login with '<login>' and '<password>' credentials 
	Then I get the compose link text
	And The compose link text presents on the Page

	Examples:
	| login     | password    | 
	| Snieczka  | 2020327abcd | 
	| Snieczka2 | 2020327abc  | 