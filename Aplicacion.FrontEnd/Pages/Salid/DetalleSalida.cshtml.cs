using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class DetalleSalidaModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioSalida _repoSalida = new Aplicacion.Persistencia.AppRepositorios.RepositorioSalida(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public Salida SalidaDetalle { get; set; }

        public IActionResult OnGet(int salidaId)
        {
            SalidaDetalle = _repoSalida.MostrarSalida(salidaId); //repositorio.GetSaludoId(saludoID);
            if (SalidaDetalle == null)
            {
                return RedirectToPage("./ListaSalida");
            }
            else
                return Page();
        }
    }
}
