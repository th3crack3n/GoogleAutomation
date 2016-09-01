using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;
using System.Threading;

namespace GoogleAutomation.Tests
{
    class TestMapPage
    {

        static BrowserSession browser;
        Maps maps;

        [TestFixtureSetUp]
        public void init()
        {
            browser = new BrowserSession(new SessionConfiguration
            {
                Browser = Coypu.Drivers.Browser.Chrome,
                AppHost = "http://www.google.com"
            });
            browser.MaximiseWindow();

            maps = new Maps(browser);
        }

        [SetUp]
        public void reset()
        {
            browser.Visit("/maps");
            Thread.Sleep(3500);     // content slow to load
        }

        [Test]
        public void zoomInAndOut()
        {
            maps.ZoomIn.Click();
            maps.ZoomOut.Click();
        }

        [Test]
        public void testLocation()
        {
            maps.ShowLocation.Click();
        }

        [Test]
        public void toggleMapType()
        {
            maps.MapType.Click();
            maps.MapType.Click();
        }

        [Test]
        public void toggleMenu()
        {
            maps.OpenMenu.Click();
            maps.CloseMenu.Click();
        }

        [Test]
        public void toggleExplore()
        {
            maps.Explore.Click();
            maps.Explore.Click();
        }

        [Test]
        public void toggleDirections()
        {
            maps.OpenDirections.Click();
            maps.CloseDirections.Click();
        }

        [Test]
        public void searchText()
        {
            maps.SearchBox.FillText("Ames IA");
            maps.SearchIcon.Click();
        }

        [Test]
        public void getDirections()
        {
            maps.OpenDirections.Click();
            maps.DirectionsFirst.FillText("4909 NE Milligan Ln, Ankeny, IA 50021");
            maps.DirectionsSecond.FillText("1315 South Bell Ave, Ames, IA 50010");
            maps.DirectionSubmit.Click();
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}