using Coypu;
using System;
using System.Collections.Generic;

namespace GoogleAutomation.Object_Models
{
    class Header
    {
        private BrowserSession browser;
        public List<SubOption> subOptions;

        public enum Clickables
        {
            Gmail,
            Images,
            Options,
            SignIn
        }

        public Header(BrowserSession browser)
        {
            this.browser = browser;
            
            subOptions = new List<SubOption>();
            subOptions.Add(new SubOption("MyAccount", "gb192", "myaccount.google.com", false));
            subOptions.Add(new SubOption("Search", "gb1", "google.com", false));
            subOptions.Add(new SubOption("Maps", "gb8", "google.com/maps", false));
            subOptions.Add(new SubOption("YouTube", "gb36", "youtube.com", false));
            subOptions.Add(new SubOption("Play", "gb78", "play.google.com", false));
            subOptions.Add(new SubOption("News", "gb5", "news.google.com", false));
            subOptions.Add(new SubOption("Gmail", "gb23", "google.com/gmail", false));
            subOptions.Add(new SubOption("Drive", "gb49", "google.com/intl/en/drive", false)); 
            subOptions.Add(new SubOption("Calendar", "gb24", "calendar.google.com", false));
            subOptions.Add(new SubOption("GooglePlus", "gb119", "plus.google.com", false));
            subOptions.Add(new SubOption("Translate", "gb51", "translate.google.com", false));
            subOptions.Add(new SubOption("Photos", "gb31", "google.com/photos", false));
            subOptions.Add(new SubOption("Shopping", "gb6", "google.com/shopping", true));
            subOptions.Add(new SubOption("Wallet", "gb212", "wallet.google.com", true));
            subOptions.Add(new SubOption("Finance", "gb27", "google.com/finance", true));
            subOptions.Add(new SubOption("Docs", "gb25", "docs.google.com", true));
            subOptions.Add(new SubOption("Books", "gb10", "books.google.com", true));
            subOptions.Add(new SubOption("Blogger", "gb30", "blogger.com", true));
            subOptions.Add(new SubOption("Contacts", "gb53", "google.com%2Fcontacts", true));
            subOptions.Add(new SubOption("Hangouts", "gb300", "hangouts.google.com", true));
        }

        public class SubOption
        {
            private string name, id, landingURLPartial;
            bool more;

            public SubOption(string name, string id, string landingURLPartial, bool more)
            {
                this.name = name;
                this.id = id;
                this.landingURLPartial = landingURLPartial;
                this.more = more;
            }

            public string getName()
            {
                return name;
            }

            public string getId()
            {
                return id;
            }

            public string getLandingURLPartial()
            {
                return landingURLPartial;
            }
           
            public bool getMore()
            {
                return more;
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
                case Clickables.Gmail:
                    xpath = "//a[contains(text(),'Gmail')]";
                    break;
                case Clickables.Images:
                    xpath = "//a[contains(text(),'Images')]";
                    break;
                case Clickables.Options:
                    xpath = "//div[@id='gbwa']/div/a";
                    break;
                case Clickables.SignIn:
                    xpath = "//a[contains(text(),'Sign in')]";
                    break;
                default:
                    throw new Exception();
            }

            browser.FindXPath(xpath).Click();
        }

        public void clickSubOption(SubOption opt)
        {
            click(Clickables.Options);
            if (opt.getMore())
            {
                browser.ClickLink("More");
            }
            browser.FindId(opt.getId()).Click();
        }

        public bool hasLeftHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/");
        }

        public string getURL()
        {
            return browser.Location.ToString();
        }

        public bool optionsOpen()
        {
            return browser.FindXPath("//div[@id='gbwa']/div[2]/ul").Exists();
        }
    }
}