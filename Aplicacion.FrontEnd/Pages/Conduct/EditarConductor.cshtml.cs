using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
public class EditarConductorModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioConductor _repoConductor;
        //private readonly IRepositorioConductor repositorio;
        [BindProperty]
        public Aplicacion.Dominio.Entidades.Conductor ConductorDetalle{get;set;}
        /* public EditarConductorModel(IRepositorioConductor repositorio){
            this.repositorio = repositorio;
        } */
        public EditarConductorModel()
        {
            this._repoConductor = new Aplicacion.Persistencia.AppRepositorios.RepositorioConductor(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        }
        public IActionResult OnGet(int? conductorId)
        {
            if(conductorId.HasValue){
                ConductorDetalle = _repoConductor.MostrarConductor(conductorId.Value);
            }else{
                ConductorDetalle = new Aplicacion.Dominio.Entidades.Conductor();
                }//return Page();           
            if(ConductorDetalle == null){
                return RedirectToPage("../Index");
            }else
                return Page();
        } 
        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }

            if(ConductorDetalle.Id > 0){
                ConductorDetalle=_repoConductor.ActualizarConductor(ConductorDetalle);
                //return Page();
            }else{
                //repositorio.Add(saludoDetalle);
                _repoConductor.AgregarConductor(ConductorDetalle);
            }
            return Page();
        }
    }
}