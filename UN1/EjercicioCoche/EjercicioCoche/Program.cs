using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCoche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creamos el objeto coche
            Coche c = new Coche(1, "BMW", "Z4", 100, 53000);

            //get atributos del coche
            Console.WriteLine(c.marca);
            Console.WriteLine(c.modelo);
            Console.WriteLine(c.km);
            Console.WriteLine(c.precio);
            Console.ReadKey();

            //modifico el precio
            c.precio = 24000;

            //Muestro el coche completo utilizando el toString;
            Console.WriteLine(c.ToString());
            Console.ReadKey();

            //Ejercicio 6
            List<Coche> listCoche = new List<Coche>();

            for (int i = 0; i < 4; i++)
            {
                Coche car = crearCoche();
                listCoche.Add(car);
            }
            
            //Ejercicio 7
            foreach (Coche coche in listCoche)
            {
                Console.WriteLine(coche.ToString());
            }
            Console.ReadKey();

            

        }
        
        public static Coche crearCoche()
        {
            Console.WriteLine("Rellena los siguientes campos para crear un objeto coche:");
            Console.WriteLine("Introduce un identificador:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la marca:");
            String marca = Console.ReadLine();
            Console.WriteLine("Introduce el modelo:");
            String modelo = Console.ReadLine();
            Console.WriteLine("Introduce kilometraje:");
            int km = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduce precio:");
            double precio = Double.Parse(Console.ReadLine());

            Coche c = new Coche(id, marca, modelo, km, precio);

            return c;
        }
    }
}
