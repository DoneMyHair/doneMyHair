using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdresser_App.Data
{
    public class DoneMyHairContext : IdentityDbContext
    {
        public DoneMyHairContext(DbContextOptions<DoneMyHairContext> options)
            : base(options)
        {

        }
        public DbSet<Saloon> Saloons { get; set; }

    }
}
