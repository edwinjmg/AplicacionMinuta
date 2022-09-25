using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class DetalleConductorModel : PageModel
    {
        private static Aplicacion.Persistencia.AppRepositorios.IRepositorioConductor _repoConductor = new Aplicacion.Persistencia.AppRepositorios.RepositorioConductor(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public Conductor ConductorDetalle { get; set; }

        public IActionResult OnGet(int conductorId)
        {
            ConductorDetalle = _repoConductor.MostrarConductor(conductorId); //repositorio.GetSaludoId(saludoID);
            if (ConductorDetalle == null)
            {
                return RedirectToPage("./Lista");
            }
            else
                return Page();
        }

    }
}
