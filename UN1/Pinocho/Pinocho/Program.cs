using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creo los jugadores.
            Jugador pinocho = new Jugador("Pinocho");
            Jugador pepito = new Jugador("pepito");

            //Creo la matriz.
            string[,] tablero = new string[5, 5];
            
            //Relleno la matriz.
            Helpers.rellenarTablero(tablero);
            Helpers.mostrarTablero(tablero);
            Console.ReadKey();

            //Creo las listas para guardar todos los movimientos.
            List<string> movimientosP = new List<string>();
            List<string> movimientosp = new List<string>();


            
            //Pinocho
            int vidasP = pinocho.getVidas();
            int pecesP = pinocho.getPeces();
            //Pepito
            int vidasg = pepito.getVidas();
            int pecesg = pepito.getPeces();
            //Iniciar Juego
            int posI = 0;
            int posJ = 0;
            int saltos = 0;
            
            //Posiciono a los jugadores.
            Helpers.posicionInicial(tablero, posI, posJ, pinocho.toString("P"));

            try
            {
                while (vidasP > 0 && saltos < 18)
                {
                    Helpers.moverJugador(ref tablero, pinocho.toString("P"), ref posI, ref posJ, ref vidasP, ref pecesP, ref saltos);
                    pinocho.setVidas(vidasP);
                    pinocho.setPeces(pecesP);
                    Helpers.mostrarTablero(tablero);
                    Console.ReadKey();
                    Console.WriteLine(pinocho.getVidas());
                    Console.ReadKey();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error, " + ex.ToString());
            }



        }
    }
}
