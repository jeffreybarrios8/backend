using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public  interface IEmpleado
    {
        public IEnumerable<Modelos.EmpleadoResponse> ListarEmpleados();
        public void AgregarEmpleado(Empleado empleado);
        public void EliminarEmpleado(Empleado empleado);
        public void ActualizarEmpleado(Empleado empleado);
    }
}
