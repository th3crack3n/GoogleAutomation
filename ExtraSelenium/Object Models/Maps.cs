using Coypu;
using System.Collections.Generic;

namespace GoogleAutomation.Object_Models
{
    class Maps
    {
        private BrowserSession browser;
        public Dictionary<References, string> Library;

        public enum References
        {
            ZoomIn,
            ZoomOut,
            ShowLocation,
            MapType,
            OpenMenu,
            CloseMenu,
            Explore,
            Directions,
            CancelDirections,
            SearchBox,
            SearchIcon,
            DirectionsFirst,
            DirectionsSecond,
            HomeAddress,
            XpanxionAddress,
            DirectionSubmit
        }

        public Maps(BrowserSession browser)
        {
            this.browser = browser;

            Library = new Dictionary<References, string>();

            Library.Add(References.ZoomIn, "//div[@id='zoom']/div/button[1]");
            Library.Add(References.ZoomOut, "//div[@id='zoom']/div/button[2]");
            Library.Add(References.ShowLocation, "//div[@id='mylocation']/div/button");
            Library.Add(References.MapType, "//div[@id='minimap']/div/div[3]/button");
            Library.Add(References.OpenMenu, "//button[@id='searchbox-hamburger']");
            Library.Add(References.CloseMenu, "//div[@id='settings']/div/div[2]/div/div[2]/button");
            Library.Add(References.Explore, "//div[@id='runway-expand-button']/div/div/button[2]");
            Library.Add(References.Directions, "//button[@id='searchbox-directions']");
            Library.Add(References.CancelDirections, "//div[@id='omnibox']/div/div[3]/div/div/div/button");
            Library.Add(References.SearchBox, "//input[@id='searchboxinput']");
            Library.Add(References.SearchIcon, "//button[@id='searchbox-searchbutton']");
            Library.Add(References.DirectionsFirst, "//div[@id='sb_ifc51']/input");
            Library.Add(References.DirectionsSecond, "//div[@id='sb_ifc52']/input");
            Library.Add(References.DirectionSubmit, "//div[@id='directions-searchbox-1']/button");

            Library.Add(References.HomeAddress, "4909 NE Milligan Ln, Ankeny, IA 50021");
            Library.Add(References.XpanxionAddress, "1315 South Bell Ave, Ames, IA 50010");
        }

        public bool hasLeftMapsHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/maps");
        }

        public void click(References obj, Options opt = null)
        {
            browser.FindXPath(Library[obj], opt).Click();
        }

        public void enterSearchText(string text)
        {
            browser.FindXPath(Library[References.SearchBox]).FillInWith(text);
        }

        public string returnReferenceValue(References obj)
        {
            return Library[obj];
        }

        public void enterDirections()
        {
            browser.FindXPath(Library[References.DirectionsFirst]).FillInWith(Library[References.HomeAddress]);
            browser.FindXPath(Library[References.DirectionsSecond]).FillInWith(Library[References.XpanxionAddress]);
        }
    }
}