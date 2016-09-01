using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation.Tests
{
    [TestFixture]
    class Journeys
    {
        BrowserSession browser; 
        Footer footer;
        Main main;
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
            main = new Main(browser);
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

        private void login(string user, string pass)
        {
            signIn.Email.FillText(user);    
            signIn.Next.Click();
            signIn.Password.FillText(pass);
            signIn.SignInButton.Click();
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
            header.SignIn.Click();
            login("fake@google.com", "fakepass");   // email must exist
            browser.Visit("/");
            header.Images.Click();

            images.SearchByImage.Click();
            if (images.PasteImageUrlOpen.Exists())
            {
                images.UploadAnImage.Click();
            }
            images.ImageUrl.FillText("C:\\Users\\Public\\Penguins.jpg");
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
            header.SignIn.Click();
            login("fake@google.com", "fakepass");   // email must exist
            browser.Visit("/");
            footer.Terms.Click();
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
            header.SignIn.Click();
            login("fake@google.com", "fakepass");   // email must exist
            signIn.DifferentAccount.Click();
            signIn.CreateAccount.Click();
        }

        /// <summary>
        ///     Goes to sign in page,
        ///     Switches language 4 times
        /// </summary>
        [Test]
        public void journey4()
        {
            header.SignIn.Click();
            signIn.Language.Select("Italiano");
            signIn.Language.Select("Nederlands");
            signIn.Language.Select("Filipino");
            signIn.Language.Select("English (United States)");
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
            header.SignIn.Click();
            signIn.CreateAccount.Click();

            signIn.FirstName.FillText("Sean");
            signIn.LastName.FillText("McCracken");
            signIn.NewAddress.FillText("newfakegmail");
            signIn.NewPassword.FillText("fakepass123");
            signIn.NewPasswordVerify.FillText("fakepass123");
            signIn.BirthMonthOpen.Click();
            signIn.August.Click();
            signIn.BirthDay.element.SendKeys("22");
            signIn.BirthYear.element.SendKeys("1990");
            signIn.GenderOpen.Click();
            signIn.Male.Click();
            signIn.RecoveryPhone.FillText("5153825330");
            signIn.RecoveryEmail.FillText("oldfakegmail@gmail.com");

            signIn.NextNewAccount.Click();
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}