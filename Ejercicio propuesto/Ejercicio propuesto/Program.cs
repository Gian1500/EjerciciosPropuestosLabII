using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPropuesto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int miliseg = DateTime.Now.Millisecond;
            int dado = miliseg % 100 + 1;
            Console.WriteLine("El Numero del dado es {0} ", dado);
            Console.ReadKey();

        }
    }
}

