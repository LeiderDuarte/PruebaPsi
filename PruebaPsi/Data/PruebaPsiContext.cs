using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaPsi.Models;

namespace PruebaPsi.Data
{
    public class PruebaPsiContext : DbContext
    {
        public PruebaPsiContext (DbContextOptions<PruebaPsiContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaPsi.Models.Usuarios> Usuarios { get; set; }
    }
}
