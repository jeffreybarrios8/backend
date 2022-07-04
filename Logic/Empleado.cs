using LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Empleado : IEmpleado
    {

        private readonly DataAccessInterface.IEmpleado empleados;

        public Empleado(DataAccessInterface.IEmpleado empleado)
        {
            this.empleados = empleado;
        }

        public void ActualizarEmpleado(Modelos.Empleado empleado)
        {
            empleados.ActualizarEmpleado(empleado);
        }

        public void AgregarEmpleado(Modelos.Empleado empleado)
        {
            empleados.AgregarEmpleado(empleado);
        }

        public void EliminarEmpleado(Modelos.Empleado empleado)
        {
            empleados.EliminarEmpleado(empleado);
        }

        public IEnumerable<Modelos.EmpleadoResponse> ListarEmpleados()
        {
           return empleados.ListarEmpleados();
        }
    }
}
