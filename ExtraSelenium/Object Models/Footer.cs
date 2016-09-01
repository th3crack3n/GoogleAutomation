using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Footer
    {
        private BrowserSession _browser;

        public ObjectModel Advertising
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Advertising')]", "google.com/intl/en/ads"); }
        }

        public ObjectModel Business
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Business')]", "google.com/services"); }
        }

        public ObjectModel About
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'About')]", "google.com/intl/en/about"); }
        }

        public ObjectModel Privacy
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Privacy')]", "google.com/intl/en/policies/privacy"); }
        }

        public ObjectModel Terms
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Terms')]", "google.com/intl/en/policies/terms"); }
        }

        public ObjectModel Settings
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Settings')]"); }
        }

        public ObjectModel InstantOn
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='instant-radio']/div[3]/span"); }
        }

        public ObjectModel InstantOff
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='instant-radio']/div[1]/span"); }
        }

        public ObjectModel InstantSave
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[contains(text(),'Save')]"); }
        }

        public ObjectModel SettingsOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "fsett"); }
        }

        public ObjectModel FeedbackOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "google - feedback - wizard"); }
        }

        public ObjectModel SearchSettings
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "Search settings", "google.com/preferences"); }
        }

        public ObjectModel AdvancedSearch
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "Advanced search", "google.com/advanced_search"); }
        }

        public ObjectModel History
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "History", "google.com/history"); }
        }

        public ObjectModel SearchHelp
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "Search Help", "support.google.com/websearch"); }
        }

        public ObjectModel SendFeedback
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "Send feedback"); }
        }

        public Footer(BrowserSession browser)
        {
            _browser = browser;
        }

        public ObjectModel[] SubSettings
        {
            get { return new ObjectModel[] { SearchSettings, AdvancedSearch, History, SearchHelp }; }
        }
    }
}