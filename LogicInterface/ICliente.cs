using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
      public  interface ICliente
    {
        public IEnumerable<Modelos.Cliente> ListarCliente();
        public void AgregarCliente(Modelos.Cliente cliente);
        public void EliminarCliente(Modelos.Cliente cliente);
        public void ActualizarCliente(Modelos.Cliente cliente);
    }
}
