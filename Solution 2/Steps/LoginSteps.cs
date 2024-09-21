using OpenQA.Selenium;
using Solution_2.Models;
using Solution_2.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Solution_2.Steps;

[Binding]
public class LoginSteps
{
    private IWebDriver driver;
    private readonly LoginPage loginPage;
    private readonly HomePage homePage;
    private readonly NotesPage notePage;

    public LoginSteps()
    {
      driver = SeleniumHelper.InitializeDriver();
      loginPage = new LoginPage(driver);
      homePage = new HomePage(driver);
      notePage = new NotesPage(driver);
    }

    [Given(@"I am on the Evernote login page")]
    public void EverNoteLoginPage()
    {
        driver.Navigate().GoToUrl("https://www.evernote.com/Login.action");
    }

    [When(@"I log in with the following credentials:")]
    public void  WhenILogInWithValidCredentials(Table info)
    {
        var input = info.CreateInstance<LoginInput>(); 

        loginPage.EnterEmail(input.Email.Trim());
        loginPage.ClickContinueButton();
        loginPage.EnterPassword(input.Password.Trim());
        loginPage.ClickContinueButton();
    }

    [When(@"I create a new note with the title ""(.*)""")]
    public void WhenICreateANewNoteWithTheTitle(Table info)
    {
        var note = info.CreateInstance<NoteInput>();

        notePage.CreateNewNoteWithTitle(note);
    }

    [Then(@"I should see the error message ""(.*)""")]
    public void ThenIShouldSeeTheErrorMessage(string expectedErrorMessage)
    {
        string actualMessage = loginPage.GetErrorMessage();
        Assert.AreEqual(expectedErrorMessage, actualMessage);
    }

    [Then(@"I should be successfully logged in")]
    public void ThenIShouldBeSuccessfullyLoggedIn()
    {
        Assert.True(homePage.IsUserLoggedIn());
    }

    [Then(@"I should see the note on my homepage with:")]
    public void ThenIShouldSeeTheNoteTitledOnMyHomepage(Table info)
    {
        var note = info.CreateInstance<NoteInput>();

        Assert.True(homePage.IsNoteDisplayed(note.Note));
    }
}
