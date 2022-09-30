using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class ListaEntradaModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioEntrada _repoEntrada= new Aplicacion.Persistencia.AppRepositorios.RepositorioEntrada(new Aplicacion.Persistencia.AppRepositorios.appcontext());

        [BindProperty]
        public IEnumerable<Entrada> entrad{get;set;}
        
        public void OnGet()
        {
            entrad=_repoEntrada.MostrarEntradas();
        }
    }
}
