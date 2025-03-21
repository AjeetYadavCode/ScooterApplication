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

                if(model.Wheel1 ==0 && model.Wheel2 == 0)
                {
                    model.MaxDistance = 0;
                    return View("ScooterWheelLife", model);
                }
                double[] tires = { model.Wheel1, model.Wheel2, (double)model.Spare }; // Example lifecycles
                Array.Sort(tires);
                double total = 0;
                var firstPart = tires[0] / 2;
                total += firstPart;
                tires[0] = tires[0] - firstPart;
                tires[1] = tires[1] - firstPart;
                //----------------------------------------
                tires[2] = tires[2] - tires[1];
                total += tires[1];
                //--------------
                total += Math.Min(tires[0], tires[2]);

                model.MaxDistance = total;
                //int[] tires = { model.Wheel1, model.Wheel2, model.Spare ?? 0 }; // Example lifecycles

                //double totalLifecycle = tires.Sum();   // Sum of all tire lifecycles
                ////var test = totalLifecycle / 2;
                //model.MaxDistance = totalLifecycle / 2;
            }
            return View("ScooterWheelLife", model);
        }
    }
}