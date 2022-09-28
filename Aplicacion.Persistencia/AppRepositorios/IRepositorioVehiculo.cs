using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public interface IRepositorioVehiculo
    {
        Aplicacion.Dominio.Entidades.Vehiculo AgregarVehiculo(Vehiculo vehic);
        IEnumerable<Vehiculo> MostrarVehiculos();
        Aplicacion.Dominio.Entidades.Vehiculo MostrarVehiculo(int Id);
        Aplicacion.Dominio.Entidades.Vehiculo ActualizarVehiculo(Vehiculo VehicAct);
    }
}