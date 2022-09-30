using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public interface IRepositorioEntrada
    {
        Aplicacion.Dominio.Entidades.Entrada AgregarEntrada(Entrada entrad,int IdVehiculo, int IdConductor,int IdProducto);
        IEnumerable<Entrada> MostrarEntradas();
        Aplicacion.Dominio.Entidades.Entrada MostrarEntrada(int Id);
    }
}