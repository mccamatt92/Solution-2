Feature: Evernote Login and Note Actions

As a user i want to login and create a note

@Incorrect
Scenario: Unsuccessful login with incorrect email
	Given I am on the Evernote login page
	When I log in with the following credentials:
	|Email           |Password      | 
	| random@mail.com|Wrong Password|
	Then I should see the error message "Check your credentials. We couldn’t match your email, username, or password."

@Correct
Scenario: Successful login with correct email
    Given I am on the Evernote login page
    When I log in with the following credentials:
	|Email                        |Password          | 
	| matthias.mccarthy@gmail.com |Fiestast2024      |
    Then I should be successfully logged in

Scenario: Create a note, logout, and verify the note is available
    Given I am on the Evernote login page
	When I log in with the following credentials:
	|Email           |Password      | 
	| random@mail.com|Wrong Password|
	Then I should be successfully logged in
    When I create a new note with the title "Test Note"
    Then I should see the note on my homepage with:
	|Note     |
	|Test Note|
