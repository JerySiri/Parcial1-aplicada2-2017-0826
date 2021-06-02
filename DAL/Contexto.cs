using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial1_aplicada2_2017_0826.Models;

namespace Parcial1_aplicada2_2017_0826.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Articulos.db");
        }
    }
}
