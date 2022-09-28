using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class ListaVehiculoModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioVehiculo _repoVehiculo = new Aplicacion.Persistencia.AppRepositorios.RepositorioVehiculo(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public IEnumerable<Vehiculo> vehic{get;set;}
        public void OnGet()
        {
            vehic=_repoVehiculo.MostrarVehiculos();
        }
    }
}
