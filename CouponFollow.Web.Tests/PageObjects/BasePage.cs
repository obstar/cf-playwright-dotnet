using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace CouponFollow.Web.Tests.PageObjects;

public abstract class BasePage
{
    public abstract string PagePath { get; }

    public abstract IPage Page { get; set; }

    public abstract IBrowser Browser { get; }

    public IConfigurationRoot Configuration { get; } = new ConfigurationBuilder()
                                                       .AddJsonFile("appsettings.json")
                                                       .Build();

    public async Task NavigateAsync()
    {
        Page = await Browser.NewPageAsync();
        await Page.SetViewportSizeAsync(int.Parse(Configuration["browser:width"]),
                                        int.Parse(Configuration["browser:height"]));
        await Page.GotoAsync(PagePath);
    }
}