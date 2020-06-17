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
        public static string ConfigFileName => "Settings.cfg";
        public static string ConfigFilePath => Path.Combine(ConfigDirectory, ConfigFileName);
        public static string ConfigDirectory
        {
            get
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyName.Replace(" ", "_"), ApplicationName.Replace(" ", "_"));
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }


        public static string GistURL => "https://gist.githubusercontent.com/DcmanProductions/b0cdbacbe543f41aa337adb0ed4533f6/raw/a3b837180ea9217acc63922d0cbb479f72c98519/Compiled%2520Flash%2520Game%2520Archive.conf";
    }
}
