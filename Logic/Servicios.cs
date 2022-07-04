using DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public class Servicios: LogicInterface.IServicios
    {
        private readonly DataAccessInterface.IServicios servicios;
        

        public Servicios(DataAccessInterface.IServicios servicio)
        {
            this.servicios = servicio;
        }

        public void ActualizarServicio(Modelos.Servicios servicio)
        {
            servicios.ActualizarServicio(servicio);
        }

        public void AgregarServicio(Modelos.Servicios servicio)
        {
            servicios.AgregarServicio(servicio);
        }

        public void EliminarServicio(Modelos.Servicios servicio)
        {
            servicios.EliminarServicio(servicio);
        }

        public IEnumerable<Modelos.Servicios> ListarServicios()
        {
          return servicios.ListarServicios();
        }
    }
}
