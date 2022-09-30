using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class ListaProductoModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioProducto _repoProducto = new Aplicacion.Persistencia.AppRepositorios.RepositorioProducto(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        public IEnumerable<Producto> produc{get;set;}
        public void OnGet()
        {
            produc=_repoProducto.MostrarProductos();
        }
    }
}
