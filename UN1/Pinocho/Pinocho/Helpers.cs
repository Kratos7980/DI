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
        private static bool derecha = false;
        private static bool izquierda = false;
        private static bool arriba = false;
        private static bool abajo = false;
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

        public static void actualizarContadores(ref string[,] tablero,Jugador jugador1,Jugador jugador2, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos)
        {
            if (!(posJ +1 >= tablero.GetLength(1)) || !(posJ - 1 < 0) || !(posI - 1 < 0) || !(posI + 1 >= tablero.GetLength(0)))
            {
                if (derecha && !(posJ + 1 >= tablero.GetLength(1)))
                {
                    posJ++;
                }
                if (izquierda && !(posJ - 1 < 0))
                {
                    posJ--;
                }
                if (arriba && !(posI - 1 < 0))
                {
                    posI--;
                }
                if(abajo && !(posI + 1 >= tablero.GetLength(0)))
                {
                    posI++;
                }
                
                string str = tablero[posI, posJ].ToString();
                if (!str.Equals(jugador1.getId()) && !str.Equals(jugador2.getId()))
                {
                    int n = Int32.Parse(str);
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
                            if (peces == 5)
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
                }

                if (derecha)
                {
                    posJ--;
                    derecha = false;
                }
                if (izquierda)
                {
                    posJ++;
                    izquierda = false;
                }
                if (arriba)
                {
                    posI++;
                    arriba = false;
                }
                if (abajo)
                {
                    posI--;
                    abajo = false;
                }
                
            }

        }

        public static void moverDerecha(ref string[,] tablero, String idJugador, Jugador jugador1, Jugador jugador2, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            derecha = true;
            int n;
            String pieza;

            if (posJ + 1 >= tablero.GetLength(1))
            {
                moverIzquierda(ref tablero, idJugador, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI, posJ + 1].Equals(jugador1.getId()) && !tablero[posI, posJ + 1].Equals(jugador1.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posJ++;
                tablero[posI, posJ] = idJugador;
            }
        }

        public static void moverIzquierda(ref string[,] tablero, String idJugador, Jugador jugador1, Jugador jugador2, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            izquierda = true;
            int n;
            String pieza;
            
            if (posJ - 1 < 0)
            {
                moverDerecha(ref tablero, idJugador, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI, posJ-1].Equals(jugador1.getId()) && !tablero[posI, posJ-1].Equals(jugador1.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posJ--;
                tablero[posI, posJ] = idJugador;
            } 
        }

        public static void moverArriba(ref string[,] tablero, String idJugador, Jugador jugador1, Jugador jugador2, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            arriba = true;
            int n;
            String pieza;

            if (posI - 1 < 0)
            {
                moverAbajo(ref tablero, idJugador, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI - 1, posJ].Equals(jugador1.getId()) && !tablero[posI - 1, posJ].Equals(jugador1.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces,ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posI--;
                tablero[posI, posJ] = idJugador;
            }
            
        }

        public static void moverAbajo(ref string[,] tablero, String idJugador, Jugador jugador1, Jugador jugador2, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            abajo = true;
            int n;
            String pieza;

            if (posI + 1 >= tablero.GetLength(0))
            {
                moverArriba(ref tablero, idJugador, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
            }
            else if (!tablero[posI + 1, posJ].Equals(jugador1.getId()) && !tablero[posI + 1, posJ].Equals(jugador1.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos);
                n = numRandom(min, max);
                pieza = n.ToString();
                tablero[posI, posJ] = pieza;
                posI++;
                tablero[posI, posJ] = idJugador;
            } 
        }

        public static void moverJugador(ref string[,] tablero, Jugador jugador1, Jugador jugador2, ref int posI, ref int posJ, ref int vidas, ref int peces, ref int saltos, int min, int max)
        {
            int movimiento = numRandom(1, 4);

            switch (movimiento)
            {
                case 1:
                    moverDerecha(ref tablero, jugador1.getId(), jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
                case 2:
                    moverIzquierda(ref tablero, jugador1.getId(), jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
                case 3:
                    moverArriba(ref tablero, jugador1.getId(), jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
                case 4:
                    moverAbajo(ref tablero, jugador1.getId(), jugador1, jugador2, ref posI, ref posJ, ref vidas, ref peces, ref saltos, min, max);
                    break;
            }
        }

        public static void mostrarFinal(Jugador jugador1, Jugador jugador2, List<string> movimientosP, List<string> movimientosp)
        {
            if (jugador1.getVidas() == 0)
            {
                Console.WriteLine("{0}: ¡GAME OVER!", jugador1.getId());
            }
            if (jugador1.getPeces() == 5)
            {
                Console.WriteLine("{0}: !Ha completado el juego!", jugador1.getId());
            }
            if (jugador2.getVidas() == 0)
            {
                Console.WriteLine("{0}: ¡GAME OVER!", jugador2.getId());
            }
            if (jugador2.getPeces() == 5)
            {
                Console.WriteLine("{0}: !Ha completado el juego!", jugador2.getId());
            }
            Console.Write("Paths {0}: ",jugador1.getId());
            foreach (String str in movimientosP)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            Console.Write("Paths {0}: ", jugador2.getId());
            foreach (String str in movimientosp)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
