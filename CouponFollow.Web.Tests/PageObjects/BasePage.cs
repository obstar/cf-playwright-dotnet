using Microsoft.Playwright;

namespace CouponFollow.Web.Tests.PageObjects;

public abstract class BasePage
{
    public abstract string PagePath { get; }

    public abstract IPage Page { get; set; }

    public abstract IBrowser Browser { get; }

    public async Task NavigateAsync()
    {
        Page = await Browser.NewPageAsync();
        await Page.SetViewportSizeAsync(1170, 2532);
        await Page.GotoAsync(PagePath);
    }
}