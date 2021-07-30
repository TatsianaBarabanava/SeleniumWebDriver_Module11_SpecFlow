@LoggedUser
Feature: SpecFlowReceiveFolderTest
	In order to check that the send to yourself email appears in "Inbox" folder
	As a Yandex Mailbox user
	I want to be able to check the existance of received email in "Inbox" folder

Background:
Given I create an Email for Yandex

@smoke
Scenario: The received email should exist in Inbox folder
	When I escape the created email
	And I go to Draft folder
	And I click on recepientField
	And I click Send button
	And I escape the notification message
	And I go to Inbox folder
	And I refresh the Page
	Then The send email should appear in Inbox folder