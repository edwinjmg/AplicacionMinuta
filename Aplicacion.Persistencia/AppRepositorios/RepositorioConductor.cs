using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public class RepositorioConductor : IRepositorioConductor
    {
        public readonly Aplicacion.Persistencia.AppRepositorios.appcontext appcox;
        public RepositorioConductor(Aplicacion.Persistencia.AppRepositorios.appcontext appContext)
        {
            appcox = appContext;
        }
        public Aplicacion.Dominio.Entidades.Conductor AgregarConductor(Aplicacion.Dominio.Entidades.Conductor conductor)
        {
            var conductorNuevo = appcox.Conductores.Add(conductor);
            appcox.SaveChanges();
            return conductorNuevo.Entity;
        }
        public IEnumerable<Conductor> MostrarConductores()
        {
            return appcox.Conductores;
        }
        public IEnumerable<Conductor> MostrarConductoresFiltro(string filtro)
        {
            var conduc=MostrarConductores();
            if (conduc!=null)
            {
                if(!String.IsNullOrEmpty(filtro))
                {
                    conduc=conduc.Where(c=>c.Nombre.Contains(filtro));
                }
                
            }
            return conduc;
        }
        public Conductor MostrarConductor(int Id)
        {
            return appcox.Conductores.FirstOrDefault(a => a.Id == Id);
        }
        public Conductor ActualizarConductor(Conductor Conduct)
        {
            var ConductorModificado = appcox.Conductores.FirstOrDefault(s => s.Id == Conduct.Id);
            if (ConductorModificado != null)
            {
                ConductorModificado.Cedula = Conduct.Cedula;
                ConductorModificado.Nombre = Conduct.Nombre;
                ConductorModificado.Apellido = Conduct.Apellido;
                ConductorModificado.Celular = Conduct.Celular;
            }
            appcox.SaveChanges();
            return ConductorModificado;
        }
       /*  public void EliminarConductor(int Id)
        {
            var ConductorEncontrado = appcox.Conductores.FirstOrDefault(a => a.Id == Id);
            if (ConductorEncontrado == null)
                return;
            appcox.Conductores.Remove(ConductorEncontrado);
            appcox.SaveChanges();
        } */
    }
}