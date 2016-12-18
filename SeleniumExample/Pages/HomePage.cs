using OpenQA.Selenium.Remote;
using Infra;

namespace SeleniumExample
{
    public class HomePage : BasePage
    {
        public SearchFrame SearchFrame { get; private set; }

        public HomePage(BaseBrowser browser)
        {
            _browser = browser;
            SearchFrame = new SearchFrame(_browser);
        }
        public HomePage(BaseBrowser driver, string url)
        {
            _browser = driver;
            _browser.Driver.Url=url;
            SearchFrame = new SearchFrame(_browser);
        }
    }
}