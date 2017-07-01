using System;
using System.Collections.Generic;
using System.Linq;

namespace JuegoDeLaVida
{
    public class Juego
    {
        public Generacion[] Generaciones { get; set; }
        public Generacion GeneracionActual { get; set; }
        public Generacion GeneracionAnterior { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        // Constructor
        public Juego(int sizeX, int sizeY, bool isRandom = true)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            if (isRandom)
            {
                GeneracionActual = GenerarGeneracionRandom();
                Generaciones[0] = GeneracionActual;
            }
        }

        public void AvanzarGeneracion()
        {
            GeneracionAnterior = GeneracionActual;
            GeneracionActual = GeneracionActual.GetNextGeneracion();
            Generaciones[Generaciones.Length] = GeneracionActual ;
        }
        public void RetrocederGeneracion()
        {
            GeneracionActual = GeneracionAnterior;
            GeneracionAnterior = Generaciones[GeneracionAnterior.Id-1];
        }
        public Generacion GenerarGeneracionRandom()
        {
            var random = new Random();
            var _matrix = Enumerable.Range(1, SizeX * SizeY)
                .Select((x) => random.NextDouble() < 0.20)
                .ToArray();
            return new Generacion(Generaciones.Length,_matrix, SizeX, SizeY);
        }

        // Metodos Estaticos
        public static bool GetValor(Generacion generacion, int x, int y)
        {
            return generacion.Matrix[x + y * generacion.SizeX];
        }

        public static Generacion GetNextGeneracion(Generacion generacion)
        {
            var _matrix = (
                from y in Enumerable.Range(0, generacion.SizeY)
                from x in Enumerable.Range(0, generacion.SizeX)
                let val = generacion.GetValor(x, y)
                let vecinosCercanos = (
                    from x2 in Enumerable.Range(x - 1, 3)
                    from y2 in Enumerable.Range(y - 1, 3)
                    where x2 >= 0 && x2 < generacion.SizeX
                    where y2 >= 0 && y2 < generacion.SizeY
                    where x2 != x || y2 != y
                    where generacion.GetValor(x2, y2)
                    select 1).Sum()
                select ((val && (vecinosCercanos == 2 || vecinosCercanos == 3))
                    || (!val && vecinosCercanos == 3)))
                .ToArray();
            return new Generacion(0,_matrix, generacion.SizeX, generacion.SizeY); ;
        }


    }
}