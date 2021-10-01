using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Data;
using WebApplication2.Services.View_Models.Data;
using AppContext = WebApplication2.Data.AppContext;

namespace WebApplication2.Services
{
    public class UnitOfWork
    {
        AppContext db;

        public UnitOfWork()
        {
        }

        public UnitOfWork(AppContext context)
        {
            db = context;
        }
        public OrderAccessor Order { get { return new OrderAccessor(db); } }
        public MealAccessor Meals { get { return new MealAccessor(db); } }
        public void  Commit()
        {
            db.SaveChanges();
        }
    }
}
