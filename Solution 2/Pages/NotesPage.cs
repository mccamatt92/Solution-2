using OpenQA.Selenium;
using Solution_2.Models;

namespace Solution_2.Pages;

public class NotesPage
{
    private IWebDriver driver;

    public NotesPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement NewNoteButton => driver.FindElement(By.ClassName("DJloq7TCQ1fb8Lz9l9fD"));
    private IWebElement NoteTitleField => driver.FindElement(By.ClassName("dSbRl"));

    public void CreateNewNoteWithTitle(NoteInput noteInput)
    {
        NewNoteButton.Click();
        NoteTitleField.SendKeys(noteInput.Note);
    }
}