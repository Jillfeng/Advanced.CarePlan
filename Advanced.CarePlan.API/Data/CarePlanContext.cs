using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advanced.CarePlan.API.Models;

namespace Advanced.CarePlan.API.Data
{
    public class CarePlanContext : DbContext
    {
        public CarePlanContext (DbContextOptions<CarePlanContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarePlan> CarePlan { get; set; }
    }
}
