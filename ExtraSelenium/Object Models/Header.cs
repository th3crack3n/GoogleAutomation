using Coypu;
using System;
using System.Collections.Generic;

namespace GoogleAutomation.Object_Models
{
    class Header
    {
        private BrowserSession browser;

        public Objects Gmail
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Gmail')]", "google.com/gmail"); }
        }

        public Objects Images
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Images')]", "google.com/img"); }
        }

        public Objects Options
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='gbwa']/div/a"); }
        }

        public Objects OptionsOpen
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='gbwa']/div[2]/ul"); }
        }

        public Objects SignIn
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Sign in')]", "accounts.google.com"); }
        }

        public Objects MyAccount
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb192", "myaccount.google.com"); }
        }

        public Objects Search
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb1", "google.com"); }
        }

        public Objects Maps
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb8", "google.com/maps"); }
        }

        public Objects YouTube
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb36", "youtube.com"); }
        }

        public Objects Play
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb78", "play.google.com"); }
        }

        public Objects News
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb5", "news.google.com"); }
        }

        public Objects OptGmail
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb23", "google.com/gmail"); }
        }

        public Objects Drive
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb49", "google.com/intl/en/drive"); }
        }

        public Objects Calendar
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb24", "calendar.google.com"); }
        }

        public Objects GooglePlus
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb119", "plus.google.com"); }
        }

        public Objects Translate
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb51", "translate.google.com"); }
        }

        public Objects Photos
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb31", "google.com/photos"); }
        }

        public Objects Shopping
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb6", "google.com/shopping", true); }
        }

        public Objects Wallet
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb212", "wallet.google.com", true); }
        }

        public Objects Finance
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb27", "google.com/finance", true); }
        }

        public Objects Docs
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb25", "docs.google.com", true); }
        }

        public Objects Books
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb10", "books.google.com", true); }
        }

        public Objects Blogger
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb30", "blogger.com", true); }
        }

        public Objects Contacts
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb53", "google.com%2Fcontacts", true); }
        }

        public Objects Hangouts
        {
            get { return new Objects(browser, Objects.RefType.Id, "gb300", "hangouts.google.com", true); }
        }

        public Header(BrowserSession browser)
        {
            this.browser = browser; 
        }

        public Objects[] SubOptions
        {
            get
            {
                return new Objects[] { MyAccount, Search, Maps, YouTube, Play, News, OptGmail, Drive, Calendar,
                    GooglePlus, Translate, Photos, Shopping, Wallet, Finance, Docs, Books, Blogger, Contacts, Hangouts };
            }
        }
        
        public bool hasLeftHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/");
        }
    }
}