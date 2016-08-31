using Coypu;
using System;
using System.Threading;

namespace GoogleAutomation
{
    class Objects
    {
        BrowserSession browser;
        public ElementScope element;
        string partial;
        bool more;

        public enum RefType
        {
            Id,
            Xpath,
            Frame,
            Link,
            Field
        }

        public Objects(BrowserSession browser, RefType refType, string value, string partial = "", bool more = false)
                                            // 'partial' & 'more' only used in certain objects, so are optional params
        {
            this.browser = browser;
            this.partial = partial;
            this.more = more;

            switch (refType)
            {
                case RefType.Id:
                    element = browser.FindId(value, Options.First);
                    break;
                case RefType.Xpath:
                    element = browser.FindXPath(value, Options.First);
                    break;
                case RefType.Frame:
                    element = browser.FindFrame(value, Options.First);
                    break;
                case RefType.Link:
                    element = browser.FindLink(value, Options.First);
                    break;
                case RefType.Field:
                    element = browser.FindField(value, Options.First);
                    break;
                default:
                    throw new MissingHtmlException("");
            }
        }
        
        public void Click()
        {
            if (more)
            {
                browser.ClickLink("More");    // only used for header sub-options
                Thread.Sleep(1000);
            }
            element.Click();
            
            Thread.Sleep(1500);
        }

        public void FillText(string text)
        {
            element.FillInWith(text);
        }
        
        public void Select(string option)
        {
            element.Select(option);
        }

        public bool Exists()
        {
            return element.Exists();
        }

        public bool ContainsPartial()
        {
            return browser.Location.AbsoluteUri.Contains(partial);
        }
    }
}
