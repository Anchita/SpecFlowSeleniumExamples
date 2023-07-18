Feature: Calculator

Scenario: Numbers 50 and 20 should add up to 70
	Given the first number is 50
	And the second number is 20
	When the two numbers are added
	Then the result should be 70
