using Infra;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumExample
{
    public class ResultsFrame : BasePage
    {
        public static By RESULTS_CONTAINER = By.Id("rcnt");
        private IWebElement _rootElement;
        private WebDriverWait _wait;

        public ResultsFrame(BaseBrowser browser)
        {
            _browser = browser;
            _wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(10));
            _wait.Until(ExpectedConditions.ElementIsVisible(RESULTS_CONTAINER));
            _rootElement = browser.Driver.FindElement(RESULTS_CONTAINER);
        }
    }
}