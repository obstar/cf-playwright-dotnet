using CouponFollow.Web.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageSteps;

[Binding]
[Scope(Feature = "MainPage")]
public class MainPageSteps
{
    private readonly MainPage _mainPage;

    public MainPageSteps(MainPage mainPage)
    {
        _mainPage = mainPage;
    }
    
    [Given(@"I navigate to Main page")]
    public async Task GivenINavigateToMainPage()
    {
        await _mainPage.NavigateAsync();
    }

    [Then(@"user can see Main page")]
    public async Task ThenUserCanSeeMainPage()
    {
        await _mainPage.AssertPageLoaded();
    }

    [Then(@"user can see at least '(.*)' Today's Trending Coupons")]
    public void ThenUserCanSeeAtLeastTodaysTrendingCoupons(int trendingCoupons)
    {
        ScenarioContext.StepIsPending();
    }
}