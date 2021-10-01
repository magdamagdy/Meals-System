using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Services;
using WebApplication2.Services.View_Models;
using AppContext = WebApplication2.Data.AppContext;
namespace WebApplication2.Controllers
{
   
    public class MealController : Controller
    {
        UnitOfWork unitOfWork;
        public MealController(AppContext db)
        {
            unitOfWork = new UnitOfWork(db);
        }
        public IActionResult Meals()
        {
            var model = unitOfWork.Meals.Get();
            return View(model);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MealViewModel model)
        {
            unitOfWork.Meals.Add(model);
            unitOfWork.Commit();
            return RedirectToAction("Meals");
        }

        public IActionResult Edit(int id)
        {
            var model = unitOfWork.Meals.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(MealViewModel model)
        {
            unitOfWork.Meals.Edit(model);
            unitOfWork.Commit();
            return RedirectToAction("Meals");

        }
        public IActionResult Delete(int id)
        {
            var model = unitOfWork.Meals.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(MealViewModel model)
        {
            unitOfWork.Meals.Delete(model.ID);
            unitOfWork.Commit();
            return RedirectToAction("Meals");

        }
        public IActionResult Details(int id)
        {
            var model = unitOfWork.Meals.Get(id);
            return View(model);
        }

    }
}
