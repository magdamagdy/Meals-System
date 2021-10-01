using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication2.Data;
using WebApplication2.Data.Models;

namespace WebApplication2.Services.View_Models.Data
{
    public class MealAccessor:Repository<Meals>
    {
        public MealAccessor(WebApplication2.Data.AppContext context) : base(context)
        {
        }
        //Extra Func to select meal from list
        public List<SelectListItem> Create_list() //Return ViewBag 
        {
            return AsQueryable().Select(r => new SelectListItem { Value = r.ID.ToString(), Text = r.Type}).ToList();
        }


        // get whole list 
        public IEnumerable<MealViewModel> Get()
        {
            return AsQueryable().Select(s => new MealViewModel
            {
                ID = s.ID,
                Type =s.Type,
                Name =s.Name,
                ImageUrl=s.ImageUrl,
                Components=s.Components
            });
        }
        // get details of only one Meal
        public MealViewModel Get(int id)
        {
            return AsQueryable().Where(w => w.ID == id).Select(s => new MealViewModel
            {
                ID = s.ID,
                Type = s.Type,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                Components = s.Components

            }).FirstOrDefault();
        }

        public void Add(MealViewModel model)
        {
            var newmodel = new Meals
            {
                ID = model.ID,
                Type = model.Type,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Components = model.Components
            };
            Insert(newmodel);
        }
        public void Edit(MealViewModel model)
        {
            var newmodel = new Meals
            {
                ID = model.ID,
                Type = model.Type,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Components = model.Components
            };
            Update(newmodel);
        }

        public void Delete(int id)
        {
            var model = AsQueryable().Where(w => w.ID == id).FirstOrDefault();
            if (model != null)
                base.Delete(model);
        }
    }
}
