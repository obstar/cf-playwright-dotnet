using BoDi;
using CouponFollow.Web.Tests.PageObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.Configuration;

[Binding]
public class BrowserBindings
{
    [BeforeScenario]
    public async Task BeforeScenario(IObjectContainer specFlowContainer,
                                     ScenarioContext scenarioContext)
    {
        Console.WriteLine($"-> [BeforeScenario] {scenarioContext.ScenarioInfo.Title}");
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                      .Build();
        var playwright = await Playwright.CreateAsync();
        var browserType = playwright[configuration["browser:name"]];
        var browser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions
                                                    {
                                                        Headless = Convert.ToBoolean(configuration["headless"]),
                                                        SlowMo = Convert.ToInt16(configuration["slowMo"])
                                                    });

        var mainPage = new MainPage(browser);
        specFlowContainer.RegisterInstanceAs(playwright);
        specFlowContainer.RegisterInstanceAs(browser);
        specFlowContainer.RegisterInstanceAs(mainPage);
    }

    [AfterScenario(Order = 10)]
    public async Task AfterEachScenario(IObjectContainer specFlowContainer,
                                        ScenarioContext scenarioContext)
    {
        var nUnitStatus = TestContext.CurrentContext.Result.Outcome.Status;
        var failed = nUnitStatus is not TestStatus.Passed and not TestStatus.Skipped;
        Console.WriteLine($"-> [AfterScenario] {scenarioContext.ScenarioInfo.Title}");

        var browser = specFlowContainer.Resolve<IBrowser>();
        await browser.CloseAsync();
        var playwright = specFlowContainer.Resolve<IPlaywright>();
        playwright.Dispose();

        try
        {
            if (!failed) return;
            var error = scenarioContext.TestError;
            Console.WriteLine("-> [AfterScenario] test has failed!");
            Console.WriteLine($"-> [AfterScenario] An error occurred: {(error != null ? error.Message : "unknown")}");
            Console.WriteLine(
                              $"-> [AfterScenario] It was of type: {(error != null ? error.GetType().Name : "unknown")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("-> Could not mark session as failed");
            Console.WriteLine(ex.Message);
        }
    }
}