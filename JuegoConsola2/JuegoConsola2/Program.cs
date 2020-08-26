using System;
using System.Threading; // Para Thread.Sleep

namespace JuegoConsola2
{
    class Program
    {
        public static void Main()

        {

            ConsoleKeyInfo tecla;

            int x = 40, y = 12;

            // Obstáculos
            int[] xo1 = new int[10];

            int[] yo1 = new int[10];


            // Enemigo 1
            int[] xe1 = new int[6];
            int[] ye1 = new int[6];
            int incr1 = 1;

            // 0 = no terminado, 1 = terminado
            int fin = 0;

            int[] xPremio = new int[3]; // Premios

            int[] yPremio = new int[3];

            //Barras
            int vidas = 100;
            int vx = 0, vy = 0;
            int Px = 0, Py = 1;




            // Genero las posiciones de los premios y enemigos al azar



            Random generador2 = new Random();

            for (int i = 0; i < 6; i++)

            {


                xe1[i] = generador2.Next(0, 80);

                ye1[i] = generador2.Next(0, 24);

            }


            Random generador1 = new Random();

            for (int i = 0; i < 10; i++)

            {

                xo1[i] = generador1.Next(0, 80);

                yo1[i] = generador1.Next(0, 24);

            }


            Random generador = new Random();

            for (int i = 0; i < 3; i++)

            {

                xPremio[i] = generador.Next(0, 80);

                yPremio[i] = generador.Next(0, 24);

            }

            // Bucle de juego

            while (fin == 0)

            {

                // Dibujar

                Console.Clear();

                Console.SetCursorPosition(x, y);

                Console.Write("P");


                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(xo1[i], yo1[i]); // Obstáculos
                    Console.Write("o");
                }

                for (int i = 0; i < 6; i++)
                {
                    Console.SetCursorPosition(xe1[i], ye1[i]); // Enemigo

                    Console.Write("@");
                }

                Console.SetCursorPosition(vx, vy);  //BARRAS
                Console.Write("LIFE= " + vidas + "%");

                Console.SetCursorPosition(Px, Py);
                Console.Write("VUELVE A CASA ( / )");

                for (int i = 0; i < 3; i++) // Premios

                {

                    Console.SetCursorPosition(xPremio[i], yPremio[i]);
                    Console.Write("/");

                }

                // Leer teclas y calcular nueva posición

                if (Console.KeyAvailable)

                {

                    tecla = Console.ReadKey(false);

                    if (tecla.Key == ConsoleKey.RightArrow) x++;

                    if (tecla.Key == ConsoleKey.LeftArrow) x--;

                    if (tecla.Key == ConsoleKey.DownArrow) y++;

                    if (tecla.Key == ConsoleKey.UpArrow) y--;

                }

                // Mover enemigos, entorno
                for (int i = 0; i < 6; i++)
                {
                    xe1[i] = xe1[i] + incr1;


                    if (xe1[i] == 0)

                        incr1 = -incr1;

                    else if (xe1[i] == 70)

                        incr1 = -incr1;

                }

                // Colisiones, perder vidas, etc

                for (int i = 0; i < 10; i++)
                {
                    if ((x == xo1[i]) && (y == yo1[i]))
                    {
                        vidas = vidas - 5;
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    if ((x == xe1[i]) && (y == ye1[i]))
                    {
                        vidas = vidas - 10;

                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if ((x == xPremio[i]) && (y == yPremio[i]))
                    {
                        Console.WriteLine("       ||GANASTE!!!!|| ");
                        Console.ReadKey();
                        fin = 1;

                    }
                }



                if (vidas == 0)
                {
                    Console.WriteLine("       ||PERDISTE!!!!|| ");
                    Console.ReadKey();
                    fin = 1;

                }




                    // Pausa hasta el siguiente "fotograma" del juego

                    Thread.Sleep(40);

                }

            }

        }
    }

