using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public interface IRepositorioConductor
    {
        Aplicacion.Dominio.Entidades.Conductor AgregarConductor(Conductor condu);
        IEnumerable<Conductor> MostrarConductores();
        IEnumerable<Conductor> MostrarConductoresFiltro(string filtro);
        Aplicacion.Dominio.Entidades.Conductor MostrarConductor(int Id);
        Aplicacion.Dominio.Entidades.Conductor ActualizarConductor(Conductor ConducAct);
        //void EliminarConductor(int Id);


    }
}