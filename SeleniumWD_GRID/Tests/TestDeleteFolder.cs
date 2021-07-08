using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDeleteFolder : BaseTest
    {
        [Test]
        public void DeleteFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmail, emailSubject);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            draftPage.SelectEmailByNumber(0, gmailEmail);
            draftPage.deleteButton.Click();
            var deletePage = draftPage.ClickOnDeleteFolder();

            //Assert
            var actualSender = deletePage.GetTextFromRecepientField(yandexEmail);
            var actualSubject = deletePage.GetTextFromMailTopicField();
            var actualContent = deletePage.GetTextFromContentField();
            Assert.AreEqual(sender, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(emailSubject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(deletePage.GetTextFromContentField(), actualContent,  "Content field has an invalid value");
        }
    }
}