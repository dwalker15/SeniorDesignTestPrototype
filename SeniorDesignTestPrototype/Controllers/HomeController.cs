using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeniorDesignTestPrototype.Models;

namespace SeniorDesignTestPrototype.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()

        {
            List<TNotes> d = null;
            using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
            {
                d = db.TNotes.ToList();
            }
            return View(d);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
