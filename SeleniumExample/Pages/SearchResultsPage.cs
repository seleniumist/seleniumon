using OpenQA.Selenium.Remote;
using Infra;

namespace SeleniumExample
{
    public class SearchResultsPage : BasePage
    {
        public SearchFrame SearchFrame { get; private set; }
        public ResultsFrame ResultsFrame { get; private set; }

        public SearchResultsPage(BaseBrowser browser)
        {
            _browser = browser;
            ResultsFrame = new ResultsFrame(_browser);
            SearchFrame = new SearchFrame(_browser);
        }
    }
}