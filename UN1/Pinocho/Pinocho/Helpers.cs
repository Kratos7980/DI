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
        private static Random r = new Random(DateTime.Now.Millisecond);
        public static int numRandom(int n1, int n2)
        {
            return r.Next(n1, n2+1);
        }

        public static void rellenarTablero(string[,] tablero)
        {

            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    int num = numRandom(0, 3);
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
                    saltos--;
                    break;
                case 1:
                    saltos--;
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
                    saltos--;
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
                    saltos--;
                    break;
            }
            posJ--;

        }

        public static void moverDerecha(ref string[,] tablero, String idJugador, Jugador jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {

            int n;
            String pieza;

            if (posJ + 1 >= tablero.GetLength(1))
            {
                moverIzquierda(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI, posJ + 1].Equals(jugador.getId()) && !tablero[posI, posJ + 1].Equals(jugador.getId()))
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posJ++;
                tablero[posI, posJ] = idJugador;
            }

        }

        public static void moverIzquierda(ref string[,] tablero, String idJugador, Jugador jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            int n;
            String pieza;
            
            if (posJ - 1 < 0)
            {
                moverDerecha(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI, posJ-1].Equals(jugador.getId()) && !tablero[posI, posJ-1].Equals(jugador.getId()))
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posJ--;
                tablero[posI, posJ] = idJugador;
            }
            

        }

        public static void moverArriba(ref string[,] tablero, String idJugador, Jugador jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            int n;
            String pieza;

            if (posI - 1 < 0)
            {
                moverAbajo(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI - 1, posJ].Equals(jugador.getId()) && !tablero[posI - 1, posJ].Equals(jugador.getId()))
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces,ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posI--;
                tablero[posI, posJ] = idJugador;
            }

        }

        public static void moverAbajo(ref string[,] tablero, String idJugador, Jugador jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {

            int n;
            String pieza;

            if (posI + 1 >= tablero.GetLength(1))
            {
                moverArriba(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI + 1, posJ].Equals(jugador.getId()) && !tablero[posI + 1, posJ].Equals(jugador.getId()))
            {
                actualizarContadores(ref tablero, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posI++;
                tablero[posI, posJ] = idJugador;
            }

        }

        public static void moverJugador(ref string[,] tablero, String idJugador, Jugador jugador, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            int movimiento = numRandom(1, 4);

            switch (movimiento)
            {
                case 1:
                    moverDerecha(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
                case 2:
                    moverIzquierda(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
                case 3:
                    moverArriba(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
                case 4:
                    moverAbajo(ref tablero, idJugador, jugador, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
            }
        }
    }
}
