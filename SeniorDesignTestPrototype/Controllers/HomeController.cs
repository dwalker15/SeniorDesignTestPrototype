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
            List<PrototypeModel> modelList = new List<PrototypeModel>();
            using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
            {
                IQueryable<TPrototype> prototypes = db.TPrototype.Where(x => true);

                foreach (var prototype in prototypes)
                {
                    PrototypeModel model = new PrototypeModel
                    {
                        dataCollection = prototype.VcDataCollection,
                        posture = prototype.VcPosture,
                        torqueType = prototype.VcTorqueType
                    };
                    modelList.Add(model);
                }
            }
            return View(modelList);
        }

        public IActionResult Create()
        {
            PrototypeModel model = new PrototypeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PrototypeModel model)
        {
            using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
            {
                TPrototype prototype = new TPrototype
                {
                    VcTorqueType = model.torqueType,
                    VcPosture = model.posture,
                    VcDataCollection = model.dataCollection
                };

                db.Add(prototype);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
