using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScooterApplication.Models;

namespace ScooterApplication.Controllers
{
    public class ScooterController : Controller
    {
        // GET: Scooter
        [HttpGet]
        public ActionResult Index()
        {
            return View("ScooterWheelLife");
        }

        [HttpPost]
        public ActionResult Calculate(ScooterWheelLife model)
        {
            if (ModelState.IsValid)
            {
                //int totalLife = model.Wheel1 + model.Wheel2 + model.Spare;
                //model.MaxDistance = Math.Min(model.Wheel1, Math.Min(model.Wheel2, model.Spare));
                //model.MaxDistance = (double)totalLife * 2 / 3;
                int[] tires = { model.Wheel1, model.Wheel2, model.Spare }; // Example lifecycles

                double totalLifecycle = tires.Sum();   // Sum of all tire lifecycles
                //var test = totalLifecycle / 2;
                model.MaxDistance = totalLifecycle / 2;
            }
            return View("ScooterWheelLife", model);
        }
    }
}