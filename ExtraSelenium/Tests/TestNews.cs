using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation.Tests
{
    [TestFixture]
    class TestNews
    {
        BrowserSession browser;
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
        }

        [Test]
        public void testAllCategories()
        {
            foreach (var option in news.Categories)
            {
                option.Click();
                
                news.FirstArticle.Click();

                Assert.True(news.hasLeftHome());

                news.closeOpenedArticleTab();
            }
        }

        [Test]
        public void testSearch()
        {
            news.SearchBar.FillText("ford fusion");

            Assert.True(news.hasLeftHome());
        }



        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}