using Coypu;
using System.Threading;

namespace GoogleAutomation
{
    class ObjectModel
    {
        BrowserSession _browser;
        public ElementScope element;
        string _partial;
        bool _more;

        public enum RefType {
            Id,
            Xpath,
            Frame,
            Link,
            Field
        }

        public ObjectModel(BrowserSession browser, RefType refType, string value, string partial = "", bool more = false)
                                            // 'partial' & 'more' only used in certain objects, so are optional params
        {
            _browser = browser;
            _partial = partial;
            _more = more;

            switch (refType)
            {
                case RefType.Id:
                    element = _browser.FindId(value, Options.First);
                    break;
                case RefType.Xpath:
                    element = _browser.FindXPath(value, Options.First);
                    break;
                case RefType.Frame:
                    element = _browser.FindFrame(value, Options.First);
                    break;
                case RefType.Link:
                    element = _browser.FindLink(value, Options.First);
                    break;
                case RefType.Field:
                    element = _browser.FindField(value, Options.First);
                    break;
                default:
                    throw new MissingHtmlException("RefType entered was not a valid RefType");
            }
        }
        
        public void Click()
        {
            if (_more)
            {
                _browser.ClickLink("More");    // only used for header sub-options
                Thread.Sleep(1000);
            }
            element.Click();
            
            Thread.Sleep(2000);
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
            return _browser.Location.AbsoluteUri.Contains(_partial);
        }
    }
}
