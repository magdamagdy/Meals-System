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
   
    public class OrderController : Controller
    {
        UnitOfWork unitOfWork;
        public OrderController(AppContext db)
        {
            unitOfWork = new UnitOfWork(db);
        }
        public IActionResult Index()
        {
            var model = unitOfWork.Order.Get();
            return View(model);
        }

        
        public IActionResult Create()
        {
            ViewBag.Meal_order = unitOfWork.Meals.Create_list();

            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            unitOfWork.Order.Add(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Meal_order = unitOfWork.Meals.Create_list();

            var model = unitOfWork.Order.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(OrderViewModel model)
        {
            unitOfWork.Order.Edit(model);
            unitOfWork.Commit();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var model = unitOfWork.Order.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(OrderViewModel model)
        {
            unitOfWork.Order.Delete(model.ID);
            unitOfWork.Commit();
            return RedirectToAction("Index");

        }
        //public IActionResult Details(int id)
        //{
        //    var model = unitOfWork.Order.Get(id);
        //    return View(model);
        //}

    }
}
