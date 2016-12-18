using Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;

namespace UnitTestProject1
{
    public abstract class BaseTestClass
    {
        protected BaseBrowser _browser;
        protected DriverParameters _driverParameters;
        protected string _startUrl;
        protected string _playbuzzPlatfromType;
        protected Configuration _appConfig;

        private TestContext _testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }




            [TestInitialize]
        public void Init()
        {    
            _driverParameters = new DriverParameters();
            _driverParameters.BrowserName = _testContextInstance.Properties["browserName"].ToString();
            _driverParameters.PlatformDesktop = _testContextInstance.Properties["platform"].ToString();

            _appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            _driverParameters.SeleniumHub= _appConfig.AppSettings.Settings["Hub"].Value;


            _browser = new BaseBrowser(_driverParameters);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _browser.CleanUpDriver();

        }
    }
}
