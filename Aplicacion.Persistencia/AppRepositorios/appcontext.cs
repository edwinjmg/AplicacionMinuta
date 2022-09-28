using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public class appcontext: DbContext
    {
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Vehiculo> Vehiculos{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Aplicacion.Data");

            }
        }
    }
}