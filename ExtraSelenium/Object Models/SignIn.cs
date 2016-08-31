using Coypu;

namespace GoogleAutomation.Object_Models
{
    class SignIn
    {
        private BrowserSession browser;
        
        public Objects Next
        {
            get { return new Objects(browser, Objects.RefType.Id, "next"); }
        }

        public Objects SignInButton
        {
            get { return new Objects(browser, Objects.RefType.Id, "signIn"); }
        }

        public Objects CreateAccount
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Create account')]"); }
        }

        public Objects BirthMonthOpen
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//span[@id='BirthMonth']/div"); }
        }

        public Objects January
        {
            get { return new Objects(browser, Objects.RefType.Id, ":1"); }
        }

        public Objects February
        {
            get { return new Objects(browser, Objects.RefType.Id, ":2"); }
        }

        public Objects March
        {
            get { return new Objects(browser, Objects.RefType.Id, ":3"); }
        }

        public Objects April
        {
            get { return new Objects(browser, Objects.RefType.Id, ":4"); }
        }

        public Objects May
        {
            get { return new Objects(browser, Objects.RefType.Id, ":5"); }
        }

        public Objects June
        {
            get { return new Objects(browser, Objects.RefType.Id, ":6"); }
        }

        public Objects July
        {
            get { return new Objects(browser, Objects.RefType.Id, ":7"); }
        }

        public Objects August
        {
            get { return new Objects(browser, Objects.RefType.Id, ":8"); }
        }

        public Objects September
        {
            get { return new Objects(browser, Objects.RefType.Id, ":9"); }
        }

        public Objects October
        {
            get { return new Objects(browser, Objects.RefType.Id, ":10"); }
        }

        public Objects November
        {
            get { return new Objects(browser, Objects.RefType.Id, ":11"); }
        }

        public Objects December
        {
            get { return new Objects(browser, Objects.RefType.Id, ":12"); }
        }

        public Objects GenderOpen
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='Gender']/div"); }
        }

        public Objects Female
        {
            get { return new Objects(browser, Objects.RefType.Id, ":e"); }
        }

        public Objects Male
        {
            get { return new Objects(browser, Objects.RefType.Id, ":f"); }
        }

        public Objects Other
        {
            get { return new Objects(browser, Objects.RefType.Id, ":g"); }
        }

        public Objects NextNewAccount
        {
            get { return new Objects(browser, Objects.RefType.Id, "submitbutton"); }
        }

        public Objects DifferentAccount
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//a[contains(text(),'Sign in with a different account')]"); }
        }

        public Objects Email
        {
            get { return new Objects(browser, Objects.RefType.Id, "Email"); }
        }

        public Objects Password
        {
            get { return new Objects(browser, Objects.RefType.Id, "Passwd"); }
        }

        public Objects FirstName
        {
            get { return new Objects(browser, Objects.RefType.Id, "FirstName"); }
        }

        public Objects LastName
        {
            get { return new Objects(browser, Objects.RefType.Id, "LastName"); }
        }

        public Objects NewAddress
        {
            get { return new Objects(browser, Objects.RefType.Id, "GmailAddress"); }
        }

        public Objects NewPassword
        {
            get { return new Objects(browser, Objects.RefType.Id, "Passwd"); }
        }

        public Objects NewPasswordVerify
        {
            get { return new Objects(browser, Objects.RefType.Id, "PasswdAgain"); }
        }

        public Objects BirthDay
        {
            get { return new Objects(browser, Objects.RefType.Id, "BirthDay"); }
        }

        public Objects BirthYear
        {
            get { return new Objects(browser, Objects.RefType.Id, "BirthYear"); }
        }

        public Objects RecoveryPhone
        {
            get { return new Objects(browser, Objects.RefType.Id, "RecoveryPhoneNumber"); }
        }

        public Objects RecoveryEmail
        {
            get { return new Objects(browser, Objects.RefType.Id, "RecoveryEmailAddress"); }
        }

        public Objects Language
        {
            get { return new Objects(browser, Objects.RefType.Id, "lang-chooser"); }
        }
        
        public SignIn(BrowserSession browser)
        {
            this.browser = browser;
        }

        public void login(string email, string password)
        {
            Email.FillText(email);
            Next.Click();
            Password.FillText(password);
            SignInButton.Click();
        }

        public void fillCreateAccount(string first, string last, string newAddr, string pass, string passAgain, Objects month, 
            string day, string year, Objects gender, string phone, string currAddr)
        {
            FirstName.FillText(first);
            LastName.FillText(last);
            NewAddress.FillText(newAddr);
            NewPassword.FillText(pass);
            NewPasswordVerify.FillText(passAgain);

            BirthMonthOpen.Click();
            month.Click();

            BirthDay.element.SendKeys(day);
            BirthYear.element.SendKeys(year);

            GenderOpen.Click();
            gender.Click();

            RecoveryPhone.FillText(phone);
            RecoveryEmail.FillText(currAddr);
        }   
    }
}
