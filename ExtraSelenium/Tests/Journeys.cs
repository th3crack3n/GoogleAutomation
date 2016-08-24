using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation
{
    [TestFixture]
    class Journeys
    {
        BrowserSession browser; 
        Footer footer;
        Google google;
        Header header;
        Images images;
        Maps maps;
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

            footer = new Footer(browser);
            google = new Google(browser);
            header = new Header(browser);
            images = new Images(browser);
            maps = new Maps(browser);
            signIn = new SignIn(browser);
        }

        [SetUp]
        public void reset()
        {
            browser.Visit("/");
        }

        /// <summary>
        ///     Goes to sign in page,
        ///     Fails login,
        ///     Goes back to home page,
        ///     Navigates to images page,
        ///     Uploads image
        /// </summary>
        [Test]
        public void journey1()
        {
            header.click(Header.Clickables.SignIn);
            signIn.login("fake@google.com", "failpass");   // email must exist
            browser.Visit("/");
            header.click(Header.Clickables.Images);
            images.uploadImage("C:\\Users\\Public\\Penguins.jpg");
        }

        /// <summary>
        ///     Goes to sign in page,
        ///     Fails login,
        ///     Goes back to home page,
        ///     Checks out Google terms
        /// </summary>
        [Test]
        public void journey2()
        {
            header.click(Header.Clickables.SignIn);
            signIn.login("fake@google.com", "failpass");   // email must exist
            browser.Visit("/");
            footer.click(Footer.Clickables.Terms);
        }

        /// <summary>
        ///     Goes to sign in page,
        ///     Fails login,
        ///     Clicks on the "Sign in with a different account" link,
        ///     Goes to "Create new account" page
        /// </summary>
        [Test]
        public void journey3()
        {
            header.click(Header.Clickables.SignIn);
            signIn.login("fake@google.com", "failpass");   // email must exist
            signIn.click(SignIn.Clickables.DifferentAccount);
            signIn.click(SignIn.Clickables.CreateAccount);
        }

        /// <summary>
        ///     Goes to sign in page,
        ///     Switches language 4 times
        /// </summary>
        [Test]
        public void journey4()
        {
            header.click(Header.Clickables.SignIn);
            signIn.selectOption(SignIn.Selectables.Language, "Italiano");
            signIn.selectOption(SignIn.Selectables.Language, "Nederlands");
            signIn.selectOption(SignIn.Selectables.Language, "Filipino");
            signIn.selectOption(SignIn.Selectables.Language, "English (United States)");
        }

        /// <summary>
        ///     Goes to sign in page,
        ///     Clicks "Create new account",
        ///     Fills in all necessary fields,
        ///     Click "Next step"
        /// </summary>
        [Test]
        public void journey5()
        {
            header.click(Header.Clickables.SignIn);
            signIn.click(SignIn.Clickables.CreateAccount);
            signIn.fillCreateAccount("Sean", "McCracken", "newfakegmail", "fakepass123", "fakepass123", 
                SignIn.Clickables.August, "22", "1990", SignIn.Clickables.Male, "5153825330", "oldfakegmail@gmail.com");
            signIn.click(SignIn.Clickables.NextNewAccount);
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}