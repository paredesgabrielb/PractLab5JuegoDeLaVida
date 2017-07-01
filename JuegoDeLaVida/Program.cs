using System;

namespace JuegoDeLaVida
{
    public class Program
    {
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

            Console.WriteLine("Definir Posicion Inicial:");
            Console.WriteLine("1 - Random");
            Console.WriteLine("2 - Manual");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                isRandom = true;
                juego = new Juego(x,y,isRandom);
            }
            else
            {
                isRandom = false;
                juego = SelectPosicionInicial();

            }

        }
        public static Juego SelectPosicionInicial() {
            ConsolePrinter.Print(g);
            return new Juego(x,y);
        }
        public static void MenuJuego()
        {
            Console.WriteLine("OPCIONES:");
            Console.WriteLine("1 - Avanzar una Generacion");
            Console.WriteLine("2 - Retroceder generacion");
            Console.WriteLine("3 - Reiniciar");
            Console.WriteLine("4 - Salir");
        }
        static void Main(string[] args)
        {
            // Opciones:
            // 1 - Retroceder generacion
            // 2 - Avanzar una Generacion
            // 3 - Reiniciar
            // 4 - Definir Posicion Inicial
            //      1 - Manual
            //      2 - Random
            // 5 - Salir
            do
            {
                initMenu();
                int opcion = 0;

                MenuJuego();

                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                ConsolePrinter.Print(g);
                Console.WriteLine("Enter para continuar. Q para salir.");
                if (Console.ReadLine() == "Q")
                    break;

                g.GoNextState();

            } while (true);

        }
    }
}
