using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego01
{
    class Program
    {
        public static void Main(string[] args)
        {
            int miliseg = DateTime.Now.Millisecond;
            Console.WriteLine(miliseg);
            Console.ReadKey();
        }
    }
}
