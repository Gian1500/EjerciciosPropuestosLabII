using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juegi01e
{
    public class Program
    {
        public static void Main(string[] args)
        { Random dado = new Random();
            int aleatorio1 = dado.Next(1, 11);
            int aleatorio2 = dado.Next(11, 21);
            Console.WriteLine("El Numero del 1° dado es {0} ", aleatorio1);
            Console.WriteLine("El Numero del 2° dado es {0} ", aleatorio2);
            Console.ReadKey();

        }
    }
}
