using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public class RepositorioVehiculo:IRepositorioVehiculo
    {
        public readonly Aplicacion.Persistencia.AppRepositorios.appcontext appcox;
        public RepositorioVehiculo(Aplicacion.Persistencia.AppRepositorios.appcontext appContext)
        {
            appcox = appContext;
        }
        public Aplicacion.Dominio.Entidades.Vehiculo AgregarVehiculo(Aplicacion.Dominio.Entidades.Vehiculo Vehiculo)
        {
            var VehiculoNuevo = appcox.Vehiculos.Add(Vehiculo);
            appcox.SaveChanges();
            return VehiculoNuevo.Entity;
        }
        public IEnumerable<Vehiculo> MostrarVehiculos()
        {
            return appcox.Vehiculos;
        }
        public Vehiculo MostrarVehiculo(int Id)
        {
            return appcox.Vehiculos.FirstOrDefault(a => a.Id == Id);
        }
        public Vehiculo ActualizarVehiculo(Vehiculo Vehic)
        {
            var VehiculoModificado = appcox.Vehiculos.FirstOrDefault(s => s.Id == Vehic.Id);
            if (VehiculoModificado != null)
            {
                VehiculoModificado.Placa = Vehic.Placa;
                VehiculoModificado.Modelo = Vehic.Modelo;
                VehiculoModificado.Color = Vehic.Color;
                }
            appcox.SaveChanges();
            return VehiculoModificado;
        }
        /* public void EliminarVehiculo(int Id)
        {
            var VehiculoEncontrado = appcox.Vehiculos.FirstOrDefault(a => a.Id == Id);
            if (VehiculoEncontrado == null)
                return;
            appcox.Vehiculos.Remove(VehiculoEncontrado);
            appcox.SaveChanges();
        }  */
    }
}