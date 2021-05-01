using Advanced.CarePlan.API.Data;
using Advanced.CarePlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced.CarePlan.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public HomeController(CarePlanContext db)
        {
            Db = db;
        }
        private CarePlanContext Db { get; }

        public ActionResult Index()
        {
            var model = new IndexViewModel(Db.CarePlan.ToList());
            return View(model);
        }

        public ActionResult DeleteCarePlan(int id)
        {
            var carePlan = Db.CarePlan.FirstOrDefault(x => x.CarePlanId == id);

            Db.Remove(carePlan);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetCarePlan (int id)
        {
            CarePlanViewModel model;
            var carePlan = Db.CarePlan.FirstOrDefault(x => x.CarePlanId == id);
            model = new CarePlanViewModel(carePlan);

            return View("CreateCarePlan", model);

        }
        [HttpPost]
        public JsonResult Create(CarePlanViewModel model)
        {
            if (model.Completed == true)
            {
                Validate(model);
            }
            var carePlan = new API.Models.CarePlan
            {
                CarePlanId = model.CarePlanId,
                Title = model.Title,
                PatientName = model.PatientName,
                UserName = model.UserName,
                ActualStartDate = model.ActualStartDate,
                TargetDate = model.TargetDate,
                Reason = model.Reason,
                Action = model.Action,
                Completed = model.Completed,
                EndDate = model.EndDate,
                OutCome = model.OutCome
            };
            if (ModelState.IsValid)
            {
                Db.CarePlan.Add(carePlan);
                Db.SaveChanges();
            }
            return Json(new { Success = true });

        }
        private void Validate(CarePlanViewModel model)
        {
            if (model.EndDate <= model.ActualStartDate)
            {
                ModelState.AddModelError("EndDate", $@"End Date error: Cannot before start date");
            }
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
