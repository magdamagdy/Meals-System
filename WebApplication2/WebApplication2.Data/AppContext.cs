using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Data.Models;

namespace WebApplication2.Data
{
    public class AppContext : IdentityDbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Meals>Meals {get;set;}
        public DbSet<Order>Orders {get;set;}

        
    }

}
