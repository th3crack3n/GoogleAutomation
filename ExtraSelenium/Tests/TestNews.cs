using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;
using System;

namespace GoogleAutomation
{
    [TestFixture]
    class TestNews
    {
        BrowserSession browser;
        Google google;
        Header header;
        Footer footer;
        News news;

        [TestFixtureSetUp]
        public void init()
        {
            browser = new BrowserSession(new SessionConfiguration
            {
                Browser = Coypu.Drivers.Browser.Chrome,
                AppHost = "http://news.google.com"
            });
            browser.MaximiseWindow();
            
            header = new Header(browser);
            footer = new Footer(browser);
            news = new News(browser);
        }

        [SetUp]
        public void reset()
        {
            browser.Visit("/");
            //header.clickSubOption(header.subOptions[5]);
        }

        [Test]
        public void testAllCategories()
        {
            foreach (News.Categories option in Enum.GetValues(typeof(News.Categories)))
            {
                news.click(option);
                news.clickFirstArticle();
            }
        }

        [Test]
        public void testSearch()
        {
            news.enterText(News.Fields.SearchBar, "ford fusion");
        }



        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}