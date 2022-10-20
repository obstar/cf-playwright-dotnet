# Recruitment task
	Your task is to automate the following tests for the CouponFollow portal. All tasks below should be done in C# language and end-to-end, unit testing framework of your own choice.
What you should know is that we are using Playwright. Most of our users (about 70% of users) use mobile devices and their browser of choice is Safari or Chrome.
All tasks are meant to run against our main page - https://couponfollow.com/
1. Validate that 3 out of 3 or 6 or 9 total Top Deal coupons are displayed.
2. Validate that at least 30 Today’s Trending Coupons are displayed on the main page.
3. Validate that Staff Picks contain unique stores with proper discounts for monetary, percentage or text values.
4. Search for an existing CouponFollow store, click on it in order to open a store page. Then validate that the page is properly displayed.

## Improvements
* replace Console.WriteLine with some proper logger
* I could handle better browser session, currently is through appsettings.json
* I didn't go with that path of playwright.devices just concentrated on desktop browsers
* scenario: MainPage - Staff Picks contain unique stores with proper discounts for monetary from MainPage.feature is brittle those stores change a lot, so there should be done refactor to assert that displayed stores are unique for each other and some regex to validate promotion/discount messages 
* I didn't added ExtentReports or Allure for reporting but would be nice to have it

## Running tests
`dotnet build`
`dotnet test`