using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class DetalleEntradaModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioEntrada _repoEntrada = new Aplicacion.Persistencia.AppRepositorios.RepositorioEntrada(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public Entrada EntradaDetalle { get; set; }

        public IActionResult OnGet(int entradaId)
        {
            EntradaDetalle = _repoEntrada.MostrarEntrada(entradaId); //repositorio.GetSaludoId(saludoID);
            if (EntradaDetalle == null)
            {
                return RedirectToPage("./ListaEntrada");
            }
            else
                return Page();
        }
    }
}
