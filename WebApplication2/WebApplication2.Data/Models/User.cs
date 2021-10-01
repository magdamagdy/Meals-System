using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data.Models
{
    public class User:IdentityUser
    {
        public User()
        {
            orders = new HashSet<Order>();
        }
        public ICollection<Order> orders { get; set; }
    }
}
