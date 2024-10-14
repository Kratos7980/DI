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

        public static void actualizarContadores(ref string[,] tablero,Jugador jugador1,Jugador jugador2)
        {
            if (derecha && !(jugador1.getPosJ() + 1 >= tablero.GetLength(1)))
            {
                jugador1.setPosJ(jugador1.getPosJ()+1);
                actualizar(ref tablero, jugador1, jugador2);
                jugador1.setPosJ(jugador1.getPosJ() - 1);
                derecha = false;
            }
            if (izquierda && !(jugador1.getPosJ() - 1 < 0))
            {
                jugador1.setPosJ(jugador1.getPosJ()-1);
                actualizar(ref tablero, jugador1, jugador2);
                jugador1.setPosJ(jugador1.getPosJ() + 1);
                izquierda = false;
            }
            if (arriba && !(jugador1.getPosI() - 1 < 0))
            {
                jugador1.setPosI(jugador1.getPosI()-1);
                actualizar(ref tablero, jugador1, jugador2);
                jugador1.setPosI(jugador1.getPosI() + 1);
                arriba = false;
            }
            if(abajo && !(jugador1.getPosI() + 1 >= tablero.GetLength(0)))
            {
                jugador1.setPosI(jugador1.getPosI() + 1);
                actualizar(ref tablero, jugador1, jugador2);
                jugador1.setPosI(jugador1.getPosI() - 1);
                abajo = false;
            }

        }

        private static void actualizar(ref string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            string str = tablero[jugador1.getPosI(), jugador1.getPosJ()].ToString();
            if (!str.Equals(jugador1.getId()) && !str.Equals(jugador2.getId()))
            {
                int n = Int32.Parse(str);
                switch (n)
                {
                    case 0:
                        jugador1.setVidas(jugador1.getVidas()-1);
                        jugador1.setSaltos(jugador1.getSaltos()-1);
                        break;
                    case 1:
                        jugador1.setSaltos(jugador1.getSaltos() - 1);
                        break;
                    case 2:
                        if (!(jugador1.getPeces() == 0))
                        {
                            jugador1.setPeces(jugador1.getPeces() - 1);
                        }

                        jugador1.setSaltos(jugador1.getSaltos() - 1);
                        break;
                    case 3:
                        if (!(jugador1.getPeces() == 5))
                        {
                            jugador1.setPeces(jugador1.getPeces()+1);
                        }

                        jugador1.setSaltos(jugador1.getSaltos() - 1);
                        break;
                }
            }
        }

        public static void moverDerecha(ref string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            derecha = true;
            int n;
            String pieza;

            if (jugador1.getPosJ() + 1 >= tablero.GetLength(1))
            {
                moverIzquierda(ref tablero, jugador1, jugador2);
            }
            else if (!tablero[jugador1.getPosI(), jugador1.getPosJ() + 1].Equals(jugador1.getId()) && !tablero[jugador1.getPosI(), jugador1.getPosJ() + 1].Equals(jugador2.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2);
                n = numRandom(0, 3);
                pieza = n.ToString();
                tablero[jugador1.getPosI(),jugador1.getPosJ()] = pieza;
                jugador1.setPosJ(jugador1.getPosJ()+1);
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = jugador1.getId();
            }
        }

        public static void moverIzquierda(ref string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            izquierda = true;
            int n;
            String pieza;
            
            if (jugador1.getPosJ() - 1 < 0)
            {
                moverDerecha(ref tablero, jugador1, jugador2);
            }
            else if (!tablero[jugador1.getPosI(), jugador1.getPosJ()-1].Equals(jugador1.getId()) && !tablero[jugador1.getPosI(), jugador1.getPosJ() - 1].Equals(jugador2.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2);
                n = numRandom(0, 3);
                pieza = n.ToString();
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = pieza;
                jugador1.setPosJ(jugador1.getPosJ() - 1);
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = jugador1.getId();
            } 
        }

        public static void moverArriba(ref string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            arriba = true;
            int n;
            String pieza;

            if (jugador1.getPosI() - 1 < 0)
            {
                moverAbajo(ref tablero, jugador1, jugador2);
            }
            else if (!tablero[jugador1.getPosI() - 1, jugador1.getPosJ()].Equals(jugador1.getId()) && !tablero[jugador1.getPosI() - 1, jugador1.getPosJ()].Equals(jugador2.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2);
                n = numRandom(0, 3);
                pieza = n.ToString();
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = pieza;
                jugador1.setPosI(jugador1.getPosI() - 1);
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = jugador1.getId();
            }
            
        }

        public static void moverAbajo(ref string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            abajo = true;
            int n;
            String pieza;

            if (jugador1.getPosI() + 1 >= tablero.GetLength(0))
            {
                moverArriba(ref tablero, jugador1, jugador2);
            }
            else if (!tablero[jugador1.getPosI() + 1, jugador1.getPosJ()].Equals(jugador1.getId()) && !tablero[jugador1.getPosI() + 1, jugador1.getPosJ()].Equals(jugador2.getId()))
            {
                actualizarContadores(ref tablero, jugador1, jugador2);
                n = numRandom(0, 3);
                pieza = n.ToString();
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = pieza;
                jugador1.setPosI(jugador1.getPosI() + 1);
                tablero[jugador1.getPosI(), jugador1.getPosJ()] = jugador1.getId();
            } 
        }

        public static void moverJugador(ref string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            int movimiento = numRandom(1, 4);

            switch (movimiento)
            {
                case 1:
                    moverDerecha(ref tablero, jugador1, jugador2);
                    break;
                case 2:
                    moverIzquierda(ref tablero, jugador1, jugador2);
                    break;
                case 3:
                    moverArriba(ref tablero, jugador1, jugador2);
                    break;
                case 4:
                    moverAbajo(ref tablero, jugador1, jugador2);
                    break;
            }
        }

        public static void mostrarFinal(Jugador jugador1, Jugador jugador2, List<string> movimientosP, List<string> movimientosp)
        {
            if (jugador1.getVidas() == 0 || jugador1.getSaltos() <= 0)
            {
                Console.WriteLine("{0}: ¡GAME OVER!", jugador1.getId());
            }
            if (jugador1.getPeces() == 5 && jugador1.getSaltos() > 0)
            {
                Console.WriteLine("{0}: !Ha completado el juego!", jugador1.getId());
            }
            if (jugador2.getVidas() == 0 || jugador2.getSaltos() <= 0)
            {
                Console.WriteLine("{0}: ¡GAME OVER!", jugador2.getId());
            }
            if (jugador2.getPeces() == 5 && jugador2.getSaltos() > 0)
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