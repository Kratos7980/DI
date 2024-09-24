using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    internal class Operaciones
    {
        /**
         * Te pide 5 números y cuenta los que son positivos.
         */
        public static void positivos()
        {
            int positivo = 0;
            int num;
            int cont = 0;

            Console.WriteLine("Introduce cinco números: \n");
            while(cont < 5)
            {
                String leido = Console.ReadLine();
                num = Int32.Parse(leido);
                if(num > 0)
                {
                    positivo++;
                }
                cont++;
            }

            Console.WriteLine("Hay un total de {0} numeros positivos.",positivo);
            Console.ReadKey();
        }
        /**
         * Genera un número aleatorio entre dos números (ambos incluidos).
         * 
         * @param minimo Limite inferior.
         * @param maximo Limite superior.
         */
        public static int aleatorio(int minimo,int maximo)
        {
            if (minimo < maximo)
            {
                Random r = new Random();
                return r.Next(minimo, maximo + 1);
            }
            return -1;
        }
        /**
         * Presentación Listas
         */
        public static void presentacionListas()
        {
            //Trabaja con listas.

            List<string> ListaColores = new List<string>();
            ListaColores.Add("Azul");
            ListaColores.Add("Rojo");
            ListaColores.Add("Verde");
            ListaColores.Add("Amarillo");
            ListaColores.Add("Morado");

            Console.WriteLine(ListaColores[1]);
            Console.WriteLine();

            ListaColores[2] = "Hola";
            Console.WriteLine(ListaColores[2]);
            Console.WriteLine();

            foreach (string s in ListaColores)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            ListaColores.Insert(2, "otra vez");

            foreach (string s in ListaColores)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            ListaColores.Sort();
            foreach (string s in ListaColores)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            Console.WriteLine(ListaColores.IndexOf("Rojo"));

            Console.WriteLine();

            Console.WriteLine(ListaColores.Contains("Rojo"));

            Console.WriteLine();

            ListaColores[ListaColores.IndexOf("otra vez")] = "Verde";
            foreach (string s in ListaColores)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            Console.WriteLine(ListaColores.Count);

            Console.WriteLine();

            Console.WriteLine(ListaColores.Capacity);

            Console.WriteLine();

            ListaColores.Clear();

            foreach (string s in ListaColores)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
        /**
         * Crea un metodo que cree una lista de numeros aleatorios con minimo 1 y maximo 50
         * Esta lista será de 100 elementos.
         * 
         * 
         */
        public static List<int> listaNumerosAleatorios()
        {
            List<int> list = new List<int>(100);
            Random r = new Random();
            foreach (int i in list)
            {
                list.Add(r.Next(1, 51));
            }

            return list;
        }
    }
}
