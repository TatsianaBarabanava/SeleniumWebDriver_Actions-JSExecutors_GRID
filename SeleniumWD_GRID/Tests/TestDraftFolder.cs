using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDraftFolder : BaseTest
    {

         [Test]
        public void DraftContent()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmail, emailSubject);
            Browser.PressEscape();
            mailPage.resendLink.WaitForIsVisible();
            var draftPage = mailPage.ClickOnDraftLink();

            //Assert
            var actualSender = draftPage.GetTextFromRecepientField(gmailEmail);
            var actualSubject = draftPage.GetTextFromMailTopicField();
            var actualContent = draftPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmail,actualSender, "Sender field has an invalid value");
            Assert.AreEqual(emailSubject,actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(draftPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}