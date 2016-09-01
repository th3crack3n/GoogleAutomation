using Coypu;

namespace GoogleAutomation.Object_Models
{
    class SignIn
    {
        private BrowserSession _browser;
        
        public ObjectModel Next
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "next"); }
        }

        public ObjectModel SignInButton
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "signIn"); }
        }

        public ObjectModel CreateAccount
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Create account')]"); }
        }

        public ObjectModel BirthMonthOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//span[@id='BirthMonth']/div"); }
        }

        public ObjectModel January
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":1"); }
        }

        public ObjectModel February
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":2"); }
        }

        public ObjectModel March
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":3"); }
        }

        public ObjectModel April
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":4"); }
        }

        public ObjectModel May
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":5"); }
        }

        public ObjectModel June
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":6"); }
        }

        public ObjectModel July
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":7"); }
        }

        public ObjectModel August
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":8"); }
        }

        public ObjectModel September
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":9"); }
        }

        public ObjectModel October
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":10"); }
        }

        public ObjectModel November
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":11"); }
        }

        public ObjectModel December
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":12"); }
        }

        public ObjectModel GenderOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='Gender']/div"); }
        }

        public ObjectModel Female
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":e"); }
        }

        public ObjectModel Male
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":f"); }
        }

        public ObjectModel Other
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, ":g"); }
        }

        public ObjectModel NextNewAccount
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "submitbutton"); }
        }

        public ObjectModel DifferentAccount
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//a[contains(text(),'Sign in with a different account')]"); }
        }

        public ObjectModel Email
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "Email"); }
        }

        public ObjectModel Password
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "Passwd"); }
        }

        public ObjectModel FirstName
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "FirstName"); }
        }

        public ObjectModel LastName
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "LastName"); }
        }

        public ObjectModel NewAddress
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "GmailAddress"); }
        }

        public ObjectModel NewPassword
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "Passwd"); }
        }

        public ObjectModel NewPasswordVerify
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "PasswdAgain"); }
        }

        public ObjectModel BirthDay
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "BirthDay"); }
        }

        public ObjectModel BirthYear
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "BirthYear"); }
        }

        public ObjectModel RecoveryPhone
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "RecoveryPhoneNumber"); }
        }

        public ObjectModel RecoveryEmail
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "RecoveryEmailAddress"); }
        }

        public ObjectModel Language
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "lang-chooser"); }
        }
        
        public SignIn(BrowserSession browser)
        {
            _browser = browser;
        }
    }
}
