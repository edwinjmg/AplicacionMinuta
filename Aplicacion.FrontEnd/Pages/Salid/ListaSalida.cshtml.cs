using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
        public class ListaSalidaModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioSalida _repoSalida= new Aplicacion.Persistencia.AppRepositorios.RepositorioSalida(new Aplicacion.Persistencia.AppRepositorios.appcontext());

        [BindProperty]
        public IEnumerable<Salida> salid{get;set;}
        
        public void OnGet()
        {
            salid=_repoSalida.MostrarSalidas();
        }
    }
    
}
