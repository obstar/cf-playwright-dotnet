using System.Diagnostics;
using Microsoft.Playwright;
using NUnit.Framework;
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

        var elements =  Page.Locator(".swiper-wrapper > div > a[data-domain]");
        string? text = elements.Nth(0).First.GetAttributeAsync("ariaLabel").Result;
        Console.WriteLine(text);
    }
}