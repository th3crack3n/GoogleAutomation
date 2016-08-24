using Coypu;
using System;

namespace GoogleAutomation.Object_Models
{
    class Google
    {
        private BrowserSession browser;

        public enum Clickables
        {
            GoogleSearch,
            ImFeelingLucky,
            Doodle
        }

        public Google(BrowserSession browser)
        {
            this.browser = browser;
        }

        public void click(Clickables link)
        {
            var xpath = "";

            switch (link)
            {
                case Clickables.Doodle:
                    xpath = "//div[@id='hplogo']/a/img";
                    break;
                case Clickables.GoogleSearch:
                    xpath = "//input[@value='Google Search']";
                    break;
                case Clickables.ImFeelingLucky:
                    xpath = "//div[@id='sbtc']/div[2]/div[2]/div/div/div/div/span[2]/span/input";
                    break;
                default:
                    throw new Exception();
            }

            browser.FindXPath(xpath, Options.First).Click();
        }

        public bool hasLeftHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/");
        }

        public void enterSearch(string text)
        {
            browser.FillIn("q").With(text);
        }
    }
}