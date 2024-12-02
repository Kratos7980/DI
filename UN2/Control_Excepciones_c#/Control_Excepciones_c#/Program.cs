using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Excepciones_c_
{
    internal class Program
    {
        private static int MAX_DIVISIONES = 10;
        static void Main(string[] args)
        {

            double[] listDiv = new double[10];
            int dividendo = 20;
            int divisor = 0;
            int i = 0;
            
            while (i < 20)
            {
                try
                {
                    int num = Int32.Parse(Console.ReadLine());
                    if (num < 0)
                    {
                        throw new NumeroNegativoException();
                    }
                    else
                    {
                        listDiv[i] = num;
                        i++;
                    }
                } catch (NumeroNegativoException ex)
                {
                    Console.WriteLine("Debe ser un número mayor o igual a 0 ");
                }
            }
            

            while(divisor < 11)
            {
                try
                {
                    listDiv[divisor] = (dividendo / divisor);
                    divisor++;
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("ERROR: NO se puede dividir entre 0, la variable divisor deber ser diferente a 0");
                    divisor++;
                    continue;
                }catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("ERROR: La lista de divisiones no puede ser mayor de 10, intentas meter + de 10 registros");
                    break;
                }
                finally
                {
                    Console.WriteLine("El programa ha terminado");
                }
                
            }
        }
    }
}
