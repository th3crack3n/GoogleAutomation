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
    class TestImagePage
    {

        static BrowserSession browser;
        Images images;

        [TestFixtureSetUp]
        public void init()
        {
            browser = new BrowserSession(new SessionConfiguration
            {
                Browser = Coypu.Drivers.Browser.Chrome,
                AppHost = "http://www.google.com"
            });
            browser.MaximiseWindow();
            
            images = new Images(browser);
        }

        [SetUp]
        public void reset()
        {
            browser.Visit("/images");
        }

        [Test]
        public void imageSearchXpanxion()
        {
            images.typeAndReturnSearchBar("xpanxion");
            Assert.IsTrue(images.hasLeftImagesHome());
        }

        [Test]
        public void openSearchByImage()
        {
            images.SearchByImage.Click();

            Assert.IsTrue(images.SearchByImageOpen.Exists());
        }

        [Test]
        public void toggleSearchByImageSelector()
        {
            openSearchByImage();
            images.toggleUploadImage();

            Assert.IsTrue(images.UploadAnImageOpen.Exists());

            images.togglePasteImageURL();

            Assert.IsTrue(images.PasteImageUrlOpen.Exists());

        }

        [Test]
        public void searchByImageURL()
        {
            openSearchByImage();
            images.typeInImageURL("http://xpanxion.com/images/black%20xpanxion-ust%20global%20group.png");
            images.clickSearchByImagePost();

            Assert.IsTrue(images.hasLeftImagesHome());
        }

        [Test]
        public void searchByUpload()
        {
            openSearchByImage();
            images.toggleUploadImage();
            images.uploadImageLocation(("C:\\Users\\Public\\Penguins.jpg"));
            if (browser.Location.AbsoluteUri == "https://www.google.com/searchbyimage/upload")
            {
                Assert.Fail("Unable to find file");
            }

            Assert.IsTrue(images.hasLeftImagesHome());
        }

        [TestFixtureTearDown]
        public void destroy()
        {
            browser.Dispose();
        }
    }
}