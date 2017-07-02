using JuegoDeLaVida.Core;
using System;

namespace JuegoDeLaVida.Consola
{
    public class Program
    {
        // DONE Excepciones cuando no digite una variable del mismo tipo
        static int x = 0;
        static int y = 0;
        static bool isRandom = true;
        static Juego juego = null;

        #region Funciones para la consola
        //TODO: Mover a JuegoExtensionConsola como una Extension de la Clase Juego
        public static void initMenu()
        {
            Console.WriteLine("BIENVENIDO AL JUEGO DE LA VIDA\n");
            Console.WriteLine("Inserte el tamaño de su tablero {No mayor a 100 x 100}: ");
            Console.Write("X: ");
            bool xBool = int.TryParse(Console.ReadLine(), out x);
            Console.Write("Y: ");
            bool yBool = int.TryParse(Console.ReadLine(), out y);
            if (!xBool || !yBool || x > 100 || y > 100 || x < 1 || y < 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No inserto una cantidad correcta, favor intentar de nuevo.");
                Console.ResetColor();
                initMenu();
            }
        }
        public static void initPosition()
        {
            Console.WriteLine("\nDefinir Posicion Inicial:");
            Console.WriteLine("\t1 - Random");
            Console.WriteLine("\t2 - Manual");
            if (int.TryParse(Console.ReadLine(), out int opc))
            {
                if (opc == 1)
                {
                    isRandom = true;
                    juego = new Juego(x, y);
                    ConsolePrinter.Print(juego.GeneracionActual);
                }
                else
                {
                    isRandom = false;
                    juego = new Juego(x, y).SelectPosicionInicial();
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No inserto una opcion correcta, favor intentar de nuevo.");
                Console.ResetColor();
                initPosition();
            }
        }
        public static void MenuJuego()
        {
            Console.WriteLine("OPCIONES:");
            Console.WriteLine("1 - Avanzar una Generacion {Arriba, Derecha o Enter}");
            if (juego?.GeneracionAnterior != null)
            {
                // DONE: No imprimir Retroceder si no existe una generacion anterior
                Console.WriteLine("2 - Retroceder generacion {Abajo, Izquierda}");
            }
            Console.WriteLine("3 - Reiniciar {R}");
            Console.WriteLine("4 - Salir {Escape}");
        }
        public static void InitGame() {
            initMenu();
            initPosition();
            //MenuJuego();
        }
        #endregion

        static void Main(string[] args)
        {
            // BIENVENIDO AL JUEGO DE LA VIDA
            //
            // Inserte el tamaño de su tablero:
            // X: _
            // Y: _
            //
            // 4 - Definir Posicion Inicial
            //      1 - Manual
            //      2 - Random
            //
            // Opciones:
            // 1 - Avanzar una Generacion
            // 2 - Retroceder generacion
            // 3 - Reiniciar
            // 4 - Salir
            ConsoleKey key;
            bool ciclo = true;
            bool printMenu = true;
            InitGame();
            do
            {
                if (printMenu)
                {
                    MenuJuego();
                }
                printMenu = true;
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow: // 1 - Avanzar una generacion
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Enter:
                    case ConsoleKey.NumPad1:
                        juego.AvanzarGeneracion();
                        ConsolePrinter.Print(juego.GeneracionActual);
                        break;
                    case ConsoleKey.NumPad2:  // 2 - Retroceder una Generacion
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        if (juego?.GeneracionAnterior != null)
                        {
                            juego.RetrocederGeneracion();
                            ConsolePrinter.Print(juego.GeneracionActual);
                        }
                        else
                        {
                            printMenu = false;
                        }
                        break;
                    case ConsoleKey.NumPad3:  // 3 - Reiniciar
                    case ConsoleKey.R:
                        Console.Clear();
                        x = 0;
                        y = 0;
                        isRandom = true;
                        juego = null;
                        InitGame();
                        break;
                    case ConsoleKey.NumPad4: // 4 - Salir
                    case ConsoleKey.Escape:
                        ciclo = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No inserto una opcion correcta, favor intentar de nuevo.");
                        Console.ResetColor();
                        break;
                }
            } while (ciclo);
        }
    }
}
