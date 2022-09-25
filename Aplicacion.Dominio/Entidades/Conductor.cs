using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades
{
    public class Conductor
    {
        public int Id {get;set;}
        public string Cedula {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public string Celular {get;set;}
    }
}