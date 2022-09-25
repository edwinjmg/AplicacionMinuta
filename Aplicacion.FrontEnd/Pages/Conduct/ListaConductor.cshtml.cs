using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Persistencia.AppRepositorios;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.FrontEnd.Pages
{
    public class ListaConductorModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioConductor _repoConductor = new Aplicacion.Persistencia.AppRepositorios.RepositorioConductor(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public IEnumerable<Conductor> conduc{get;set;}
        public void OnGet()
        {
            conduc=_repoConductor.MostrarConductores();
        }
    }
}
