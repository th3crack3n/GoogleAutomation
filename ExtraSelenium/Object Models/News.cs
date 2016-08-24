using Coypu;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace GoogleAutomation.Object_Models
{
    class News
    {
        private BrowserSession browser;

        public enum Categories
        {
            Local,
            TopStories,     // moved to second position, button not available when selected on page load
            World,
            US,
            Business,
            Technology,
            Entertainment,
            Sports,
            Science,
            Health,
            Spotlight,
            Elections     // probably temporary
        }

        public enum Fields
        {
            SearchBar
        }

        public News(BrowserSession browser)
        {
            this.browser = browser;
        }

        public void click(Categories clickObj)
        {
            browser.FindXPath(getClickRef(clickObj), Options.First).Click();
        }

        private string getClickRef(Categories clickObj)
        {
            switch (clickObj)
            {
                case Categories.TopStories:
                    return "//a[contains(text(),'Top Stories')]";
                case Categories.Local:
                    return "//div[3]/div/div/div/div[2]/div/ul/li[2]/a";
                case Categories.World:
                    return "//a[contains(text(),'World')]";
                case Categories.US:
                    return "//a[contains(text(),'U.S.')]";
                case Categories.Business:
                    return "//a[contains(text(),'Business')]";
                case Categories.Technology:
                    return "//a[contains(text(),'Technology')]";
                case Categories.Entertainment:
                    return "//a[contains(text(),'Entertainment')]";
                case Categories.Sports:
                    return "//a[contains(text(),'Sports')]";
                case Categories.Science:
                    return "//a[contains(text(),'Science')]";
                case Categories.Health:
                    return "//a[contains(text(),'Health')]";
                case Categories.Spotlight:
                    return "//a[contains(text(),'Spotlight')]";
                case Categories.Elections:
                    return "//a[contains(text(),'Elections')]";
                default:
                    return null;
            }
        }

        public bool hasLeftHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/");
        }

        public void clickFirstArticle()
        {
            browser.FindXPath("//h2/a/span", Options.First).Click();
            Thread.Sleep(500);
            closeOpenedTab();
        }

        public void closeOpenedTab()
        {
            ChromeDriver driver = (ChromeDriver) browser.Native;
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);      // newly opened tab
            driver.Close();
            driver.SwitchTo().Window(tabs[0]);      // original tab
        }

        public void enterText(Fields fieldObj, string text)
        {
            browser.FillIn(getFieldRef(fieldObj)).With(text);
            browser.ClickButton("gbqfb");
        }

        private string getFieldRef(Fields fieldObj)
        {
            switch (fieldObj)
            {
                case Fields.SearchBar:
                    return "gbqfq";
                default:
                    return null;
            }
        }
    }
}
