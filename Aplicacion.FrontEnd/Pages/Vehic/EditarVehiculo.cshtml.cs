using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class EditarVehiculoModel : PageModel
    {
       private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioVehiculo _repoVehiculo;
        [BindProperty]
        public Aplicacion.Dominio.Entidades.Vehiculo VehiculoDetalle{get;set;}
        public EditarVehiculoModel()
        {
            this._repoVehiculo = new Aplicacion.Persistencia.AppRepositorios.RepositorioVehiculo(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        }
        public IActionResult OnGet(int? vehiculoId)
        {
            if(vehiculoId.HasValue){
                VehiculoDetalle = _repoVehiculo.MostrarVehiculo(vehiculoId.Value);
            }else{
                VehiculoDetalle = new Aplicacion.Dominio.Entidades.Vehiculo();
                }     
            if(VehiculoDetalle == null){
                return RedirectToPage("../Index");
            }else
                return Page();
        } 
        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }

            if(VehiculoDetalle.Id > 0){
                VehiculoDetalle=_repoVehiculo.ActualizarVehiculo(VehiculoDetalle);
            }else{
                _repoVehiculo.AgregarVehiculo(VehiculoDetalle);
            }
            
            return RedirectToPage("./ListaVehiculo");
        }
    }
}
