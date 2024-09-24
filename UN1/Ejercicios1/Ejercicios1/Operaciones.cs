using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    internal class Operaciones
    {
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

        public static void aleatorio()
        {

        }
    }
}
