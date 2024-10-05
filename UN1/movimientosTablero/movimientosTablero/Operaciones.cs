using System;
using System.Collections.Generic;
using System.Linq;
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

                    if (Int32.TryParse(opcion, out opcionNum))
                    {
                        switch (opcionNum)
                        {
                            case 1:
                                tablero[posI, posJ] = "X";
                                posJ++;
                                tablero[posI, posJ] = "0";
                                break;
                            case 2:
                                tablero[posI, posJ] = "X";
                                posJ--;
                                tablero[posI, posJ] = "0";
                                break;
                            case 3:
                                tablero[posI, posJ] = "X";
                                posI++;
                                tablero[posI, posJ] = "0";
                                break;
                            case 4:
                                tablero[posI, posJ] = "X";
                                posI--;
                                tablero[posI, posJ] = "0";
                                break;
                            case 5:
                                salir = true;
                                break;
                        }
                        Console.WriteLine();
                        mostrarMatriz(tablero);
                    }
                    else
                    {
                        Console.WriteLine("Solo opciones entre 1 y 5");
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

        public static void mostrarMatriz(string[,] tablero)
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
    }
}
