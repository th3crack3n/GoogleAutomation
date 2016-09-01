using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Main
    {
        private BrowserSession _browser;
        
        public ObjectModel GoogleSearch
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//input[@value='Google Search']"); }
        }

        public ObjectModel ImFeelingLucky
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='sbtc']/div[2]/div[2]/div/div/div/div/span[2]/span/input"); }
        }

        public ObjectModel SearchBar
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Field, "q"); }
        }

        public Main(BrowserSession browser)
        {
            _browser = browser;
        }

        public bool hasLeftHome()
        {
            return !(_browser.Location.ToString().Equals("https://www.google.com/"));
        }
    }
}