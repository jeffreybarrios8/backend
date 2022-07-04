using Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicInterface
{
    public interface IServicios
    {
        public IEnumerable<Modelos.Servicios> ListarServicios();
        public void AgregarServicio(Servicios servicio);
        public void EliminarServicio(Servicios servicio);
        public void ActualizarServicio(Servicios servicio);
    }
}
