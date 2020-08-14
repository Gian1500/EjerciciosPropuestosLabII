using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int aleatorio, introducido;
            int restantes = 10;
            Random generador = new Random();
            aleatorio = generador.Next(1, 1001);

            Console.WriteLine("Te quedan {0} intentos", restantes);
            Console.Write("Introduce un número: ");
            introducido = Convert.ToInt32(Console.ReadLine());

            //Bucle que se repite hasta que acierte o se quede sin intentos
            while ((introducido != aleatorio) && (restantes > 1))
            {
                restantes = restantes - 1;
                if (introducido < aleatorio)
                    Console.WriteLine("Te has quedado corto");
                if (introducido > aleatorio)
                    Console.WriteLine("Te has pasado");

                Console.WriteLine("Te quedan {0} intentos", restantes);
                Console.Write("Introduce un número: ");
                introducido = Convert.ToInt32(Console.ReadLine());
             }
                //Comprobar si gana o pierde
                if (introducido == aleatorio)
                    Console.WriteLine("Has ganado!");
                else
                {
                    Console.WriteLine("Has perdido!");
                    Console.WriteLine("Era el {0}",aleatorio);
                }

            
        }
    }
}

