using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation
{
    [TestFixture]
    class TestHomePage
    {
        BrowserSession browser;
        Main main;
        Header header;
        Footer footer;

        [TestFixtureSetUp]
        public void init()
        {
            browser = new BrowserSession(new SessionConfiguration
            {
                Browser = Coypu.Drivers.Browser.Chrome,
                AppHost = "http://www.google.com"
            });
            browser.MaximiseWindow();

            main = new Main(browser);
            header = new Header(browser);
            footer = new Footer(browser);
        }

        [SetUp]
        public void reset()
        {
            browser.Visit("/");
        }

        [Test]
        public void openGmail()
        {
            header.Gmail.Click();

            Assert.IsTrue(header.hasLeftHome());
        }

        [Test]
        public void openImages()
        {
            header.Images.Click();

            Assert.IsTrue(header.hasLeftHome());
        }

        [Test]
        public void openOptions()
        {
            header.Options.Click();

            Assert.IsTrue(header.OptionsOpen.Exists());
        }

        [Test]
        public void openSubOptionAll()
        {
            foreach (var option in header.SubOptions){
                reset();
                header.Options.Click();
                option.Click();

                Assert.IsTrue(option.ContainsPartial());
            }
        }

        [Test]
        public void openSignIn()
        {
            header.SignIn.Click();

            Assert.IsTrue(header.SignIn.ContainsPartial());
        }
        
        [Test]
        public void searchInstantResults()
        {
            footer.disableInstantSearch(false);
            main.SearchBar.FillText("xpanxion");

            Assert.True(true);
        }

        [Test]
        public void searchNormal()
        {
            footer.disableInstantSearch(true);
            main.SearchBar.FillText("xpanxion");
            main.GoogleSearch.Click();

            Assert.IsTrue(main.hasLeftHome());
        }

        [Test]
        public void searchLucky()
        {
            footer.disableInstantSearch(true);
            main.SearchBar.FillText("xpanxion");
            main.ImFeelingLucky.Click();

            Assert.IsTrue(main.hasLeftHome());
        }

        [Test]
        public void openAdvertising()
        {
            footer.Advertising.Click();

            Assert.IsTrue(footer.Advertising.ContainsPartial());
        }

        [Test]
        public void openBusiness()
        {
            footer.Business.Click();

            Assert.IsTrue(footer.Business.ContainsPartial());
        }

        [Test]
        public void openAbout()
        {
            footer.About.Click();

            Assert.IsTrue(footer.About.ContainsPartial());
        }

        [Test]
        public void openPrivacy()
        {
            footer.Privacy.Click();

            Assert.IsTrue(footer.Privacy.ContainsPartial());
        }

        [Test]
        public void openTerms()
        {
            footer.Terms.Click();

            Assert.IsTrue(footer.Terms.ContainsPartial());
        }

        [Test]
        public void openSettings()
        {
            footer.Settings.Click();

            Assert.IsTrue(footer.SettingsOpen.Exists());
        }

        [Test]
        public void openSubSettingsAll()
        {
            foreach (var option in footer.SubSettings)
            {
                reset();
                footer.Settings.Click();
                option.Click();
                if (option == footer.SendFeedback)
                {
                    Assert.IsTrue(footer.FeedbackOpen.Exists());
                }
                else
                {
                    Assert.IsTrue(option.ContainsPartial());
                }
            }
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}