using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation
{
    [TestFixture]
    class TestHomePage
    {
        BrowserSession browser;
        Google google;
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

            google = new Google(browser);
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
            header.click(Header.Clickables.Gmail);
            Assert.IsTrue(header.hasLeftHome());
        }

        [Test]
        public void openImages()
        {
            header.click(Header.Clickables.Images);
            Assert.IsTrue(header.hasLeftHome());
        }

        [Test]
        public void openOptions()
        {
            header.click(Header.Clickables.Options);
            Assert.IsTrue(header.optionsOpen());
        }

        [Test Ignore]
        public void openSubOptionAll()
        {
            foreach (var option in header.subOptions){
                reset();
                header.clickSubOption(option);
                Assert.IsTrue(option.verifyURL(browser));
            }
        }

        [Test]
        public void openSignIn()
        {
            header.click(Header.Clickables.SignIn);
            Assert.IsTrue(header.getURL().ToString().Contains("accounts.google.com"));
        }

        [Test]
        public void openDoodle()
        {
            google.click(Google.Clickables.Doodle);
            Assert.True(google.hasLeftHome());
        }

        [Test]
        public void searchInstantResults()
        {
            footer.disableInstantSearch(false);
            google.enterSearch("xpanxion");
        }

        [Test]
        public void searchNormal()
        {
            footer.disableInstantSearch(true);
            google.enterSearch("xpanxion");
            google.click(Google.Clickables.GoogleSearch);
            Assert.IsTrue(google.hasLeftHome());
        }

        [Test]
        public void searchLucky()
        {
            footer.disableInstantSearch(true);
            google.enterSearch("xpanxion");
            google.click(Google.Clickables.ImFeelingLucky);
            Assert.IsTrue(google.hasLeftHome());
        }

        [Test]
        public void openAdvertising()
        {
            footer.click(Footer.Clickables.Advertising);
            Assert.IsTrue(footer.getURL().ToString().Contains("google.com/intl/en/ads"));
        }

        [Test]
        public void openBusiness()
        {
            footer.click(Footer.Clickables.Business);
            Assert.IsTrue(footer.getURL().ToString().Contains("google.com/services"));
        }

        [Test]
        public void openAbout()
        {
            footer.click(Footer.Clickables.About);
            Assert.IsTrue(footer.getURL().ToString().Contains("google.com/intl/en/about"));
        }

        [Test]
        public void openPrivacy()
        {
            footer.click(Footer.Clickables.Privacy);
            Assert.IsTrue(footer.getURL().ToString().Contains("google.com/intl/en/policies/privacy"));
        }

        [Test]
        public void openTerms()
        {
            footer.click(Footer.Clickables.Terms);
            Assert.IsTrue(footer.getURL().ToString().Contains("google.com/intl/en/policies/terms"));
        }

        [Test]
        public void openSettings()
        {
            footer.click(Footer.Clickables.Settings);
            Assert.IsTrue(footer.settingsOpen());
        }

        [Test]
        public void openSubSettingsAll()
        {
            foreach (var option in footer.subSettings)
            {
                reset();
                footer.clickSubSetting(option);
                if (option.getName().Equals("SendFeedback"))
                {
                    Assert.IsTrue(footer.feedbackOpen());
                }
                else
                {
                    Assert.IsTrue(footer.getURL().ToString().Contains(option.getLandingURLPartial()));
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