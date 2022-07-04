using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterface
{
    public interface IServicios
    {
        public IEnumerable<Modelos.Servicios> ListarServicios();
        public void AgregarServicio(Servicios servicio);
        public void EliminarServicio(Servicios servicio);
        public void ActualizarServicio(Servicios servicio);

    }
}
