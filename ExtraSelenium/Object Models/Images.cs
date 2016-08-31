using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Images
    {
        private BrowserSession browser;

        public Objects SearchByImage
        {
            get { return new Objects(browser, Objects.RefType.Id, "qbi"); }
        }

        public Objects SearchByImageOpen
        {
            get { return new Objects(browser, Objects.RefType.Id, "qbp"); }
        }

        public Objects UploadAnImage
        {
            get { return new Objects(browser, Objects.RefType.Link, "Upload an image"); }
        }

        public Objects UploadAnImageOpen
        {
            get { return new Objects(browser, Objects.RefType.Id, "qbp"); }
        }

        public Objects PasteImageUrl
        {
            get { return new Objects(browser, Objects.RefType.Link, "Paste image URL"); }
        }

        public Objects PasteImageUrlOpen
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//td[@id='qbbtc']/input"); }
        }

        public Objects SearchBar
        {
            get { return new Objects(browser, Objects.RefType.Id, "lst-ib"); }
        }

        public Objects SearchIcon
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//div[@id='sblsbb']/button"); }
        }

        public Objects TypeImageUrl
        {
            get { return new Objects(browser, Objects.RefType.Id, "qbui"); }
        }

        public Objects SearchByImagePost
        {
            get { return new Objects(browser, Objects.RefType.Xpath, "//input[@id='qbui']"); }
        }

        public Objects ImageUrl
        {
            get { return new Objects(browser, Objects.RefType.Id, "qbfile"); }
        }

        public Images(BrowserSession browser)
        {
            this.browser = browser;
        }

        public bool hasLeftImagesHome()
        {
            return !string.Equals(browser.Location, "https://www.google.com/images");
        }

        public void togglePasteImageURL()
        {
            if (UploadAnImageOpen.Exists())
            {
                PasteImageUrl.Click();
            }
        }

        public void toggleUploadImage()
        {
            if (PasteImageUrlOpen.Exists())
            {
                UploadAnImage.Click();
            }
        }

        public void typeAndReturnSearchBar(string text)
        {
            SearchBar.FillText("xpanxion");
            SearchIcon.Click();
        }

        public void typeInImageURL(string url)
        {
            TypeImageUrl.FillText(url);
        }

        public void clickSearchByImagePost()
        {
            SearchByImagePost.Click();
        }

        public void uploadImageLocation(string path)
        {
            ImageUrl.FillText(path);
        }

        public void uploadImage(string path)
        {
            SearchByImage.Click();
            toggleUploadImage();
            ImageUrl.FillText(path);
        }

    }
}