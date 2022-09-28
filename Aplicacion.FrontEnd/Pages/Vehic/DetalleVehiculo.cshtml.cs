using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class DetalleVehiculoModel : PageModel
    {
       private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioVehiculo _repoVehiculo = new Aplicacion.Persistencia.AppRepositorios.RepositorioVehiculo(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public Vehiculo VehiculoDetalle { get; set; }

        public IActionResult OnGet(int vehiculoId)
        {
            VehiculoDetalle = _repoVehiculo.MostrarVehiculo(vehiculoId); //repositorio.GetSaludoId(saludoID);
            if (VehiculoDetalle == null)
            {
                return RedirectToPage("./Lista");
            }
            else
                return Page();
        }
    }
}
