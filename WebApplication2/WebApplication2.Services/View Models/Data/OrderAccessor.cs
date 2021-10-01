using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication2.Data;
using WebApplication2.Data.Models;

namespace WebApplication2.Services.View_Models.Data
{
    public class OrderAccessor:Repository<Order>
    {
        public OrderAccessor(WebApplication2.Data.AppContext context) : base(context)
        {
        }
        // get whole list 
        public IEnumerable<OrderViewModel> Get()
        {
            return AsQueryable().Select(s => new OrderViewModel
            {
                ID = s.ID,
                Date = s.Date,
                Claimed = s.Claimed,
                MealId = s.MealId,
                UserId = s.UserId,
                MealName = s.meal.Type
            });
        }
        // get details of only one trip
        public OrderViewModel Get(int id)
        {
            return AsQueryable().Where(w => w.ID == id).Select(s => new OrderViewModel
            {
                ID = s.ID,
                Date = s.Date,
                Claimed = s.Claimed,
                MealId = s.MealId,
                UserId = s.UserId,
                MealName = s.meal.Type

            }).FirstOrDefault();
        }

        // new func to return list of all orders of user 
        public IEnumerable<OrderViewModel> Get(String userid)
        {
            return AsQueryable().Where(w => w.UserId == userid).Select(s => new OrderViewModel
            {
                ID = s.ID,
                Date = s.Date,
                Claimed = s.Claimed,
                MealId = s.MealId,
                UserId = s.UserId,
                MealName = s.meal.Type

            });
        }

        public void Add(OrderViewModel model)
        {
            var newmodel = new Order
            {
                ID = model.ID,
                Date = model.Date,
                Claimed = model.Claimed,
                MealId = model.MealId,
                UserId = model.UserId,
               
            };
            Insert(newmodel);
        }
        public void Edit(OrderViewModel model)
        {
            var newmodel = new Order
            {
                ID = model.ID,
                Date = model.Date,
                Claimed = model.Claimed,
                MealId = model.MealId,
                UserId = model.UserId,
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
