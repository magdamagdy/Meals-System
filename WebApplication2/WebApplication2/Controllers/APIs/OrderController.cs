using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Services;
using WebApplication2.Services.View_Models;
using AppContext = WebApplication2.Data.AppContext;

namespace WebApplication2.Controllers.APIs
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        UnitOfWork unitOfWork;
        public OrderController(AppContext db)
        {
            unitOfWork = new UnitOfWork(db);
        }

        
        public IEnumerable<OrderViewModel> Get()
        {
            return unitOfWork.Order.Get();
        }

        //[HttpPost]
        //public object Get2([FromBody]string id) //??? check input string
        //{
        //    Get3(id);
        //    return new { IsSuccess = true };
        //}
        [HttpPost]
        public IEnumerable<OrderViewModel> Get3(string id) //??? check input string
        {
            return unitOfWork.Order.Get(id);
        }

        [HttpPost]
        public object Add(OrderViewModel model)
        {
            unitOfWork.Order.Add(model);
            unitOfWork.Commit();
            return new { IsSuccess = true };
        }
        [HttpPost]
        public object Edit(OrderViewModel model)
        {
            unitOfWork.Order.Edit(model);
            unitOfWork.Commit();
            return new { IsSuccess = true };
        }

        public object Delete(int id)
        {
            unitOfWork.Order.Delete(id);
            unitOfWork.Commit();
            return new { IsSuccess = true };
        }


    }
}
