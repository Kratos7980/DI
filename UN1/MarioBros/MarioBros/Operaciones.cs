﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    internal class Operaciones
    {
        public static void rellenarTablero(string[,] tablero)
        {
            Random r = new Random();
            
            for ( int i = 0; i < tablero.GetLength(0); i++ )
            {
                for( int j = 0; j < tablero.GetLength(1); j++)
                {
                    int num = r.Next(0, 3);
                    string n = num.ToString();
                    tablero[i, j] = n;
                }
            }
        }

        public static void posicionInicial(string[,] tablero, int posI, int posJ, string cadena)
        {
            tablero[posI,posJ] = cadena;
        }

        public static void panelControl()
        {
            Console.WriteLine("1.Derecha");
            Console.WriteLine("2.Izquierda");
            Console.WriteLine("3.Arriba");
            Console.WriteLine("4.Abajo");
        }

        public static void mostrarInicio()
        {
            Console.WriteLine("Bienvenido a Mario Bros");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Debemos rescatar a Peach de las manos de Browser");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Para ello debemos conseguir las 5 pócimas");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("¡COMENCEMOS!");
            Console.ReadKey();
            Console.Clear();
        }

        public static void mostrarReglas()
        {
            Console.WriteLine("Instrucciones:");
            Console.WriteLine("1.Comienzas con 3 vidas");
            Console.WriteLine("2.Si caes en 0 pierdes 1 vida");
            Console.WriteLine("3.Si caes en 1 ganas 1 vida");
            Console.WriteLine("4.Si caes en 2 consigues 1 pocion");
            Console.WriteLine("5.Si pierdes todas las vidas pierdes");
            Console.WriteLine("6.Si consigues todas las pociones ganas");
            Console.ReadKey();
            Console.Clear();
        }

        public static void mostrarTablero(string[,] tablero)
        {
            for(int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int vidasPocimas(string[,] tablero, int posI, int posJ, int vidas, int pocimas)
        {
            int n = Int32.Parse(tablero[posI,posJ]);
            int v = vidas;
            switch(n)
            {
                case 0:
                    vidas--;
                    break;
                case 1:
                    vidas++;
                    break;
                case 2:
                    pocimas++;
                    break;
            }
            if (vidas != v)
            {
                return vidas;
            }
            else
            {
                return pocimas;
            }
            
        }

        public static Boolean comprobarVidas(string[,] tablero, int posI, int posJ)
        {
            int n = Int32.Parse(tablero[posI, posJ]);
            Boolean vidas = false;
            switch (n)
            {
                case 0:
                    vidas = true;
                    break;
                case 1:
                    vidas = true;
                    break;
                case 2:
                    vidas = false;
                    break;
            }
            return vidas;
        }

        public static void mostrarFinal()
        {
            Console.Clear();
            Console.WriteLine("¡HAS CONSEGUIDO RESCATAR A PEACH!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("¡FELICIDADES HAS COMPLETADO EL JUEGO!");
            Console.ReadKey();
        }

        public static void iniciarJuego(string[,] tablero, int posI, int posJ)
        {
            int vidas = 3;
            int pocimas = 0;
            int movimiento = 0;
            //Nueva pieza tablero
            int n;
            String pieza;
            //Personaje
            String jugador = "M";
            String opcion;
            Random r = new Random();
            try
            {
                while (vidas > 0 && pocimas < 5)
                {
                    Console.WriteLine("Vidas: {0}", vidas);
                    Console.WriteLine("Pocimas: {0}", pocimas);
                    panelControl();
                    opcion = Console.ReadLine();

                    if (Int32.TryParse(opcion, out movimiento) && Int32.Parse(opcion) < 5)
                    {
                        switch (movimiento)
                        {
                            case 1:
                                posJ++;
                                if (comprobarVidas(tablero, posI, posJ))
                                {
                                    vidas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                else
                                {
                                    pocimas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                posJ--;
                                n = r.Next(0, 3);
                                pieza = n.ToString();
                                tablero[posI, posJ] = pieza;
                                posJ++;
                                tablero[posI, posJ] = jugador;
                                break;
                            case 2:
                                posJ--;
                                if (comprobarVidas(tablero, posI, posJ))
                                {
                                    vidas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                else
                                {
                                    pocimas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                posJ++;
                                n = r.Next(0, 3);
                                pieza = n.ToString();
                                tablero[posI, posJ] = pieza;
                                posJ--;
                                tablero[posI, posJ] = jugador;
                                break;
                            case 3:
                                posI--;
                                if (comprobarVidas(tablero, posI, posJ))
                                {
                                    vidas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                else
                                {
                                    pocimas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                posI++;
                                n = r.Next(0, 3);
                                pieza = n.ToString();
                                tablero[posI, posJ] = pieza;
                                posI--;
                                tablero[posI, posJ] = jugador;
                                break;
                            case 4:
                                posI++;
                                if (comprobarVidas(tablero, posI, posJ))
                                {
                                    vidas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                else
                                {
                                    pocimas = vidasPocimas(tablero, posI, posJ, vidas, pocimas);
                                }
                                posI--;
                                n = r.Next(0, 3);
                                pieza = n.ToString();
                                tablero[posI, posJ] = pieza;
                                posI++;
                                tablero[posI, posJ] = jugador;
                                break;

                        }
                        Console.Clear();
                        mostrarTablero(tablero);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Movimiento equivocado");
                        Console.ReadKey();
                        Console.Clear();
                        mostrarTablero(tablero);
                    }

                }

                if(vidas == 0)
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                }
                else
                {
                    mostrarFinal();
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error, " + ex.ToString());
            }
                
            
        }

         


    }
}