using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Header
    {
        private BrowserSession _browser;

        public ObjectModel Gmail
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Gmail')]", "google.com/gmail"); }
        }

        public ObjectModel Images
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Images')]", "google.com/img"); }
        }

        public ObjectModel Options
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='gbwa']/div/a"); }
        }

        public ObjectModel OptionsOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='gbwa']/div[2]/ul"); }
        }

        public ObjectModel SignIn
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Sign in')]", "accounts.google.com"); }
        }

        public ObjectModel MyAccount
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb192", "myaccount.google.com"); }
        }

        public ObjectModel Search
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb1", "google.com"); }
        }

        public ObjectModel Maps
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb8", "google.com/maps"); }
        }

        public ObjectModel YouTube
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb36", "youtube.com"); }
        }

        public ObjectModel Play
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb78", "play.google.com"); }
        }

        public ObjectModel News
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb5", "news.google.com"); }
        }

        public ObjectModel OptGmail
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb23", "google.com/gmail"); }
        }

        public ObjectModel Drive
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb49", "google.com/intl/en/drive"); }
        }

        public ObjectModel Calendar
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb24", "calendar.google.com"); }
        }

        public ObjectModel GooglePlus
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb119", "plus.google.com"); }
        }

        public ObjectModel Translate
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb51", "translate.google.com"); }
        }

        public ObjectModel Photos
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb31", "google.com/photos"); }
        }

        public ObjectModel Shopping
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb6", "google.com/shopping", true); }
        }

        public ObjectModel Wallet
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb212", "wallet.google.com", true); }
        }

        public ObjectModel Finance
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb27", "google.com/finance", true); }
        }

        public ObjectModel Docs
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb25", "docs.google.com", true); }
        }

        public ObjectModel Books
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb10", "books.google.com", true); }
        }

        public ObjectModel Blogger
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb30", "blogger.com", true); }
        }

        public ObjectModel Contacts
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb53", "google.com%2Fcontacts", true); }
        }

        public ObjectModel Hangouts
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "gb300", "hangouts.google.com", true); }
        }

        public Header(BrowserSession browser)
        {
            _browser = browser; 
        }

        public ObjectModel[] SubOptions
        {
            get
            {
                return new ObjectModel[] { MyAccount, Search, Maps, YouTube, Play, News, OptGmail, Drive, Calendar,
                    GooglePlus, Translate, Photos, Shopping, Wallet, Finance, Docs, Books, Blogger, Contacts, Hangouts };
            }
        }
        
        public bool hasLeftHome()
        {
            return !string.Equals(_browser.Location, "https://www.google.com/");
        }
    }
}