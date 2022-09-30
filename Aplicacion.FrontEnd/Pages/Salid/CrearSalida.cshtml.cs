using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia.AppRepositorios;

namespace Aplicacion.FrontEnd.Pages
{
    public class CrearSalidaModel : PageModel
    {
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioSalida _repoSalida= new Aplicacion.Persistencia.AppRepositorios.RepositorioSalida(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioVehiculo _repoVehiculo= new Aplicacion.Persistencia.AppRepositorios.RepositorioVehiculo(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioConductor _repoConductor = new Aplicacion.Persistencia.AppRepositorios.RepositorioConductor(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        private readonly Aplicacion.Persistencia.AppRepositorios.IRepositorioProducto _repoProducto = new Aplicacion.Persistencia.AppRepositorios.RepositorioProducto(new Aplicacion.Persistencia.AppRepositorios.appcontext());
        [BindProperty]
        public Aplicacion.Dominio.Entidades.Salida SalidaDetalle{get;set;}
        public Aplicacion.Dominio.Entidades.Vehiculo VehiculoDetalle{get;set;}
        public Aplicacion.Dominio.Entidades.Conductor ConductorDetalle{get;set;}
        public Aplicacion.Dominio.Entidades.Producto ProductoDetalle{get;set;}

        public IEnumerable<Vehiculo> vehic{get;set;}
        public IEnumerable<Conductor> conduc{get;set;}
        public IEnumerable<Producto> produc{get;set;}

        public IActionResult OnGet()
        {
            vehic=_repoVehiculo.MostrarVehiculos();
            conduc=_repoConductor.MostrarConductores();
            produc=_repoProducto.MostrarProductos();
            SalidaDetalle = new Aplicacion.Dominio.Entidades.Salida();
            VehiculoDetalle = new Aplicacion.Dominio.Entidades.Vehiculo();
            ConductorDetalle = new Aplicacion.Dominio.Entidades.Conductor();
            ProductoDetalle = new Aplicacion.Dominio.Entidades.Producto();

            return Page();
        } 
        public IActionResult OnPost(int vehiculoId, int conductorId, int productoId){
            if(ModelState.IsValid){
                /* VehiculoDetalle=_repoVehiculo.MostrarVehiculo(vehiculoId);
                Console.WriteLine(VehiculoDetalle.Id+" "+VehiculoDetalle.Placa);
                ConductorDetalle=_repoConductor.MostrarConductor(conductorId);
                Console.WriteLine(ConductorDetalle.Nombre+" "+ConductorDetalle.Apellido);
                ProductoDetalle=_repoProducto.MostrarProducto(productoId);
                Console.WriteLine(ProductoDetalle.Id+" "+ProductoDetalle.Nombre);

                SalidaDetalle.Vehiculo=VehiculoDetalle;
                SalidaDetalle.Conductor=ConductorDetalle;
                SalidaDetalle.Producto=ProductoDetalle;
                Console.WriteLine(SalidaDetalle.Vehiculo.Placa+" "+SalidaDetalle.Conductor.Nombre+" "+SalidaDetalle.Producto.Nombre);
                 */
                SalidaDetalle.FechaHora=DateTime.Now;

                _repoSalida.AgregarSalida(SalidaDetalle,vehiculoId,conductorId,productoId);
                //Console.WriteLine(SalidaDetalle.Vehiculo.Placa+" "+SalidaDetalle.Conductor.Nombre+" "+SalidaDetalle.Producto.Nombre);
            
            return RedirectToPage("./ListaSalida");
        }else
        return Page();
        }
    }
    }