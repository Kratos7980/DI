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
            int minimo;
            int maximo;
            String leido;

            Console.WriteLine("Introduce el minimo: ");
            leido = Console.ReadLine();
            minimo = Int32.Parse(leido);
            Console.WriteLine("Introduce el máximo: ");
            leido = Console.ReadLine();
            maximo = Int32.Parse(leido);

            Random num = new Random();
            Console.WriteLine("\n");
            Console.WriteLine("Numero generado: {0}",num.Next(minimo, maximo + 1));
            Console.ReadKey();
        }
    }
}
