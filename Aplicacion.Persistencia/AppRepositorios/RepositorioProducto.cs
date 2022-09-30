using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public class RepositorioProducto:IRepositorioProducto
    {
        public readonly Aplicacion.Persistencia.AppRepositorios.appcontext appcox;
        public RepositorioProducto(Aplicacion.Persistencia.AppRepositorios.appcontext appContext)
        {
            appcox = appContext;
        }
        public Aplicacion.Dominio.Entidades.Producto AgregarProducto(Aplicacion.Dominio.Entidades.Producto Producto)
        {
            var productoNuevo = appcox.Productos.Add(Producto);
            appcox.SaveChanges();
            return productoNuevo.Entity;
        }
        public IEnumerable<Producto> MostrarProductos()
        {
            return appcox.Productos;
        }
        public IEnumerable<Producto> MostrarProductosFiltro(string filtro)
        {
            var Produc=MostrarProductos();
            if (Produc!=null)
            {
                if(!String.IsNullOrEmpty(filtro))
                {
                    Produc=Produc.Where(c=>c.Nombre.Contains(filtro));
                }
                
            }
            return Produc;
        }
        public Producto MostrarProducto(int Id)
        {
            return appcox.Productos.FirstOrDefault(a => a.Id == Id);
        }
        public Producto ActualizarProducto(Producto Produc)
        {
            var ProductoModificado = appcox.Productos.FirstOrDefault(s => s.Id == Produc.Id);
            if (ProductoModificado != null)
            {
                ProductoModificado.Nombre = Produc.Nombre;
                ProductoModificado.Precio = Produc.Precio;
                ProductoModificado.Cantidad = Produc.Cantidad;
            }
            appcox.SaveChanges();
            return ProductoModificado;
        }
        public Producto SumarProducto(Producto Produc)
        {
            var ProductoModificado = appcox.Productos.FirstOrDefault(s => s.Id == Produc.Id);
            if (ProductoModificado != null)
            {
                ProductoModificado.Nombre = Produc.Nombre;
                ProductoModificado.Precio = Produc.Precio;
                ProductoModificado.Cantidad = ProductoModificado.Cantidad+Produc.Cantidad;
            }
            appcox.SaveChanges();
            return ProductoModificado;
        }
        public Producto RestarProducto(Producto Produc)
        {
            var ProductoModificado = appcox.Productos.FirstOrDefault(s => s.Id == Produc.Id);
            if (ProductoModificado != null)
            {
                ProductoModificado.Nombre = Produc.Nombre;
                ProductoModificado.Precio = Produc.Precio;
                ProductoModificado.Cantidad = ProductoModificado.Cantidad-Produc.Cantidad;
            }
            appcox.SaveChanges();
            return ProductoModificado;
        }
        /* public void EliminarProducto(int Id)
        {
            var ProductoEncontrado = appcox.Productos.FirstOrDefault(a => a.Id == Id);
            if (ProductoEncontrado == null)
                return;
            appcox.Productoes.Remove(ProductoEncontrado);
            appcox.SaveChanges();
        } */
    }
}