@LoggedUser
Feature: SpecFlowDeleteFolderTest
	In order to check that deleted from "Draft" folder mail appears in "Delete" folder
	As a Yandex Mailbox user
	I want to be able to check the existance of deleted email in "Delete" folder

Background:
Given I create an Email

@smoke
Scenario: The deleted email should exist in Delete folder
	When I escape the created email
	And I go to Draft folder
	And I select created email
	And I delete the email from Draft folder
	And I go to Delete folder
	Then The deleted email should appear in Delete folder