using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;
using System.Threading;

namespace GoogleAutomation
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
            Thread.Sleep(3500);
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
            maps.Directions.Click();
            maps.CancelDirections.Click();
        }

        [Test]
        public void searchText()
        {
            maps.SearchBox.FillText("Xpanxion, Ames IA");
            maps.SearchIcon.Click();
        }

        [Test]
        public void getDirections()
        {
            maps.Directions.Click();
            maps.enterDirections();
            maps.DirectionSubmit.Click();
        }

        [TearDown]
        public void wait()
        {
            Thread.Sleep(1500);     // to see results
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}