using System;

namespace JuegoDeLaVida
{
    public static class ConsolePrinter
    {
        public static void Print(Generacion generacion)
        {
            for (int x = 0; x < generacion.SizeX; x++)
            {
                for (int y = 0; y < generacion.SizeY; y++)
                    Console.Write("|{0}", generacion.GetValor(x, y) ? "X" : " ");
                Console.WriteLine("|");
            }
        }
    }
}

