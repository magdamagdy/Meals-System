using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication2.Data.Models
{
    public class Order
    { 
        public int ID { get; set; }
        
        public DateTime Date { get; set; } //to be ckecked

        public bool Claimed { get; set; }

        public int MealId { get; set; }
        [ForeignKey("MealId")]
        public Meals meal { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

        //public string QR { get; set; }

    }
}
