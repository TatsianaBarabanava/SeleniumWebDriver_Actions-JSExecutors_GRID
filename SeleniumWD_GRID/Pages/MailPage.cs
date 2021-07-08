using System;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumWebDriver
{
    public class MailPage : BaseMailPage
    {
        public static readonly String url = "https://mail.yandex.by/u2709/?uid=1437990165#inbox";
        private static readonly By newMail = By.XPath("//span[text()='Новое письмо']");
        private static readonly BaseElement recepientField = new BaseElement(By.XPath("//div[@class='composeYabbles']"));
        private static readonly BaseElement topicField = new BaseElement(By.XPath("//input[contains(@class,'composeTextField')]"));
        private static readonly BaseElement mailContentField = new BaseElement(By.XPath("//div[@role='textbox']"));
        public static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public String randomText = new string(Enumerable.Range(1, 10).Select(_ => chars[random.Next(chars.Length)]).ToArray());

        public MailPage() : base(newMail, "New Mail") 
        { 
        }

        public void TypeRecepient(string Recepient)
        {
            recepientField.SendKeys(Recepient);
        }

        public void ClickOnTypeTopicField()
        {
            topicField.Click();
        }

        public void TypeTopic(string Topic)
        {
            topicField.SendKeys(Topic);
        }

        public void ClickOnMailContentField()
        {
            mailContentField.Click();
        }

        public void TypeMailContent(string Content)
        {
            mailContentField.SendKeys(Content);
        }

        public void WaitForRecepientFieldIsVisible()
        {
            recepientField.WaitForIsVisible();
        }

        public void ComposeEmail(string Recepient, string Topic, string Content)
        {
            TypeRecepient(Recepient);
            ClickOnTypeTopicField();
            TypeTopic(Topic);
            ClickOnMailContentField();
            TypeMailContent(Content);
        }

        public void ComposeEmailWithRandomContent(string Recepient, string Topic)
        {
            WaitForRecepientFieldIsVisible();
            ComposeEmail(Recepient, Topic, randomText);
        }

        public string GetRandomContent()
        {
            return mailContentField.GetText();
        }
    }
}