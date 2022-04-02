using LVP4_SportsPro2_start.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LVP4_SportsPro2_start.Controllers
/*************************************************************
* 
* Update the [HttpGet] List() method query options below
* 
**************************************************************/
{
    public class TechIncidentController : Controller
    {
        private SportsProUnit data { get; set; }

        public TechIncidentController(SportsProContext ctx)
        {
            data = new SportsProUnit(ctx);
        }

        [HttpGet]
        public IActionResult Get()
        {
            ViewBag.Technicians = data.Technicians.List(new QueryOptions<Technician>
            {
                OrderBy = c => c.Name
            });

            int techID = HttpContext.Session.GetInt32("techID") ?? 0;
            Technician technician;
            if (techID == 0)
            {
                technician = new Technician();
            }
            else
            {
                technician = data.Technicians.Get(techID);
            }

            return View(technician);
        }

        [HttpPost]
        public IActionResult List(Technician technician)
        {
            HttpContext.Session.SetInt32("techID", technician.TechnicianID);

            if (technician.TechnicianID == 0)
            {
                TempData["message"] = "You must select a technician.";
                return RedirectToAction("Get");
            }
            else
            {
                return RedirectToAction("List", new { id = technician.TechnicianID });
            }
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var model = new TechIncidentViewModel
            {
                Technician = data.Technicians.Get(id),

                Incidents = data.Incidents.List(new QueryOptions<Incident>
                {
                    /*************************************************
                     * 
                     * Update this code!!
                     * 
                     *************************************************/
                })
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int techID = HttpContext.Session.GetInt32("techID") ?? 0;
            var model = new TechIncidentViewModel
            {
                Technician = data.Technicians.Get(techID),

                Incident = data.Incidents.Get(new QueryOptions<Incident>
                {
                    Includes = "Customer, Product",
                    Where = i => i.IncidentID == id
                })
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel model)
        {
            Incident i = data.Incidents.Get(model.Incident.IncidentID);
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;

            data.Incidents.Update(i);
            data.Save();

            int techID = HttpContext.Session.GetInt32("techID") ?? 0;
            return RedirectToAction("List", new { id = techID });
        }

    }
}