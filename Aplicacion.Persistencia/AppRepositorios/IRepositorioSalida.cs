using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public interface IRepositorioSalida
    {
        Aplicacion.Dominio.Entidades.Salida AgregarSalida(Salida salid,int IdVehiculo, int IdConductor,int IdProducto);
        IEnumerable<Salida> MostrarSalidas();
        Aplicacion.Dominio.Entidades.Salida MostrarSalida(int Id);
    }
}