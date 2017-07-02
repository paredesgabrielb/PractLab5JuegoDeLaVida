using JuegoDeLaVida.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeLaVida.Consola
{
    public static class JuegoExtensionConsola
    {
        // DONE: Metodo para que el pueda elegir manualmente el tablero
        public static Juego SelectPosicionInicial(this Juego juego)
        {
            int x = juego.SizeX;
            int y = juego.SizeY;
            //ConsolePrinter.Print();
            Console.Clear();
            Console.WriteLine("Presione 'X' para seleccionar una cedula como viva, la 'BARRA ESPACIADORA' para dejarla muerta y 'ENTER' para finalizar");
            Console.WriteLine("Pude usar las flechas para moverse");
            bool[] matrix = new bool[x * y];
            //Console.Write("  ");
            //for (int j = 0; j < y; j++)
            //Console.Write("{0} ", j);
            Console.WriteLine();
            for (int j = 0; j < y; j++)
            {
                //Console.Write(i);
                for (int i = 0; i < x; i++)
                    Console.Write("|{0}", matrix[i + j * x] ? "X" : " ");
                Console.WriteLine("|");
            }
            int cursorX = 1; // El cursor comienza en  0
            int cursorY = 3;
            ConsoleKey key;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    Console.SetCursorPosition(cursorX + (i * 2), cursorY + j);
                    key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.X:
                            matrix[i + j * x] = true;
                            break;
                        case ConsoleKey.Spacebar:
                            matrix[i + j * x] = false;
                            break;
                        case ConsoleKey.Enter:
                            i = x;
                            j = y;
                            break;
                        case ConsoleKey.UpArrow:
                            // Si el cursor no esta en la posicion inicial, le resto una posicion de lo contrario, se quedara ahi
                            matrix[i + j * x] = false;
                            j = j != 0 ? j - 1 : j;
                            i--;
                            break;
                        case ConsoleKey.DownArrow:
                            matrix[i + j * x] = false;
                            j = j != y - 1 ? j + 1 : j;
                            i--;
                            break;
                        case ConsoleKey.RightArrow:
                            matrix[i + j * x] = false;
                            i = i != x - 1 ? i : i - 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            matrix[i + j * x] = false;
                            i = i != 0 ? i - 2 : -1;
                            break;
                        default:
                            i--;
                            break;
                    }

                }
            }
            Console.SetCursorPosition(0, cursorY + y);

            Generacion gen = new Generacion(0, matrix, x, y);
            return new Juego(x, y, false, gen);
        }


    }
}
