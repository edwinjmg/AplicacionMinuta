using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class EditarProductoModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioProducto _repoProducto;
        [BindProperty]
        public Aplicacion.Dominio.Entidades.Producto ProductoDetalle{get;set;}
        public EditarProductoModel()
        {
            this._repoProducto = new Aplicacion.Persistencia.AppRepositorios.RepositorioProducto(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        }
        public IActionResult OnGet(int? productoId)
        {
            if(productoId.HasValue){
                ProductoDetalle = _repoProducto.MostrarProducto(productoId.Value);
            }else{
                ProductoDetalle = new Aplicacion.Dominio.Entidades.Producto();
                }     
            if(ProductoDetalle == null){
                return RedirectToPage("../Index");
            }else
                return Page();
        } 
        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }

            if(ProductoDetalle.Id > 0){
                ProductoDetalle=_repoProducto.ActualizarProducto(ProductoDetalle);
            }else{
                _repoProducto.AgregarProducto(ProductoDetalle);
            }
            
            return RedirectToPage("./ListaProducto");
        }
    }
}
