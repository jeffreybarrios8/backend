using DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public  class Cliente: LogicInterface.ICliente
    {
        private readonly DataAccessInterface.ICliente clientes;

        public Cliente(DataAccessInterface.ICliente cliente)
        {
            this.clientes = cliente;
        }

        public IEnumerable<Modelos.Cliente> ListarCliente()
        {
          return  clientes.ListarCliente();
        }

        public void AgregarCliente(Modelos.Cliente cliente)
        {
            clientes.AgregarCliente(cliente);
        }

        public void EliminarCliente(Modelos.Cliente cliente)
        {
            clientes.EliminarCliente(cliente);
        }

        public void ActualizarCliente(Modelos.Cliente cliente)
        {
            clientes.ActualizarCliente(cliente);
        }

      

    }
}
