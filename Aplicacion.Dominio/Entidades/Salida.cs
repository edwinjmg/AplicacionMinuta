using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades
{
    public class Salida
    {
        public int Id {get;set;}
        public DateTime FechaHora {get;set;}
        public Vehiculo Vehiculo{get;set;}
        public Conductor Conductor{get;set;}
        public Producto Producto{get;set;}
    }
}