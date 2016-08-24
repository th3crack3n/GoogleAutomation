using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation
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
            header.click(Header.Clickables.SignIn);
        }

        [Test]
        public void testEnterEmail()
        {
            signIn.enterText(SignIn.Fields.SignInEmail, "fake@gmail.com");
        }

        [Test]
        public void testClickNext()
        {
            signIn.click(SignIn.Clickables.Next);
        }

        [Test]
        public void testEnterPassword()
        {
            signIn.enterText(SignIn.Fields.SignInEmail, "fake@gmail.com");
            signIn.click(SignIn.Clickables.Next);

            signIn.enterText(SignIn.Fields.SignInPassword, "fakepass123");
        }

        [Test]
        public void testClickSignIn()
        {
            signIn.enterText(SignIn.Fields.SignInEmail, "fake@gmail.com");
            signIn.click(SignIn.Clickables.Next);

            signIn.enterText(SignIn.Fields.SignInPassword, "fakepass123");
            signIn.click(SignIn.Clickables.SignIn);
        }

        [Test]
        public void testCreateAccount()
        {
            signIn.click(SignIn.Clickables.CreateAccount);
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}