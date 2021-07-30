@LoggedUser
Feature: SpecFlowSendFolderTest
	In order to check that the send email is being saved in "Send" folder
	As a Yandex Mailbox user
	I want to be able to check that the email exists in "Send" folder

Background:
Given I create an Email

@smoke
Scenario: The sent email should appear in Send folder
	When I escape the created email
	And I go to Draft folder
	And I click on recepientField for Yandex
	And I click Send button
	And I escape the notification message
	And I go to Send folder
	Then The send email should appear in Send folder