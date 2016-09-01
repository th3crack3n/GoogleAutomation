using Coypu;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace GoogleAutomation.Object_Models
{
    class News
    {
        private BrowserSession _browser;
        
        public ObjectModel TopStories
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Top Stories')]"); }
        }

        public ObjectModel Local
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[3]/div/div/div/div[2]/div/ul/li[2]/a"); }
        }

        public ObjectModel World
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'World')]"); }
        }

        public ObjectModel US
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'U.S.')]"); }
        }

        public ObjectModel Business
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Business')]"); }
        }

        public ObjectModel Technology
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Technology')]"); }
        }

        public ObjectModel Entertainment
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Entertainment')]"); }
        }

        public ObjectModel Sports
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Sports')]"); }
        }

        public ObjectModel Science
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Science')]"); }
        }

        public ObjectModel Health
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Health')]"); }
        }

        public ObjectModel Spotlight
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Spotlight')]"); }
        }

        public ObjectModel Elections
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Elections')]"); }
        }

        public ObjectModel SearchBar
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gbqfq"); }
        }

        public ObjectModel FirstArticle
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//h2/a/span"); }
        }

        public News(BrowserSession browser)
        {
            _browser = browser;
        }

        public ObjectModel[] Categories
        {
            get
            {
                return new ObjectModel[] { Local, TopStories, World, US, Business, Technology, Entertainment, Sports, Science, Health, Spotlight, Elections };
            }
        }

        public bool hasLeftHome()
        {
            return !Equals(_browser.Location, "https://www.google.com/");
        }
        
        public void closeOpenedArticleTab()
        {
            Thread.Sleep(500);
            ChromeDriver driver = (ChromeDriver) _browser.Native;
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);      // newly opened tab
            driver.Close();
            driver.SwitchTo().Window(tabs[0]);      // original tab
        }
    }
}
