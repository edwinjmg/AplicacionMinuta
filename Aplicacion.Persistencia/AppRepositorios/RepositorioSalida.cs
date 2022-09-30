using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public class RepositorioSalida:IRepositorioSalida
    {
        public readonly Aplicacion.Persistencia.AppRepositorios.appcontext appcox;
        public RepositorioSalida(Aplicacion.Persistencia.AppRepositorios.appcontext appContext)
        {
            appcox = appContext;
        }
        public Aplicacion.Dominio.Entidades.Salida AgregarSalida(Aplicacion.Dominio.Entidades.Salida Salida,int IdVehiculo, int IdConductor,int IdProducto)
        {
            if (Salida != null)
            {
                var VehiculoEncontrado = appcox.Vehiculos.FirstOrDefault(m => m.Id == IdVehiculo);
                if (VehiculoEncontrado != null)
                {
                    Salida.Vehiculo = VehiculoEncontrado;
                }
                var ConductorEncontrado = appcox.Conductores.FirstOrDefault(m => m.Id == IdConductor);
                if (ConductorEncontrado != null)
                {
                    Salida.Conductor = ConductorEncontrado;
                }
                var ProductoEncontrado = appcox.Productos.FirstOrDefault(m => m.Id == IdProducto);
                if (ProductoEncontrado != null)
                {
                    Salida.Producto = ProductoEncontrado;
                }
            }
            var SalidaNuevo = appcox.Salidas.Add(Salida);
            appcox.SaveChanges();
            return SalidaNuevo.Entity;

        }
        public IEnumerable<Salida> MostrarSalidas()
        {
            return appcox.Salidas.Include("Vehiculo").Include("Conductor").Include("Producto");
        }
        public Salida MostrarSalida(int Id)
        {
            return appcox.Salidas.Include("Vehiculo").Include("Conductor").Include("Producto").FirstOrDefault(a => a.Id == Id);
        }
        
    }
}