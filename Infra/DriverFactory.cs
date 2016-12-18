using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Drawing;
using System.Collections.Generic;
using OpenQA.Selenium.PhantomJS;


namespace Infra
{

    internal static class DriverFactory
    {
        private const string PHANTOM_NOT_SUPPORTED_CATEGORY_NAME = "NotSupportedPhantom";

        //TODO: return to version 1.5.2 for all devices after iOS issue will be fixed
        //const string APPIUM_VERSION = "1.5.2";
        /// <summary>
        /// Create selenium driver
        /// According to the given parameters decides if to create a desktop/ios/android driver
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="testName"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        internal static RemoteWebDriver CreateDriver(DriverParameters parameters)
        {
            RemoteWebDriver driver=null;
            DesiredCapabilities caps = new DesiredCapabilities();
            if (parameters.BrowserName == "Chrome")
            {
                driver = createChromeDriver(parameters.SeleniumHub);
            }
            else if (parameters.BrowserName == "PhantomJS")
            {
                driver = createPhantomJSDriver(parameters.SeleniumHub);
            }
            else if (parameters.BrowserName == "Firefox")
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.SetPreference("plugin.state.flash", 0);
                caps.SetCapability(FirefoxDriver.ProfileCapabilityName, profile);
            }
            else
            {
                caps.SetCapability(CapabilityType.BrowserName, parameters.BrowserName);
                caps.SetCapability(CapabilityType.Version, parameters.VersionDesktop);
                caps.SetCapability(CapabilityType.Platform, parameters.PlatformDesktop);
                caps.SetCapability(CapabilityType.IsJavaScriptEnabled, true);
                caps.SetCapability(CapabilityType.PageLoadStrategy, "eager");
                caps.SetCapability("idleTimeout", 300);
                return driver = new RemoteWebDriver(new Uri(parameters.SeleniumHub), caps, TimeSpan.FromSeconds(180));
            }
            return driver;
        }




        private static RemoteWebDriver createPhantomJSDriver(string seleniumHub)
        {
            RemoteWebDriver driver;
            PhantomJSOptions opt = new PhantomJSOptions();
            driver = new RemoteWebDriver(new Uri(seleniumHub), opt.ToCapabilities(), TimeSpan.FromSeconds(600));
            return driver;
        }

        private static RemoteWebDriver createChromeDriver(string seleniumHub)
        {
            RemoteWebDriver driver;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("test-type");
            DesiredCapabilities capabilities = (DesiredCapabilities)chromeOptions.ToCapabilities();
            capabilities.SetCapability(CapabilityType.PageLoadStrategy, "none");
            driver = new RemoteWebDriver(new Uri(seleniumHub), capabilities, TimeSpan.FromSeconds(600));
            return driver;
        }
    }
}
