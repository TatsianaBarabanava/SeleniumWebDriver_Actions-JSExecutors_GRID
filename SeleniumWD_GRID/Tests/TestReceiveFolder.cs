using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestReceiveFolder : BaseTest
    {
        [Test]
        public void ReceiveFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(yandexEmail, emailSubject);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            draftPage.ClickOnRecepientField(yandexEmail); 
            draftPage.ClickOnSendButtonWithActions();
            Browser.PressEscape();
            var receivePage = draftPage.ClickOnInboxFolder();
            Browser.RefreshPage();

            //Assert
            var actualSender = receivePage.GetTextFromRecepientField(yandexEmail); 
            var actualSubject = receivePage.GetTextFromMailTopicField();
            var actualContent = receivePage.GetTextFromContentField();
            Assert.AreEqual(sender, actualSender, "Sender field has an invalid value");
            Assert.IsTrue(actualSubject.Contains(emailSubject), "Email Subject field has an invalid value");
            Assert.AreEqual(receivePage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}