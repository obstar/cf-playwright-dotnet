using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageObjects;

[Binding]
public class MainPage : BasePage
{
    private readonly ILocator _divStaffPicks;
    private readonly ILocator _divTodaysTopCoupons;
    private readonly ILocator _divTodaysTrendingCoupons;
    private readonly ILocator _divTopDealsSwiper;

    // Texts
    private const string Title = "Coupon Codes in Real-Time - CouponFollow";

    public override string PagePath => Configuration["mainUrl"];
    public sealed override IPage Page { get; set; }

    public MainPage(IPage page)
    {
        Page = page;
        _divStaffPicks = Page.Locator("div.staff-picks [data-domain]");
        _divTodaysTopCoupons = Page.Locator(".swiper-wrapper div:not(.swiper-slide-duplicate)");
        _divTodaysTrendingCoupons = Page.Locator(".trending-deals.cont > article");
        _divTopDealsSwiper = Page.Locator(".big-cont.top-deals-swiper");
    }


    public async Task AssertPageLoaded()
    {
        Assert.That(Page.Url, Is.EqualTo(PagePath));
        Assert.That(await Page.TitleAsync(), Is.EqualTo(Title));
        Assert.That(await _divTopDealsSwiper.IsVisibleAsync(), Is.True);
        Assert.That(await _divStaffPicks.First.IsVisibleAsync(), Is.True);
        Assert.That(await _divTodaysTrendingCoupons.Last.IsVisibleAsync(), Is.True);
    }

    public async Task AssertTodaysTrendingCoupons(int trendingCoupons) =>
        Assert.That(await _divTodaysTrendingCoupons.CountAsync(),
                    Is.GreaterThanOrEqualTo(trendingCoupons));


    public async Task AssertTodaysTopCoupons(int minCoupons, int maxCoupons) =>
        Assert.That(await _divTodaysTopCoupons.CountAsync(),
                    Is.InRange(minCoupons, maxCoupons));
}