using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace CouponFollow.Web.Tests.PageObjects;

public abstract class BasePage
{
    public abstract string PagePath { get; }

    public abstract IPage Page { get; set; }

    public IConfigurationRoot Configuration { get; } = new ConfigurationBuilder()
                                                       .AddJsonFile("appsettings.json")
                                                       .Build();

    public async Task NavigateAsync()
    {
        await Page.GotoAsync(PagePath);
    }
}