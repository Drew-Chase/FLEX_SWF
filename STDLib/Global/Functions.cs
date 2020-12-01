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
            string manifest = Path.Combine(Values.ConfigDirectory, "Manfest.cfg");
            DisposeASS(manifest);
            GameFiles.Singleton.Clear();
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(Values.GistURL, manifest);
                client.Dispose();
            }
            ConfigManager manager = new ConfigManager(manifest);
            manager.List().ForEach((n) => GameFiles.Singleton.Add(new Objects.GameFile() { Name = n.Key, SWFUrl = n.Value }));
            DisposeASS(manifest);
        }

        static void DisposeASS(string manifest)
        {
            DisposeASS(manifest, 0);
        }

        static void DisposeASS(string manifest, int attempt)
        {
            if (attempt > 10) return;
            try
            {
                if (File.Exists(manifest)) File.Delete(manifest);
            }
            catch
            {
                Console.WriteLine($"Attempt #{attempt} Failed");
                DisposeASS(manifest, attempt++);
            }
        }
    }
}
