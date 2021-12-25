using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HairDresser1.Models;

namespace HairDresser1.Data
{
    public class HairDresserDbContext : DbContext
    {
        public HairDresserDbContext (DbContextOptions<HairDresserDbContext> options)
            : base(options)
        {
        }

        public DbSet<Saloon> Saloon { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<HairDresser> HairDresser { get; set; }
    }
}
