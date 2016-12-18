using Infra;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExample
{
    public class SearchFrame : BasePage
    {
        public static By SEARCH_BAR_CONTAINER = By.Id("gs_lc0");
        public static By TEXT = By.Name("q");
        private IWebElement _rootElement;
        private WebDriverWait _wait;

        public SearchFrame(BaseBrowser browser)
        {
            _browser = browser;
            _wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(10));
            _wait.Until(ExpectedConditions.ElementIsVisible(SEARCH_BAR_CONTAINER));
            _rootElement = browser.Driver.FindElement(SEARCH_BAR_CONTAINER);
        }

        public SearchResultsPage Search(string query)
        {
            _rootElement.FindElement(TEXT).SendKeys(query);
            _rootElement.Submit();
            
            return new SearchResultsPage(_browser);
        }
    }
}
