using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class DetalleProductoModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioProducto _repoProducto = new Aplicacion.Persistencia.AppRepositorios.RepositorioProducto(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public Producto ProductoDetalle { get; set; }

        public IActionResult OnGet(int productoId)
        {
            ProductoDetalle = _repoProducto.MostrarProducto(productoId); //repositorio.GetSaludoId(saludoID);
            if (ProductoDetalle == null)
            {
                return RedirectToPage("./ListaProducto");
            }
            else
                return Page();
        }
    }
}
