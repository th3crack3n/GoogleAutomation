using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation.Tests
{
    [TestFixture]
    class TestSignIn
    {
        BrowserSession browser;
        Header header;
        Footer footer;
        SignIn signIn;

        [TestFixtureSetUp]
        public void init()
        {
            browser = new BrowserSession(new SessionConfiguration
            {
                Browser = Coypu.Drivers.Browser.Chrome,
                AppHost = "http://www.google.com"
            });
            browser.MaximiseWindow();

            header = new Header(browser);
            footer = new Footer(browser);
            signIn = new SignIn(browser);
        }

        [SetUp]
        public void reset()
        {
            browser.Visit("/");
            header.SignIn.Click();
        }

        [Test]
        public void testEnterEmail()
        {
            signIn.Email.FillText("fake@gmail.com");
        }

        [Test]
        public void testClickNext()
        {
            signIn.Next.Click();
        }

        [Test]
        public void testEnterPassword()
        {
            signIn.Email.FillText("fake@gmail.com");
            signIn.Next.Click();
            signIn.Password.FillText("fakepass123");
        }

        [Test]
        public void testClickSignIn()
        {
            signIn.Email.FillText("fake@gmail.com");
            signIn.Next.Click();
            signIn.Password.FillText("fakepass123");
            signIn.SignInButton.Click();
        }

        [Test]
        public void testCreateAccount()
        {
            signIn.CreateAccount.Click();
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}