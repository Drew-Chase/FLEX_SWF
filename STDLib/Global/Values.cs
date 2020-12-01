using ChaseLabs.Games.SWF.STDLib.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChaseLabs.Games.SWF.STDLib.Global
{
    public static class Values
    {
        public static string ApplicationName => "Flex SWF";
        public static string CompanyName => "Chase Labs";
        public static string CoAuthor => "Nick Jackson";
        public static string CompanyURL => "https://drewchaseproject.com";
        public static string ConfigFileName => "Settings.cfg";
        public static string ConfigFilePath => Path.Combine(ConfigDirectory, ConfigFileName);

        public static int Port { get { return ConfigurationHandler.Singleton.manager.GetConfigByKey("Web UI Port").ParseInt(); } set { ConfigurationHandler.Singleton.manager.GetConfigByKey("Web UI Port").Value = "" + value; } }

        public static string ConfigDirectory
        {
            get
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyName.Replace(" ", "_"), ApplicationName.Replace(" ", "_"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine($"Creating Directory => {path}");
                }
                return path;
            }
        }

        public static string GistURL => "https://gist.githubusercontent.com/Shroototem/61c54cf465479f4e437e537230f83dc0/raw/";
    }
}
