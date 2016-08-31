using Coypu;
using System.Collections.Generic;

namespace GoogleAutomation.Object_Models
{
    class Maps
    {
        private BrowserSession browser;

        public Objects ZoomIn
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='zoom']/div/button[1]"); }
        }

        public Objects ZoomOut
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='zoom']/div/button[2]"); }
        }

        public Objects ShowLocation
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='mylocation']/div/button"); }
        }

        public Objects MapType
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='minimap']/div/div[3]/button"); }
        }

        public Objects OpenMenu
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//button[@id='searchbox-hamburger']"); }
        }

        public Objects CloseMenu
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='settings']/div/div[2]/div/div[2]/button"); }
        }

        public Objects Explore
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='runway-expand-button']/div/div/button[2]"); }
        }

        public Objects Directions
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//button[@id='searchbox-directions']"); }
        }

        public Objects CancelDirections
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='omnibox']/div/div[3]/div/div/div/button"); }
        }

        public Objects SearchBox
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//input[@id='searchboxinput']"); }
        }

        public Objects SearchIcon
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//button[@id='searchbox-searchbutton']"); }
        }

        public Objects DirectionsFirst
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='sb_ifc51']/input"); }
        }

        public Objects DirectionsSecond
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='sb_ifc52']/input"); }
        }

        public Objects DirectionSubmit
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='directions-searchbox-1']/button"); }
        }

        string HomeAddress = "4909 NE Milligan Ln, Ankeny, IA 50021";
        string XpanxionAddress = "1315 South Bell Ave, Ames, IA 50010";
        
        public Maps(BrowserSession browser)
        {
            this.browser = browser;
        }

        public void enterDirections()
        {
            DirectionsFirst.FillText(HomeAddress);
            DirectionsSecond.FillText(XpanxionAddress);
        }
    }
}