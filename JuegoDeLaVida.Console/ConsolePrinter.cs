using System;
using JuegoDeLaVida.Core;

namespace JuegoDeLaVida.Consola
{
    public static class ConsolePrinter
    {
        public static void Print(Generacion generacion)
        {
            for (int y = 0; y < generacion.SizeY; y++) 
            {
                for (int x = 0; x < generacion.SizeX; x++)
                    Console.Write("|{0}", generacion.GetValor(x, y) ? "x" : " ");
                Console.WriteLine("|");
            }
        }
    }
}