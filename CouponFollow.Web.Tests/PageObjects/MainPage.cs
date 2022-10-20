using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageObjects;

[Binding]
public class MainPage : BasePage
{
    // Selectors
    private const string StaffPicks = "div.staff-picks [data-domain]";
    private const string TodaysTopCoupons = ".swiper-wrapper div:not(.swiper-slide-duplicate)";
    private const string TodaysTrendingCoupons = ".trending-deals.cont > article";
    private const string TopDealsSwiper = ".big-cont.top-deals-swiper";

    // Texts
    private const string Title = "Coupon Codes in Real-Time - CouponFollow";

    public override string PagePath => Configuration["mainUrl"];
    public override IBrowser Browser { get; }
    public sealed override IPage Page { get; set; } = null!;

    public MainPage(IBrowser browser)
    {
        Browser = browser;
    }


    public async Task AssertPageLoaded()
    {
        Assert.That(Page.Url, Is.EqualTo(PagePath));
        Assert.That(await Page.TitleAsync(), Is.EqualTo(Title));
        Assert.That(await Page.Locator(TopDealsSwiper).IsVisibleAsync(), Is.True);
        Assert.That(await Page.Locator(StaffPicks).First.IsVisibleAsync(), Is.True);
        Assert.That(await Page.Locator(TodaysTrendingCoupons).Last.IsVisibleAsync(), Is.True);
    }

    public async Task AssertTodaysTrendingCoupons(int trendingCoupons)
    {
        Assert.That(await Page.Locator(TodaysTrendingCoupons).CountAsync(),
                    Is.GreaterThanOrEqualTo(trendingCoupons));
    }

    public async Task AssertTodaysTopCoupons(int minCoupons, int maxCoupons)
    {
        Assert.That(await Page.Locator(TodaysTopCoupons).CountAsync(),
                    Is.InRange(minCoupons, maxCoupons));
    }
}