using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Juan");

            Persona p2 = new Persona("Pedro");

            Departamento d1 = new Departamento();


            d1.agregarEmpleado(p1);
            d1.agregarEmpleado(p2);

            foreach (Persona o in d1.Empleados1)
            {
                Console.WriteLine("Empleados: " + o.Nombre);
               
            }
            
            Console.WriteLine("Cantidad De empleados: " + d1.getCantidadEmpleado());
            Console.ReadKey();
        }

    }
}
