using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class User
    {

        public int IdRegistrarUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public string Privilegio { get; set; }
       

    }
}
