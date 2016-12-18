using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace Infra
{

    public class BaseBrowser
    {
        public RemoteWebDriver Driver;
        private DriverParameters _driverParameters;

        public BaseBrowser(DriverParameters driverParameters)
        {
            _driverParameters = driverParameters;
            Driver = DriverFactory.CreateDriver(driverParameters);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
        /// <summary>
        /// Switchs the browser tab to the given tab
        /// </summary>
        /// <param name="tabName"></param>
        public void SwitchTab(string tabName)
        {
            Driver.SwitchTo().Window(tabName);
        }

        /// <summary>
        /// Waits until there is a tab with the given title.
        /// </summary>
        /// <param name="title">Title to wait for (case sensetiv!)</param>
        /// <returns>Tab id, and switchs the driver.</returns>
        /// <exception cref="TimeOutException">If didn't got the tab in 45 seconds</exception>
        public string SwitchTabByTitle(string title)
        {
            string currentWindow = Driver.CurrentWindowHandle;
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            // Wait until facebook share page appers and switch to it
            wait.Until((d) =>
            {
                try
                {
                    foreach (string w in Driver.WindowHandles)
                    {
                        if (w != currentWindow)
                        {
                            Driver.SwitchTo().Window(w);
                            currentWindow = w;
                            if (Driver.Title.Contains(title))
                                return true;
                            else
                            {
                                Driver.SwitchTo().Window(currentWindow);
                            }

                        }
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            });

            return currentWindow;
        }
        /// <summary>
        /// switch tab by URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string SwitchTabByPartialURL(string url)
        {
            string currentWindow = Driver.CurrentWindowHandle;
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(45));
            wait.Until((d) =>
            {
                foreach (string w in Driver.WindowHandles)
                {
                    if (w != currentWindow)
                    {
                        Driver.SwitchTo().Window(w);
                        currentWindow = w;
                        if (Driver.Url.ToLower().Contains(url.ToLower()))
                            return true;
                        else
                        {
                            Driver.SwitchTo().Window(currentWindow);
                        }

                    }
                }
                return false;
            });

            return currentWindow;
        }

        public void MaximizeWindow()
        {
            try
            {
                Driver.Manage().Window.Maximize();
            }
            catch
            {
                //don't fail test on it
            }
        }
        /// <summary>
        /// switch to another tab that doesn't contain url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string SwitchTabNotContainsURL(string url)
        {
            string currentWindow = Driver.CurrentWindowHandle;
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(45));
            wait.Until((d) =>
            {
                foreach (string w in Driver.WindowHandles)
                {
                    if (w != currentWindow)
                    {
                        Driver.SwitchTo().Window(w);
                        currentWindow = w;
                        if (!Driver.Url.ToLower().Contains(url.ToLower()))
                            return true;
                        else
                        {
                            Driver.SwitchTo().Window(currentWindow);
                        }

                    }
                }
                return false;
            });

            return currentWindow;
        }

        /// <summary>
        /// go to main frame (is used mostly in embeded items to go between frames)
        /// </summary>
        public void GoToMainFrame()
        {
            Driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Close Driver after we finish test
        /// </summary>
        /// <param name="passed"></param>
        public void CleanUpDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public string GetCurrentURL()
        {
            return Driver.Url;
        }

        public string Navigate(string url)
        {
            return Driver.Url=url;
        }

        public void RefreshPage()
        {
            string url = Driver.Url;
            try
            {
                Driver.Navigate().Refresh();
                Driver.Navigate().GoToUrl(url);
            }
            catch
            {
                Driver.Navigate().GoToUrl(url);
            }
        }

    }
}