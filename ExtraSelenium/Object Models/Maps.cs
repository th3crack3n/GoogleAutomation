using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Maps
    {
        private BrowserSession _browser;

        public ObjectModel ZoomIn
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='zoom']/div/button[1]"); }
        }

        public ObjectModel ZoomOut
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='zoom']/div/button[2]"); }
        }

        public ObjectModel ShowLocation
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='mylocation']/div/button"); }
        }

        public ObjectModel MapType
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='minimap']/div/div[3]/button"); }
        }

        public ObjectModel OpenMenu
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//button[@id='searchbox-hamburger']"); }
        }

        public ObjectModel CloseMenu
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='settings']/div/div[2]/div/div[2]/button"); }
        }

        public ObjectModel Explore
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='runway-expand-button']/div/div/button[2]"); }
        }

        public ObjectModel OpenDirections
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//button[@id='searchbox-directions']"); }
        }

        public ObjectModel CloseDirections
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='omnibox']/div/div[3]/div/div/div/button"); }
        }

        public ObjectModel SearchBox
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//input[@id='searchboxinput']"); }
        }

        public ObjectModel SearchIcon
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//button[@id='searchbox-searchbutton']"); }
        }

        public ObjectModel DirectionsFirst
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='sb_ifc51']/input"); }
        }

        public ObjectModel DirectionsSecond
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='sb_ifc52']/input"); }
        }

        public ObjectModel DirectionSubmit
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='directions-searchbox-1']/button"); }
        }
        
        public Maps(BrowserSession browser)
        {
            _browser = browser;
        }
    }
}