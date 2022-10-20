using Microsoft.Playwright;
using NUnit.Framework;

namespace CouponFollow.Web.Tests.PageObjects;

public class NavGroupObj : BasePage
{
    private readonly ILocator _h1MainTitle;
    private readonly ILocator _inpSearch;
    private readonly ILocator _lnkSuggestedItem;
    private readonly ILocator _pStoreDomain;
    
    private string? _storeDomain;
        
    public override string PagePath => Configuration["mainUrl"];
    public sealed override IPage Page { get; set; }

    public NavGroupObj(IPage page)
    {
        Page = page;
        _h1MainTitle= Page.Locator("h1.mainTitle");
        _inpSearch = Page.Locator("input.search-field");
        _lnkSuggestedItem = Page.Locator("a.suggestion-item");
        _pStoreDomain= Page.Locator("p.domain");
    }


    public async Task TypeInIntoSearchField(string searchedText)
    {
        await _inpSearch.TypeAsync(searchedText);
        _storeDomain = await _pStoreDomain.InnerTextAsync();
    }

    public async Task ClickSuggestedItem() => await _lnkSuggestedItem.ClickAsync();

    public async Task AssertThatStorePageLoaded(string storeName)
    {
        await _h1MainTitle.WaitForAsync();
        Assert.That(await _h1MainTitle.IsVisibleAsync(), Is.True);
        Assert.That(Page.Url, Is.EqualTo($"{PagePath}site/{_storeDomain}"));
        StringAssert.Contains(storeName,await Page.TitleAsync());
        StringAssert.Contains(storeName,await _h1MainTitle.InnerTextAsync());
    }
}