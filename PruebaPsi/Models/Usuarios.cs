using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPsi.Models
{
    public class Usuarios
    {

        public string Id { get; set; }

        public string ?Nombres { get; set; }

        public string ?Apellidos { get; set; }

        public string ?Identificaccion { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string ?Correo { get; set; }

    }

}
