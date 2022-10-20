using CouponFollow.Web.Tests.PageObjects;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageSteps;

[Binding]
public class MainPageSteps
{
    private readonly MainPage _mainPage;
    private ILocator? _storeElement;

    public MainPageSteps(MainPage mainPage) => _mainPage = mainPage;


    [Given(@"I navigate to Main page")]
    public async Task GivenINavigateToMainPage() => await _mainPage.NavigateAsync();

    [Given(@"there is a (.*)")]
    public async Task GivenThereIsAStore(string store) => _storeElement = await _mainPage.ReturnStoreElement(store);

    [Then(@"user can see Main page")]
    public async Task ThenUserCanSeeMainPage() => await _mainPage.AssertPageLoaded();


    [Then(@"user can see at least '(.*)' Today's Trending Coupons")]
    public async Task ThenUserCanSeeAtLeastTodaysTrendingCoupons(int trendingCoupons) =>
        await _mainPage.AssertTodaysTrendingCoupons(trendingCoupons);


    [Then(@"user can see '(.*)' out of possible '(.*)' of Today's Top Coupons")]
    public async Task ThenUserCanSeeOutOfPossibleOfTodaysTopCoupons(int minCoupons, int maxCoupons) =>
        await _mainPage.AssertTodaysTopCoupons(minCoupons, maxCoupons);

    [Then(@"a proper (.*) is presented to the user")]
    public async Task ThenAProperIsPresentedToTheUser(string discount) =>
        await _mainPage.AssertDiscountText(_storeElement, discount);
}