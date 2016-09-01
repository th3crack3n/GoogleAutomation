using Coypu;
using GoogleAutomation.Object_Models;
using NUnit.Framework;

namespace GoogleAutomation.Tests
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
            images.SearchBar.FillText("ames ia");
            images.SearchIcon.Click();

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
            images.SearchByImage.Click();

            if (images.PasteImageUrlOpen.Exists())
            {
                images.UploadAnImage.Click();

                Assert.IsTrue(images.UploadAnImageOpen.Exists());
            }

            if (images.UploadAnImageOpen.Exists())
            {
                images.PasteImageUrl.Click();

                Assert.IsTrue(images.PasteImageUrlOpen.Exists());
            }
        }

        [Test]
        public void searchByImageURL()
        {
            images.SearchByImage.Click();

            images.TypeImageUrl.FillText("http://xpanxion.com/images/black%20xpanxion-ust%20global%20group.png");
            images.SearchByImagePost.Click();

            Assert.IsTrue(images.hasLeftImagesHome());
        }

        [Test]
        public void searchByUpload()
        {
            images.SearchByImage.Click();

            if (images.PasteImageUrlOpen.Exists())
            {
                images.UploadAnImage.Click();
            }

            images.ImageUrl.FillText("C:\\Users\\Public\\Penguins.jpg");
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