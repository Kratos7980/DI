using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Helpers
    {
        //Constantes Random.
        private const int MAX = 3;
        private const int MIN = 0;
        public static int numRandom(int n1, int n2)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            return r.Next(n1, n2+1);
        }

        public static void rellenarTablero(string[,] tablero)
        {

            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    int num = numRandom(MIN, MAX);
                    string n = num.ToString();
                    tablero[i, j] = n;
                }
            }
        }

        public static void posicionInicial(string[,] tablero, int posI, int posJ, string cadena)
        {
            tablero[posI, posJ] = cadena;
        }

        public static void mostrarTablero(string[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void mostrarTablero(string[,] tablero, int posI, int posJ)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    if (tablero[i, j] == "M")
                    {
                        Console.Write(tablero[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("X" + " ");
                    }

                }
                Console.WriteLine();
            }
        }

        public static void actualizarContadores(ref string[,] tablero, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {
            posJ++;
            int n = Int32.Parse(tablero[posI, posJ]);
            switch (n)
            {
                case 0:
                    vidas--;
                    saltos++;
                    break;
                case 1:
                    saltos++;
                    break;
                case 2:
                    if (peces == 0)
                    {
                        peces = 0;
                    }
                    else
                    {
                        peces--;
                    }
                    saltos++;
                    break;
                case 3:
                    if(peces == 5)
                    {
                        peces = 5;
                    }
                    else
                    {
                        peces++;
                    }
                    saltos++;
                    break;
            }
            posJ--;


        }

        public static void moverDerecha(ref string[,] tablero, String jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {

            int n;
            String pieza;

            if (posJ + 1 >= tablero.GetLength(1))
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();
            }
            else
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(MIN, MAX);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posJ++;
                tablero[posI, posJ] = jugador;
            }

        }

        public static void moverIzquierda(ref string[,] tablero, String jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {
            int n;
            String pieza;

            if (posJ - 1 < 0)
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();
            }
            else
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(MIN, MAX);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posJ--;
                tablero[posI, posJ] = jugador;
            }

        }

        public static void moverArriba(ref string[,] tablero, String jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {
            int n;
            String pieza;

            if (posI - 1 < 0)
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();
            }
            else
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces,ref saltos);
                n = numRandom(MIN, MAX);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posI--;
                tablero[posI, posJ] = jugador;
            }

        }

        public static void moverAbajo(ref string[,] tablero, String jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {

            int n;
            String pieza;

            if (posI + 1 >= tablero.GetLength(1))
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();
            }
            else
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(MIN, MAX);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posI++;
                tablero[posI, posJ] = jugador;
            }

        }

        public static void moverJugador(ref string[,]tablero, String jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {
            int movimiento = numRandom(1, 4);

            switch (movimiento)
            {
                case 1:
                    Helpers.moverDerecha(ref tablero, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                    break;
                case 2:
                    Helpers.moverIzquierda(ref tablero, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                    break;
                case 3:
                    Helpers.moverArriba(ref tablero, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                    break;
                case 4:
                    Helpers.moverAbajo(ref tablero, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                    break;
            }
        }
    }
}
