using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Operaciones
    {
        public static void ejercicio1()
        {
            Random r = new Random();
            int mark = r.Next(0, 101);
            if (mark < 50)
            {
                Console.WriteLine("PASS");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.ReadKey();
        }

        public static void ejercicio2()
        {
            Random r = new Random();
            int n = r.Next(0, 101);

            if ((n%2) == 0)
            {
                Console.WriteLine("Número Par");
            }
            else
            {
                Console.WriteLine("Número Impar");
            }
            Console.ReadKey();
        }

        public static void ejercicio3()
        {
            int top = 100;
            int suma = 0;
            double media = 0;
            for (int i = 1; i <= top; i++)
            {
                suma += i;
            }
            media = (double) suma / top;
            Console.WriteLine("La suma es {0}",suma);
            Console.WriteLine("La media es {0:F1}", media);
            Console.ReadKey();

            //Con while do
            /*
             * int n = 0;
             * while (n <= 100)
             * {
             *     suma += n;
             *     n++;
             * }
             * media = (double) suma / top;
             * 
             * Console.WriteLine("La suma es {0}",suma);
             * Console.WriteLine("La media es {0}", media);
             * Console.ReadKey();
             */

            //Con do while

            /*
             * int n = 0;
             * do
             * {
             *     n++;
             *     suma += n;
             * 
             * }while(n <= 100)
             * 
             * media = (double) suma / top;
             * 
             * Console.WriteLine("La suma es {0}",suma);
             * Console.WriteLine("La media es {0}", media);
             * Console.ReadKey()
             */

            //Suma sólo los números pares
            /*
             * int cont = 0;
             * 
             * for(int i = 0; i <= 100 ; i++)
             * {
             *     if((i%2) == 0)
             *     {
             *         suma += i;
             *         cont++;
             *     }
             * }
             * media = (double) suma / cont;
             * 
             * Console.WriteLine("La suma es {0}",suma);
             * Console.WriteLine("La media es {0}", media);
             * Console.ReadKey()
             */

            //Suma sólo divisibles por 7
            /*
             * int cont = 0;
             * 
             * for(int i = 0; i <= 100; i++)
             * {
             *     if(i%7) == 0)
             *     {
             *         suma += i;
             *         cont++;
             *     }
             * }
             * media = (double) suma / cont;
             * 
             * Console.WriteLine("La suma es {0}",suma);
             * Console.WriteLine("La media es {0}", media);
             * Console.ReadKey()
             */

            //Suma cuadrado de números ((1*1)+(2*2)+...)
            /*
             * for (int i = 0; i <= 100; i++)
             * {
             *     suma += (i*i);
             * }
             * 
             * Console.WriteLine("La suma es {0}",suma);
             * Console.ReadKey()
             */
        }

        public static void ejercicio4()
        {
            int top = 50000;
            int n = 1;
            double suma = 1;
            double suma1 = 1;

            for(int i = 2; i <= top; i++)
            {
                suma += (double) (n / i);
            }

            for( int i = top; i <= 2; i--)
            {
                suma1 += (double) (n / i);
            }
            Console.WriteLine("De derecha a izquierda: {0:F6}",suma);
            Console.WriteLine("De izquierda a derecha: {0:F6}",suma1);
            Console.ReadKey();
        }

        public static void ejercicio5()
        {

        }


    }
}
