using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            maps.click(Maps.References.ZoomIn);
            maps.click(Maps.References.ZoomOut);
        }

        [Test]
        public void testLocation()
        {
            maps.click(Maps.References.ShowLocation);
        }

        [Test]
        public void toggleMapType()
        {
            maps.click(Maps.References.MapType);
            maps.click(Maps.References.MapType);
        }

        [Test]
        public void toggleMenu()
        {
            maps.click(Maps.References.OpenMenu);
            maps.click(Maps.References.CloseMenu);
        }

        [Test]
        public void toggleExplore()
        {
            maps.click(Maps.References.Explore);
            maps.click(Maps.References.Explore);
        }

        [Test]
        public void toggleDirections()
        {
            maps.click(Maps.References.Directions);
            maps.click(Maps.References.CancelDirections, Options.First);
        }

        [Test]
        public void searchText()
        {
            maps.enterSearchText(maps.returnReferenceValue(Maps.References.XpanxionAddress));
            maps.click(Maps.References.SearchIcon);
        }

        [Test]
        public void getDirections()
        {
            maps.click(Maps.References.Directions);
            maps.enterDirections();
            maps.click(Maps.References.DirectionSubmit);
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