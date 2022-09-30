using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public class RepositorioEntrada:IRepositorioEntrada
    {
        public readonly Aplicacion.Persistencia.AppRepositorios.appcontext appcox;
        public RepositorioEntrada(Aplicacion.Persistencia.AppRepositorios.appcontext appContext)
        {
            appcox = appContext;
        }
        public Aplicacion.Dominio.Entidades.Entrada AgregarEntrada(Aplicacion.Dominio.Entidades.Entrada Entrada,int IdVehiculo, int IdConductor,int IdProducto)
        {
            //var EntradaNuevo = appcox.Entradas.Add(Entrada);
            //id=EntradaNuevo.Id;
            //var EntradaEncontrado = appcox.Entradas.FirstOrDefault(p => p.Id == id);
            if (Entrada != null)
            {
                var VehiculoEncontrado = appcox.Vehiculos.FirstOrDefault(m => m.Id == IdVehiculo);
                if (VehiculoEncontrado != null)
                {
                    Entrada.Vehiculo = VehiculoEncontrado;
                    //appcox.SaveChanges();
                }
                var ConductorEncontrado = appcox.Conductores.FirstOrDefault(m => m.Id == IdConductor);
                if (ConductorEncontrado != null)
                {
                    Entrada.Conductor = ConductorEncontrado;
                    //appcox.SaveChanges();
                }
                var ProductoEncontrado = appcox.Productos.FirstOrDefault(m => m.Id == IdProducto);
                if (ProductoEncontrado != null)
                {
                    Entrada.Producto = ProductoEncontrado;
                    //appcox.SaveChanges();
                }
            }
            var EntradaNuevo = appcox.Entradas.Add(Entrada);
            appcox.SaveChanges();
            return EntradaNuevo.Entity;
            //Console.WriteLine(Entrada.Vehiculo.Placa+" "+Entrada.Conductor.Nombre+" "+Entrada.Producto.Nombre);
            /* var EntradaNuevo=new Entrada();
            EntradaNuevo=Entrada;
            appcox.Database.OpenConnection();
    try
    {
        appcox.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Conductores ON");
        appcox.Add(Entrada);
        appcox.SaveChanges();
        appcox.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Conductores OFF");
    }
    finally
    {
        appcox.Database.CloseConnection();
    } */
            
        }
        public IEnumerable<Entrada> MostrarEntradas()
        {
            return appcox.Entradas.Include("Vehiculo").Include("Conductor").Include("Producto");
        }
        public Entrada MostrarEntrada(int Id)
        {
            return appcox.Entradas.Include("Vehiculo").Include("Conductor").Include("Producto").FirstOrDefault(a => a.Id == Id);
        }
        
    }
}