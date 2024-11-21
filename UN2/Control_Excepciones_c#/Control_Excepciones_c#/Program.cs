using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Excepciones_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double[] listDiv = new double[10];
            int dividendo = 20;
            int divisor = 0;

            while(divisor < 11)
            {
                try
                {
                    listDiv[divisor] = (dividendo / divisor);
                    divisor++;
                    dividendo--;
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("ERROR:Linea 22, NO se puede dividir entre 0, la variable divisor deber ser diferente a 0");
                    divisor++;
                    continue;
                }catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("ERROR: Linea 22, La lista de divisiones no puede ser mayor de 10, intentas meter + de 10 registros");
                    break;
                }
                
            }
        }
    }
}
