using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFlightBag.Api;
using VirtualFlightBag.Models;
using VirtualFlightBag.Services;

namespace VirtualFlightBag
{

    public class VirtualFlightBagManager
    {
        private static VirtualFlightBagManager virtualFlightBagManager;
        private VFBWebServer vfbWebServer;

        private SettingsService settingsService;
        private Settings settings;

        public VirtualFlightBagManager()
        {
            this.settingsService = new SettingsService();
        }

        public static VirtualFlightBagManager Instance
        {
            get
            {
                if (VirtualFlightBagManager.virtualFlightBagManager == null)
                {
                    virtualFlightBagManager = new VirtualFlightBagManager();
                }

                return virtualFlightBagManager;
            }
        }

        public void Initialize()
        {
            this.settings = this.settingsService.GetSettings();
            this.settingsService.CheckConfiguredDirectories(this.settings);

            // Start the web server
            this.vfbWebServer = new VFBWebServer();
            this.vfbWebServer.StartWebServer();

            //var pdf = PdfDocument.Load(@"C:\Temp\EGFF.pdf");
        }

    }
}
