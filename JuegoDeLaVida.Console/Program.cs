using JuegoDeLaVida.Core;
using System;

namespace JuegoDeLaVida.Consola
{
    public class Program
    {
        // TODO: Excepciones cuando no digite una variable del mismo tipo
        // 
        static int x = 0;
        static int y = 0;
        static bool isRandom = true;
        static Juego juego = null;

        public static void initMenu()
        {
            Console.WriteLine("BIENVENIDO AL JUEGO DE LA VIDA\n");
            Console.WriteLine("Inserte el tamaño de su tablero: ");
            Console.WriteLine("X: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Y: ");
            y = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDefinir Posicion Inicial:");
            Console.WriteLine("\t1 - Random");
            Console.WriteLine("\t2 - Manual");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                isRandom = true;
                juego = new Juego(x,y);
            }
            else
            {
                isRandom = false;
                juego = SelectPosicionInicial();
            }
            ConsolePrinter.Print(juego.GeneracionActual);
        }
        // TODO: Metodo para que el pueda elegir manualmente el tablero
        public static Juego SelectPosicionInicial() {
            //ConsolePrinter.Print();
            return new Juego(x,y);
        }
        public static void MenuJuego()
        {
            Console.WriteLine("OPCIONES:");
            Console.WriteLine("1 - Avanzar una Generacion");
            // TODO: No imprimir Retroceder si no existe una generacion anterior
            Console.WriteLine("2 - Retroceder generacion");
            Console.WriteLine("3 - Reiniciar");
            Console.WriteLine("4 - Salir");
        }
        public static void InitGame() {
            initMenu();
            MenuJuego();
        }
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
            int opcion = 0;
            InitGame();
            do
            {

                MenuJuego();
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1: // 1 - Avanzar una generacion
                        juego.AvanzarGeneracion();
                        ConsolePrinter.Print(juego.GeneracionActual);
                        break;
                    case 2:  // 2 - Retroceder una Generacion
                        juego.RetrocederGeneracion();
                        ConsolePrinter.Print(juego.GeneracionActual);
                        break;
                    case 3: // 3 - Reiniciar
                        x = 0;
                        y = 0;
                        isRandom = true;
                        juego = null;
                        InitGame();
                        break;
                    case 4:
                        break;
                }
            } while (true);
        }
    }
}
