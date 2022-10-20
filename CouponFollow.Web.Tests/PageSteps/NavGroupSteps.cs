using CouponFollow.Web.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace CouponFollow.Web.Tests.PageSteps;

[Binding]
public class NavGroupSteps
{
    private readonly NavGroupObj _navGroupObj;

    public NavGroupSteps(NavGroupObj navGroupObj) => _navGroupObj = navGroupObj;


    [Given(@"I navigate to Nav group")]
    public async Task GivenINavigateToNavGroup() => await _navGroupObj.NavigateAsync();


    [Given(@"I type in '(.*)' into Search field in Navigation group")]
    public async Task GivenITypeInIntoSearchFieldInNavigationGroup(string searchedText) =>
        await _navGroupObj.TypeInIntoSearchField(searchedText);


    [When(@"I click suggested item in Navigation group")]
    public async Task WhenIClickSuggestedItemInNavigationGroup() =>
        await _navGroupObj.ClickSuggestedItem();

    [Then(@"user can see '(.*)' store page")]
    public async Task ThenUserCanSeeStorePage(string storeName) =>
        await _navGroupObj.AssertThatStorePageLoaded(storeName);
}