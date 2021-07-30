@LoggedUser
Feature: SpecFlowSendEmailTest
	In order to check that the send email disappears from "Draft" folder
	As a Yandex Mailbox user
	I want to be able to check that the number of emails in "Draft" folder reduces by 1 after email being sent

Background:
Given I create an Email

@smoke
Scenario: The sent email should disappear from Draft folder
	When I escape the created email
	And I go to Draft folder
	And I count the number of existing emails in Draft folder
	And I click on recepientField for Yandex
	And I click Send button
	And I escape the notification message
	And I refresh the Page
	And I count the number of emails in Draft folder one more time
	Then The send email should disappear from Draft folder