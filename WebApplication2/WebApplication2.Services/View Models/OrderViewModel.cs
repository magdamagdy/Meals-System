using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Services.View_Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        public DateTime Date { get; set; } //to be ckecked

        public bool Claimed { get; set; }

        public int MealId { get; set; }
        
        public string UserId { get; set; }
        
        public string MealName { get; set; }
        
        //public string QR { get; set; }
    }
}
