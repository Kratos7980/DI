using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace movimientosTablero
{
    internal class Operaciones
    {
        // Rellenar la matriz con una cadena dada
        public static void rellenarMatriz(string[,] tablero, string cadena)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = cadena;
                }
            }
        }

        public static void ponerPosicion(string[,] tablero, int posI, int posJ, string cadena)
        {
            tablero[posI, posJ] = cadena;
        }

        public static void entradaOpcion(string[,] tablero, int posI, int posJ)
        {
            try
            {
                #region InicializaciónVariables
                String opcion;
                int opcionNum = 0;
                bool salir = false;
                #endregion
                #region logicalWhile
                
                while (!salir)
                {
                    mostrarOpciones();
                    opcion = Console.ReadLine();

                    if (Int32.TryParse(opcion, out opcionNum) && posI >= 0 && posJ >= 0)
                    {
                        switch (opcionNum)
                        {
                            case 1:
                                moverDerecha(ref tablero,ref posI,ref posJ);
                                break;
                            case 2:
                                moverIzquierda(ref tablero, ref posI, ref posJ);
                                break;
                            case 3:
                                moverAbajo(ref tablero, ref posI, ref posJ);
                                break;
                            case 4:
                                moverArriba(ref tablero, ref posI, ref posJ);
                                break;
                            case 5:
                                salir = true;
                                break;
                        }
                        Console.Clear();
                        mostrarTablero(tablero);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento inválido");
                        Console.ReadKey();
                        mostrarTablero(tablero);
                    }
                    
                }
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha producido un error loco " + e.ToString());
                Console.ReadKey();
            }
        }

        public static void mostrarOpciones()
        {
            Console.WriteLine("1.Derecha ");
            Console.WriteLine("2.Izquierda");
            Console.WriteLine("3.Abajo");
            Console.WriteLine("4.Arriba");
            Console.WriteLine("5.Salir");
        }

        public static void mostrarTablero(string[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                Console.Write(tablero[i, 0] + " ");
                for (int j = 1; j < tablero.GetLength(1); j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void moverDerecha(ref string[,]tablero, ref int posI, ref int posJ) 
        {
            if (posJ+1 >= tablero.GetLength(1))
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();

            }
            else
            {
                tablero[posI, posJ] = "X";
                posJ++;
                tablero[posI, posJ] = "0";
            }
        }

        public static void moverIzquierda(ref string[,] tablero, ref int posI, ref int posJ)
        {
            if (posJ - 1 < 0)
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();

            }
            else
            {
                tablero[posI, posJ] = "X";
                posJ--;
                tablero[posI, posJ] = "0";
            }
        }

        public static void moverArriba(ref string[,]tablero, ref int posI, ref int posJ)
        {
            if (posI - 1 < 0)
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();

            }
            else
            {
                tablero[posI, posJ] = "X";
                posI--;
                tablero[posI, posJ] = "0";
            }
        }

        public static void moverAbajo(ref string[,] tablero, ref int posI, ref int posJ)
        {
            if (posI + 1 >= tablero.GetLength(1))
            {
                Console.WriteLine("Has llegado al límite");
                Console.ReadKey();

            }
            else
            {
                tablero[posI, posJ] = "X";
                posI++;
                tablero[posI, posJ] = "0";
            }
        }
    }
}
