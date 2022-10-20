using CouponFollow.Web.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageSteps;

[Binding]
public class MainPageSteps
{
    private readonly MainPage _mainPage;

    public MainPageSteps(MainPage mainPage) => _mainPage = mainPage;


    [Given(@"I navigate to Main page")]
    public async Task GivenINavigateToMainPage() => await _mainPage.NavigateAsync();

    
    [Then(@"user can see Main page")]
    public async Task ThenUserCanSeeMainPage() => await _mainPage.AssertPageLoaded();
    
    
    [Then(@"user can see at least '(.*)' Today's Trending Coupons")]
    public async Task ThenUserCanSeeAtLeastTodaysTrendingCoupons(int trendingCoupons) =>
        await _mainPage.AssertTodaysTrendingCoupons(trendingCoupons);

    
    [Then(@"user can see '(.*)' out of possible '(.*)' of Today's Top Coupons")]
    public async Task ThenUserCanSeeOutOfPossibleOfTodaysTopCoupons(int minCoupons, int maxCoupons) =>
        await _mainPage.AssertTodaysTopCoupons(minCoupons, maxCoupons);
}