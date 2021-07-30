@LoggedUser
Feature: SpecFlowDraftFolderTest
	In order to check that created email appears in "Draft" folder
	As a Yandex Mailbox user
	I want to be able to check the existance of created email in "Draft" folder

Background:
Given I create an Email

@smoke
Scenario: The created email should exist in Draft folder
	When I escape the created email
	And I go to Draft folder
	Then The created email should appear in Draft folder