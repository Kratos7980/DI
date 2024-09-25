using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = Operaciones.listaNumerosAleatorios();
            foreach(int i in lista)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
