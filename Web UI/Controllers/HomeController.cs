using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChaseLabs.Games.SWF.STDLib.Global;
using ChaseLabs.Games.SWF.STDLib.Lists;
using ChaseLabs.Games.SWF.STDLib.Objects;
using ChaseLabs.Games.SWF.STDLib.Singleton.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_UI.Models;

namespace Web_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 0, int items=50)
        {
            ViewData["items_per_page"] = items;
            return View(page);
        }

        public IActionResult Play(string name)
        {
            GameFile file = null;
            GameFiles.Singleton.ForEach((n) => { if (n.Name.Equals(name)) file = n; });
            if (file != null && SessionInformation.Singleton.IsSignedIn)
                return View(file);
            else if (!SessionInformation.Singleton.IsSignedIn)
                return Redirect("/Identity/Account/Login");
            return RedirectToAction("Index", 0);
        }

        public IActionResult Search(string querry, int page = 0)
        {
            ViewData["Querry"] = querry;
            List<GameFile> files = new List<GameFile>();
            GameFiles.Singleton.ForEach((n) => { if (n.Name.ToLower().Contains(querry.ToLower())) files.Add(n); });
            ViewData["Files"] = files;
            return View(page);
        }

        [HttpPost]
        public IActionResult TrySearch(Microsoft.AspNetCore.Http.IFormCollection form)
        {
            form.TryGetValue("searchBox", out Microsoft.Extensions.Primitives.StringValues values);
            string value = values[0];
            if (!string.IsNullOrEmpty(value))
            {

            }

            return Redirect($"Search?querry={value}");
        }

        public IActionResult RefreshDatabase()
        {
            Functions.GrabAss();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
