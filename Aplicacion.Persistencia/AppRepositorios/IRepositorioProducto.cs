using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia.AppRepositorios
{
    public interface IRepositorioProducto
    {
        Aplicacion.Dominio.Entidades.Producto AgregarProducto(Producto produc);
        IEnumerable<Producto> MostrarProductos();
        IEnumerable<Producto> MostrarProductosFiltro(string filtro);
        Aplicacion.Dominio.Entidades.Producto MostrarProducto(int Id);
        Aplicacion.Dominio.Entidades.Producto ActualizarProducto(Producto ProducAct);
        Aplicacion.Dominio.Entidades.Producto SumarProducto(Producto ProducAct);
        Aplicacion.Dominio.Entidades.Producto RestarProducto(Producto ProducAct);
    }
}