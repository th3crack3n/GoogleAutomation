using Coypu;
using System;

namespace GoogleAutomation.Object_Models
{
    class Main
    {
        private BrowserSession browser;
        
        public Objects GoogleSearch
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//input[@value='Google Search']"); }
        }

        public Objects ImFeelingLucky
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='sbtc']/div[2]/div[2]/div/div/div/div/span[2]/span/input"); }
        }

        public Objects SearchBar
        {
            get { return new Objects(browser, Objects.RefType.Field, "q"); }
        }

        public Main(BrowserSession browser)
        {
            this.browser = browser;
        }

        public bool hasLeftHome()
        {
            return !(browser.Location.ToString().Equals("https://www.google.com/"));
        }
    }
}