using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data.Models
{
    public class Meals
    {
        public Meals ()
        {
            orders = new HashSet<Order>();
        }
        public int ID { get; set; }
        public string Type { get; set; } 
        public string Name { get; set; }
        public string Components { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
