using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movimientosTablero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] tablero = new string[4,4];
            int posI = 0;
            int posJ = 0;
            Operaciones.rellenarMatriz(tablero, "X");
            Operaciones.ponerPosicion(tablero, posI, posJ, "0");
            Operaciones.mostrarTablero(tablero);
            Console.WriteLine();
            Operaciones.entradaOpcion(tablero, posI, posJ);

            Console.ReadKey();

        }
    }
}
