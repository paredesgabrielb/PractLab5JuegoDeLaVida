using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuegoDeLaVida
{
    public class Generacion
    {
        public int Id { get; set; }
        public bool[] Matrix { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Generacion( int id, bool[] matrix, int sizeX, int sizeY)
        {
            Id = id;
            Matrix = matrix;
            SizeX = sizeX;
            SizeY = sizeY;
        }

        // Metodos del Objeto
        public bool GetValor(int x, int y)
        {
            return Matrix[x + y * SizeX];
        }

        public Generacion GetNextGeneracion()
        {
            var _matrix = (
                from y in Enumerable.Range(0, SizeY)
                from x in Enumerable.Range(0, SizeX)
                let val = GetValor(x, y)
                let vecinosCercanos = (
                    from x2 in Enumerable.Range(x - 1, 3)
                    from y2 in Enumerable.Range(y - 1, 3)
                    where x2 >= 0 && x2 < SizeX
                    where y2 >= 0 && y2 < SizeY
                    where x2 != x || y2 != y
                    where GetValor(x2, y2)
                    select 1).Sum()
                select ((val && (vecinosCercanos == 2 || vecinosCercanos == 3))
                    || (!val && vecinosCercanos == 3)))
                .ToArray();
            return new Generacion(Id + 1, _matrix, SizeX, SizeY); ;
        }

    }
}
