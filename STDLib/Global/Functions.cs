using ChaseLabs.CLConfiguration.List;
using ChaseLabs.Games.SWF.STDLib.Lists;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChaseLabs.Games.SWF.STDLib.Global
{
    public class Functions
    {

        public static void GrabAssAsync()
        {
            Task.Run(() => GrabAss());
        }

        public static void GrabAss()
        {
            GameFiles.Singleton.Clear();
            string manifest = Path.Combine(Values.ConfigDirectory, "Manfest.cfg");
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(Values.GistURL, manifest);
                client.Dispose();
            }
            ConfigManager manager = new ConfigManager(manifest);
            manager.List().ForEach((n) => GameFiles.Singleton.Add(new Objects.GameFile() { Name = n.Key, SWFUrl = n.Value }));
            if (File.Exists(manifest)) File.Delete(manifest);
        }
    }
}
