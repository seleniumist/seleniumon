using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class DriverParameters
    {
        public string BrowserName { get; set; }

        public string VersionDesktop { get; set; }

        public string PlatformDesktop { get; set; }

        public string DeviceOrientationMobile { get; set; }

        public string DeviceNameMobile { get; set; }


        public string PlatformVersionMobile { get; set; }

        public string PlatformNameMobile { get; set; }

        public string UDID { get; set; }

        /// <summary>
        /// Where to run the selenium hub:
        ///     loclaEmail_Host. pb-automation etc...
        /// </summary>
        /// 
        public string SeleniumHub { get; set; }


        public string IOSRealDeviceUrl { get; set; }

        public string RealDeviceUrl { get; set; }

        public List<string> TestCategorirs { get; set; }
    }
}
