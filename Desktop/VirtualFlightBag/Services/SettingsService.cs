using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using VirtualFlightBag.Models;

namespace VirtualFlightBag.Services
{
    public class SettingsService
    {
        private readonly ILog log = LogManager.GetLogger("VirtualFlightBag");

        private string settingsFilePath;

        public SettingsService()
        {
        }

        public Settings GetSettings()
        {
            Settings settings = null;

            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var vfbUserDirectory = String.Format("{0}{1}VirtualFlightBag", myDocumentsPath, Path.DirectorySeparatorChar);

            if (!Directory.Exists(vfbUserDirectory))
            {
                Directory.CreateDirectory(vfbUserDirectory);
            }


            this.settingsFilePath = String.Format("{0}{1}VirtualFlightBag{2}settings.xml", myDocumentsPath,
                Path.DirectorySeparatorChar, Path.DirectorySeparatorChar);

            if (File.Exists(this.settingsFilePath))
            {
                // We have a settings.xml file so let's try to read it
                try
                {
                    using (var streamReader = new StreamReader(this.settingsFilePath))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                        settings = (Settings)serializer.Deserialize(streamReader);
                    }

                }
                catch (Exception ex)
                {
                    log.Error("Error parsing settings.xml");
                    log.Error(ex.Message);
                    if (ex.InnerException != null)
                    {
                        log.Error(ex.InnerException.Message);

                    }

                    // TODO show an error
                    //var messageBox = new CustomMessageBox("There was an error reading the AeroScenery settings.xml file.\n" +
                    //    "If this persists, you can delete the file and let AeroScenery recreate it.",
                    //    "AeroScenery",
                    //    MessageBoxIcon.Error);

                    //messageBox.ShowDialog();
                }

            }
            else
            {
                settings = new Settings();
            }

            // Any settings that are null will be set to their default value
            this.SetDefaultSettingsWhereNull(settings);
            this.SaveSettings(settings);

            return settings;
        }

        public void SaveSettings(Settings settings)
        {
            try
            {
                using (var streamWriter = new StreamWriter(this.settingsFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(streamWriter, settings);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error saving settings.xml");
                log.Error(ex.Message);
                if (ex.InnerException != null)
                {
                    log.Error(ex.InnerException.Message);

                }

                //var messageBox = new CustomMessageBox("There was an error reading the AeroScenery settings.xml file.\n" +
                //    "If this persists, you can delete the file and let AeroScenery recreate it.",
                //    "AeroScenery",
                //    MessageBoxIcon.Error);

                //messageBox.ShowDialog();
            }
        }

        public void LogSettings(Settings settings)
        {
            log.Info(String.Format("Port: {0}", settings.Port));
        }

        private void SetDefaultSettingsWhereNull(Settings settings)
        {
            log.Info("Setting default settings");

            if (settings.Port == null)
                settings.Port = 8142;

            if (settings.DocumentsDirectory == null)
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string vfbDocumentsPath = myDocumentsPath + @"\VirtualFlightBag\Documents\";

                if (!Directory.Exists(vfbDocumentsPath))
                {
                    Directory.CreateDirectory(vfbDocumentsPath);
                }

                settings.DocumentsDirectory = vfbDocumentsPath;
            }
        }

        public void CheckConfiguredDirectories(Settings settings)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(settings.DocumentsDirectory))
            {
                string vfbDocumentsPath = myDocumentsPath + @"\VirtualFlightBag\Documents\";

                if (!Directory.Exists(vfbDocumentsPath))
                {
                    Directory.CreateDirectory(vfbDocumentsPath);
                }

                settings.DocumentsDirectory = vfbDocumentsPath;

                //var messageBox = new CustomMessageBox("The configured AeroScenery database directory does not exist. It will be reset to " + aeroSceneryDBDirectoryPath + ".",
                //    "AeroScenery",
                //    MessageBoxIcon.Warning);

                //messageBox.ShowDialog();
            }

            this.SaveSettings(settings);
        }

    }
}
