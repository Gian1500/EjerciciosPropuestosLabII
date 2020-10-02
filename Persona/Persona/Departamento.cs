using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    class Departamento
    {
        private ArrayList Empleados = new ArrayList();

        public ArrayList Empleados1 { get => Empleados; set => Empleados = value; }

        public void agregarEmpleado(Persona empleado)
        {
            Empleados.Add(empleado);


        }
        public void quitarEmpleado(Persona empleado)
        {
            Empleados.Remove(empleado);
        }

        public int getCantidadEmpleado()
        {
            return Empleados.Count;
        }


    }
}

   

