using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendFolder : BaseTest
    {
       
        [Test]
        public void SendFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmail, emailSubject);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            draftPage.ClickOnRecepientField(gmailEmail);
            draftPage.ClickOnSendButtonWithActions();
            Browser.PressEscape();
            var sendPage = draftPage.ClickOnSendFolder();

            //Assert
            var actualSender = sendPage.GetTextFromRecepientField(gmailEmail);
            var actualSubject = sendPage.GetTextFromMailTopicField();
            var actualContent = sendPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmail, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(emailSubject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(sendPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}