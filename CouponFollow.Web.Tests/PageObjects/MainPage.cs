using System.Diagnostics;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageObjects;

[Binding]
public class MainPage : BasePage
{
    public override string PagePath => "https://couponfollow.com";
    public sealed override IPage Page { get; set; } = null!;


    public MainPage(IBrowser browser)
    {
        Browser = browser;
    }

    public override IBrowser Browser { get; }


    public async Task AssertPageLoaded()
    {
        Assert.That(await Page.TitleAsync(), Is.EqualTo(MainPageConst.Text.Title));
        Assert.That(await Page.Locator(MainPageConst.Selectors.TopDealsSwiper).IsVisibleAsync(), Is.True);
        Assert.That(await Page.Locator(MainPageConst.Selectors.StaffPicks).First.IsVisibleAsync(), Is.True);
        Assert.That(await Page.Locator(MainPageConst.Selectors.TodaysTrendingCoupons).Last.IsVisibleAsync(), Is.True);
    }

    public async Task AssertTodaysTrendingCoupons(int trendingCoupons)
    {
        Assert.That(await Page.Locator(MainPageConst.Selectors.TodaysTrendingCoupons).CountAsync(),
                    Is.GreaterThanOrEqualTo(trendingCoupons));
    }

    public async Task AssertTodaysTopCoupons(int minCoupons, int maxCoupons)
    {
        Assert.That(await Page.Locator(MainPageConst.Selectors.TodaysTopCoupons).CountAsync(),
                    Is.InRange(minCoupons, maxCoupons));
    }
}