using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades
{
    public class Producto
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public int Precio {get;set;}
        public int Cantidad{get;set;}
    }
}