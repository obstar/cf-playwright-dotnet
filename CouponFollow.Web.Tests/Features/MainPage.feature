Feature: MainPage

	Background: 
		Given I navigate to Main page
		
	Scenario: MainPage - Display correctly
		Then user can see Main page
		
	Scenario: MainPage - Top Deal coupons are displayed
		Then user can see '3' out of possible '9' of Today's Top Coupons
		
	Scenario: MainPage - At least 30 Today’s Trending Coupons are displayed
		Then user can see at least '30' Today's Trending Coupons
		
	Scenario Outline: MainPage - Staff Picks contain unique stores with proper discounts for monetary
		Given there is a <store>
		Then a proper <discount> is presented to the user

		Examples:
		  | store        | discount     |
		  | Gamestop     | Save 20% Off |
		  | Boost Mobile | Only $5!     |
#		  | Karen Miller | Save 20% Off |
#		  | Cult Beauty  | Save 15% Off |
#		  | Shopbop      | Save 15% Off |
#		  | ShopDisney   | FreeShipping |
