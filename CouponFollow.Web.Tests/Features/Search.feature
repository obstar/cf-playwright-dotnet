Feature: Search

    Background:
        Given I navigate to Nav group

    Scenario: Search - For an existing Gamestop store
        Given I type in 'Gamestop' into Search field in Navigation group
        When I click suggested item in Navigation group
        Then user can see 'Gamestop' store page