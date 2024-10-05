using System;
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
            Console.WriteLine("!COMENCEMOS!");
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
            Console.ReadKey();
        }

        public static void moverPersonaje()
        {
            int vidas = 3;
            int pocimas = 0;
            int movimiento = 0;
            String opcion;

            while(vidas > 0 && pocimas < 5)
            {
                panelControl();
                opcion = Console.ReadLine();

                if (Int32.TryParse(opcion, out movimiento) )
                {
                    switch (movimiento)
                    {
                        
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento equivocado");
                }

            }
        }

         


    }
}
