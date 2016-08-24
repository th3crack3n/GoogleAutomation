using Coypu;
using System;
using System.Collections.Generic;

namespace GoogleAutomation.Object_Models
{
    class Footer
    {
        private BrowserSession browser;
        public List<SubSetting> subSettings;

        public enum Clickables {
            Advertising,
            Business,
            About,
            Privacy,
            Terms,
            Settings
        }

        public Footer(BrowserSession browser)
        {
            this.browser = browser;
            
            subSettings = new List<SubSetting>();
            subSettings.Add(new SubSetting("SearchSettings", "Search settings", "google.com/preferences"));
            subSettings.Add(new SubSetting("AdvancedSearch", "Advanced search", "google.com/advanced_search"));
            subSettings.Add(new SubSetting("History", "History", "google.com/history"));
            subSettings.Add(new SubSetting("SearchHelp", "Search Help", "support.google.com/websearch"));
            subSettings.Add(new SubSetting("SendFeedback", "Send feedback", null));
        }
        
        public class SubSetting
        {
            private string name, linkText, landingURLPartial;

            public SubSetting(string name, string linkText, string landingURLPartial)
            {
                this.name = name;
                this.linkText = linkText;
                this.landingURLPartial = landingURLPartial;
            }

            public string getName()
            {
                return name;
            }

            public string getLinkText()
            {
                return linkText;
            }

            public string getLandingURLPartial()
            {
                return landingURLPartial;
            }

            public bool verifyURL(BrowserSession browser)
            {
                return browser.Location.ToString().Contains(landingURLPartial);
            }
        }
        
        public void click(Clickables link)
        {
            var xpath = "";

            switch (link)
            {
                case Clickables.Advertising:
                    xpath = "//a[contains(text(),'Advertising')]";
                    break;
                case Clickables.Business:
                    xpath = "//a[contains(text(),'Business')]";
                    break;
                case Clickables.About:
                    xpath = "//a[contains(text(),'About')]";
                    break;
                case Clickables.Privacy:
                    xpath = "//a[contains(text(),'Privacy')]";
                    break;
                case Clickables.Terms:
                    xpath = "//a[contains(text(),'Terms')]";
                    break;
                case Clickables.Settings:
                    xpath = "//a[contains(text(),'Settings')]";
                    break;
                default:
                    throw new Exception();
            }

            browser.FindXPath(xpath).Click();
        }

        public void clickSubSetting(SubSetting opt)
        {
            click(Clickables.Settings);
            browser.ClickLink(opt.getLinkText());
        }

        public bool hasLeftHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/");
        }

        public string getURL()
        {
            return browser.Location.ToString();
        }

        public bool settingsOpen()
        {
            return browser.FindId("fsett").Exists();
        }

        public bool feedbackOpen()
        {
            return browser.FindFrame("google-feedback-wizard").Exists();
        }

        public void disableInstantSearch(bool desired)
        {
            click(Clickables.Settings);
            browser.ClickLink("Search settings");
            if (desired)
            {
                browser.FindXPath("//div[@id='instant-radio']/div[3]/span").Click();
            }
            else
            {
                browser.FindXPath("//div[@id='instant-radio']/div[1]/span").Click();
            }
            browser.FindXPath("//div[contains(text(),'Save')]").Click();
            browser.AcceptModalDialog();
        }
    }
}