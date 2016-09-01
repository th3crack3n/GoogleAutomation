using Coypu;

namespace GoogleAutomation.Object_Models
{
    class Images
    {
        private BrowserSession _browser;

        public ObjectModel SearchByImage
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "qbi"); }
        }

        public ObjectModel SearchByImageOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "qbp"); }
        }

        public ObjectModel UploadAnImage
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "Upload an image"); }
        }

        public ObjectModel UploadAnImageOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "qbp"); }
        }

        public ObjectModel PasteImageUrl
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Link, "Paste image URL"); }
        }

        public ObjectModel PasteImageUrlOpen
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//td[@id='qbbtc']/input"); }
        }

        public ObjectModel SearchBar
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "lst-ib"); }
        }

        public ObjectModel SearchIcon
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//div[@id='sblsbb']/button"); }
        }

        public ObjectModel TypeImageUrl
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "qbui"); }
        }

        public ObjectModel SearchByImagePost
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Xpath, "//input[@id='qbui']"); }
        }

        public ObjectModel ImageUrl
        {
            get { return new ObjectModel(_browser, ObjectModel.RefType.Id, "qbfile"); }
        }

        public Images(BrowserSession browser)
        {
            _browser = browser;
        }

        public bool hasLeftImagesHome()
        {
            return !string.Equals(_browser.Location, "https://www.google.com/images");
        }
    }
}