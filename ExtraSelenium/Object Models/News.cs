using Coypu;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace GoogleAutomation.Object_Models
{
    class News
    {
        private BrowserSession browser;
        
        public Objects TopStories
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Top Stories')]"); }
        }

        public Objects Local
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[3]/div/div/div/div[2]/div/ul/li[2]/a"); }
        }

        public Objects World
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'World')]"); }
        }

        public Objects US
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'U.S.')]"); }
        }

        public Objects Business
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Business')]"); }
        }

        public Objects Technology
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Technology')]"); }
        }

        public Objects Entertainment
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Entertainment')]"); }
        }

        public Objects Sports
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Sports')]"); }
        }

        public Objects Science
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Science')]"); }
        }

        public Objects Health
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Health')]"); }
        }

        public Objects Spotlight
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Spotlight')]"); }
        }

        public Objects Elections
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Elections')]"); }
        }

        public Objects SearchBar
        {
            get { return new Objects(browser, Objects.RefType.Id, "gbqfq"); }
        }

        public Objects FirstArticle
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//h2/a/span"); }
        }

        public News(BrowserSession browser)
        {
            this.browser = browser;
        }

        public Objects[] Categories
        {
            get
            {
                return new Objects[] { Local, TopStories, World, US, Business, Technology, Entertainment, Sports, Science, Health, Spotlight, Elections };
            }
        }

        public bool hasLeftHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/");
        }

        public void clickFirstArticle()
        {
            FirstArticle.Click();
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
    }
}
