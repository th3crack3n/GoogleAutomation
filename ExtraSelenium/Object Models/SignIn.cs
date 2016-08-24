using Coypu;

namespace GoogleAutomation.Object_Models
{
    class SignIn
    {
        private BrowserSession browser;

        public enum Clickables
        {
            Next,
            SignIn,
            CreateAccount,
            BirthMonthOpen,
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December,
            GenderOpen,
            Female,
            Male,
            Other,
            NextNewAccount,
            DifferentAccount
        }

        public enum Fields
        {
            SignInEmail,
            SignInPassword,
            FirstName,
            LastName,
            NewAddress,
            Password,
            PasswordVerify,
            BirthDay,
            BirthYear,
            RecoveryPhone,
            RecoveryEmail
        }

        public enum Selectables
        {
            Language
        }

        public SignIn(BrowserSession browser)
        {
            this.browser = browser;
        }

        public void login(string email, string password)
        {
            enterText(Fields.SignInEmail, email);
            click(Clickables.Next);
            enterText(Fields.SignInPassword, password);
            click(Clickables.SignIn);
        }

        public void fillCreateAccount(string first, string last, string newAddr, string pass, string passAgain, Clickables month, 
            string day, string year, Clickables gender, string phone, string currAddr)
        {
            enterText(Fields.FirstName, first);
            enterText(Fields.LastName, last);
            enterText(Fields.NewAddress, newAddr);
            enterText(Fields.Password, pass);
            enterText(Fields.PasswordVerify, passAgain);

            click(Clickables.BirthMonthOpen);
            click(month);

            enterText(Fields.BirthDay, day);
            enterText(Fields.BirthYear, year);

            click(Clickables.GenderOpen);
            click(gender);

            enterText(Fields.RecoveryPhone, phone);
            enterText(Fields.RecoveryEmail, currAddr);
        }

        public void click(Clickables clickObj)
        {
            var reference = getClickRef(clickObj);

            if (clickObj == Clickables.CreateAccount || clickObj == Clickables.DifferentAccount || 
                clickObj == Clickables.BirthMonthOpen || clickObj == Clickables.GenderOpen)
            {
                browser.FindXPath(reference).Click();
            } else
            {
                browser.FindId(reference).Click();
            }
        }
        
        private string getClickRef(Clickables clickObj)
        {
            switch (clickObj)
            {
                case Clickables.Next:
                    return "next";
                case Clickables.SignIn:
                    return "signIn";
                case Clickables.CreateAccount:
                    return "//a[contains(text(),'Create account')]";
                case Clickables.BirthMonthOpen:
                    return "//span[@id='BirthMonth']/div";
                case Clickables.January:
                    return ":1";
                case Clickables.February:
                    return ":2";
                case Clickables.March:
                    return ":3";
                case Clickables.April:
                    return ":4";
                case Clickables.May:
                    return ":5";
                case Clickables.June:
                    return ":6";
                case Clickables.July:
                    return ":7";
                case Clickables.August:
                    return ":8";
                case Clickables.September:
                    return ":9";
                case Clickables.October:
                    return ":10";
                case Clickables.November:
                    return ":11";
                case Clickables.December:
                    return ":12";
                case Clickables.GenderOpen:
                    return "//div[@id='Gender']/div";
                case Clickables.Female:
                    return ":e";
                case Clickables.Male:
                    return ":f";
                case Clickables.Other:
                    return ":g";
                case Clickables.NextNewAccount:
                    return "submitbutton";
                case Clickables.DifferentAccount:
                    return "//a[contains(text(),'Sign in with a different account')]";
                default:
                    return null;
            }
        }

        public void enterText(Fields fieldObj, string text)
        {
            var reference = getFieldRef(fieldObj);

            if (fieldObj == Fields.BirthDay || fieldObj == Fields.BirthYear)
            {
                browser.FindId(reference).SendKeys(text);
            }
            else
            {
                browser.FillIn(reference).With(text);
            }
        }
        
        private string getFieldRef(Fields fieldObj)
        {
            switch (fieldObj)
            {
                case Fields.SignInEmail:
                    return "Email";
                case Fields.SignInPassword:
                    return "Passwd";
                case Fields.FirstName:
                    return "FirstName";
                case Fields.LastName:
                    return "LastName";
                case Fields.NewAddress:
                    return "GmailAddress";
                case Fields.Password:
                    return "Passwd";
                case Fields.PasswordVerify:
                    return "PasswdAgain";
                case Fields.BirthDay:
                    return "BirthDay";
                case Fields.BirthYear:
                    return "BirthYear";
                case Fields.RecoveryPhone:
                    return "RecoveryPhoneNumber";
                case Fields.RecoveryEmail:
                    return "RecoveryEmailAddress";
                default:
                    return null;
            }
        }

        public void selectOption(Selectables selection, string opt)
        {
            var reference = getSelectablesRef(selection);

            browser.Select(opt).From(reference);
        }

        private string getSelectablesRef(Selectables selection)
        {
            switch (selection)
            {
                case Selectables.Language:
                    return "lang-chooser";
                default:
                    return null;
            }
        } 
    }
}
