using Coypu;
using System;
using System.Collections.Generic;

namespace GoogleAutomation.Object_Models
{
    class Footer
    {
        private BrowserSession browser;

        public Objects Advertising
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Advertising')]", "google.com/intl/en/ads"); }
        }

        public Objects Business
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Business')]", "google.com/services"); }
        }

        public Objects About
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'About')]", "google.com/intl/en/about"); }
        }

        public Objects Privacy
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Privacy')]", "google.com/intl/en/policies/privacy"); }
        }

        public Objects Terms
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Terms')]", "google.com/intl/en/policies/terms"); }
        }

        public Objects Settings
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Settings')]"); }
        }

        public Objects InstantOn
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='instant-radio']/div[3]/span"); }
        }

        public Objects InstantOff
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='instant-radio']/div[1]/span"); }
        }

        public Objects InstantSave
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[contains(text(),'Save')]"); }
        }

        public Objects SettingsOpen
        {
            get { return new Objects(browser, Objects.RefType.Id, "fsett"); }
        }

        public Objects FeedbackOpen
        {
            get { return new Objects(browser, Objects.RefType.Id, "google - feedback - wizard"); }
        }

        public Objects SearchSettings
        {
            get { return new Objects(browser, Objects.RefType.Link, "Search settings", "google.com/preferences"); }
        }

        public Objects AdvancedSearch
        {
            get { return new Objects(browser, Objects.RefType.Link, "Advanced search", "google.com/advanced_search"); }
        }

        public Objects History
        {
            get { return new Objects(browser, Objects.RefType.Link, "History", "google.com/history"); }
        }

        public Objects SearchHelp
        {
            get { return new Objects(browser, Objects.RefType.Link, "Search Help", "support.google.com/websearch"); }
        }

        public Objects SendFeedback
        {
            get { return new Objects(browser, Objects.RefType.Link, "Send feedback"); }
        }

        public Footer(BrowserSession browser)
        {
            this.browser = browser;
        }

        public Objects[] SubSettings
        {
            get { return new Objects[] { SearchSettings, AdvancedSearch, History, SearchHelp }; }
        }

        public void disableInstantSearch(bool desired)
        {
            Settings.Click();
            SearchSettings.Click();
            if (desired)
            {
                InstantOn.Click();
            }
            else
            {
                InstantOff.Click();
            }
            InstantSave.Click();
            browser.AcceptModalDialog();
        }
    }
}