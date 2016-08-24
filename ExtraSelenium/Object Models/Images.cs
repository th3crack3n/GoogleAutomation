using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Images
    {
        private BrowserSession browser;

        public Images(BrowserSession browser)
        {
            this.browser = browser;
        }


        public bool hasLeftImagesHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/images");
        }

        public string getURL()
        {
            return browser.Location.ToString();
        }

        public bool searchByImageOpen()
        {
            return browser.FindId("qbp").Exists();
        }

        public bool uploadImageOpen()
        {
            return browser.FindId("qbp").Exists();
        }

        public bool pasteImageURLOpen()
        {
            return browser.FindXPath("//td[@id='qbbtc']/input").Exists();
        }

        public void typeAndReturnSearchBar(string text)
        {
            browser.FillIn("lst-ib").With("xpanxion");
            browser.ClickButton("btnG");
        }

        public void clickSearchByImage()
        {
            browser.FindId("qbi").Click();
        }

        public void toggleUploadImage()
        {
            if (browser.FindId("qbug").Exists())
            {
                browser.ClickLink("Upload an image");
            }
        }

        public void togglePasteImageURL()
        {
            if (browser.FindId("qbig").Exists())
            {
                browser.ClickLink("Paste image URL");
            }
        }

        public void typeInImageURL(string url)
        {
            browser.FillIn("qbui").With(url);
        }

        public void clickSearchByImagePost()
        {
            browser.FindXPath("//input[@id='qbui']").Click();
        }

        public void uploadImageLocation(string path)
        {
            browser.FillIn("encoded_image").With(path);
        }

        public void uploadImage(string path)
        {
            clickSearchByImage();
            toggleUploadImage();
            uploadImageLocation(path);
        }

    }
}