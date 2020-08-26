using System;
using System.Threading;

namespace JuegoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;

            int x = 40, y = 12;

            int xo1 = 20, yo1 = 15; // Obstáculo 1

            int xo2 = 25, yo2 = 5; // Obstáculo 2

            int xo3 = 62, yo3 = 21; // Obstáculo 3

            int fin = 0; // 0 = no terminado, 1 = terminado

            float xe1 = 0, ye1 = 0; //ENEMIGO1

            float xe2 = 30, ye2 = 25; //ENEMIGO2

            float incr1 = 0.5f;

            float incr2 = 0.8f;

            while (fin == 0)
            {

                // Dibujar

                Console.Clear();

                Console.SetCursorPosition(x, y);

                Console.Write("A");

                Console.SetCursorPosition(xo1, yo1); // Obstáculos

                Console.Write("o");

                Console.SetCursorPosition(xo2, yo2);

                Console.Write("o");

                Console.SetCursorPosition(xo3, yo3);

                Console.Write("o");

                Console.SetCursorPosition((int)xe1, (int)ye1); // Enemigo

                Console.Write("@");

                Console.SetCursorPosition((int)xe2, (int)ye2); // Enemigo2

                Console.Write("&");

                // Leer teclas y calcular nueva posición

                tecla = Console.ReadKey(false);

                if (tecla.Key == ConsoleKey.RightArrow) x++;

                if (tecla.Key == ConsoleKey.LeftArrow) x--;

                if (tecla.Key == ConsoleKey.DownArrow) y++;

                if (tecla.Key == ConsoleKey.UpArrow) y--;

                xe1 = xe1 + incr1;
                if ((xe1 == 0) || (xe1 == 79))
                    incr1 = -incr1;

                xe2 = xe2 + incr2;
                if ((xe2 == 30) || (xe2== 79))
                    incr2 = -incr2; 

               
                if (((x == xo1) && (y == yo1))
                    || ((x == xo2) && (y == yo2))
                    || ((x == xo3) && (y == yo3)))
                {
                    fin = 1;

                    Console.WriteLine("PERDISTE!!");
                    Console.ReadKey();

                }

                // Pausa hasta el siguiente "fotograma" del juego

                Thread.Sleep(40);
            }
        }
    }
}
