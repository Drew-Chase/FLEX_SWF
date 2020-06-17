using ChaseLabs.CLConfiguration.List;
using ChaseLabs.Games.SWF.STDLib.Lists;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ChaseLabs.Games.SWF.STDLib.Global
{
    public class Functions
    {
        public static GameFiles GrabAss()
        {
            var value = new GameFiles();
            string manifest = Path.Combine(Values.ConfigDirectory, "Manfest.cfg");
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(Values.GistURL, manifest);
                client.Dispose();
            }
            ConfigManager manager = new ConfigManager(manifest);
            manager.List().ForEach((n) => value.Add(new Objects.GameFile() { Name = n.Key, SWFUrl = n.Value }));
            return value;
        }
    }
}
