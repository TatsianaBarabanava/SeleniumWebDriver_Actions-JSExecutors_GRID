using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendEmail : BaseTest
    {
       
        [Test]
        public void SendEmail()
        {
           //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmail, emailSubject);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            int actualNumberOfDrafts = draftPage.CountEmails(gmailEmail);
            draftPage.ClickOnRecepientField(gmailEmail);
            draftPage.ClickOnSendButtonWithActions();
            Browser.PressEscape();
            Browser.JSRefreshPage();

            //Assert
            bool expectedNumberOfDrafts = draftPage.CountEmails(gmailEmail).Equals(actualNumberOfDrafts - 1);
            Assert.IsTrue(expectedNumberOfDrafts, "The Number Of Letters In Mail Box is different from Expected Value");
        }
    }
}