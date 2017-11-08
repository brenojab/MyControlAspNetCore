using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyControlAspNetCore.Models;

namespace MyControlAspNetCore.Models
{
    public class MyControlAspNetCoreContext : DbContext
    {
        public MyControlAspNetCoreContext (DbContextOptions<MyControlAspNetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<MyControlAspNetCore.Models.Usuario> Usuario { get; set; }

        public DbSet<MyControlAspNetCore.Models.TipoRegistro> TipoRegistro { get; set; }

        public DbSet<MyControlAspNetCore.Models.Registro> Registro { get; set; }
    }
}
