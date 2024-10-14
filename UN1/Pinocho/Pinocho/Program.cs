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
            Jugador pinocho = new Jugador("P");
            Jugador pepito = new Jugador("G");

            //Creo la matriz.
            string[,] tablero = new string[5, 5];
            
            //Relleno la matriz.
            Helpers.rellenarTablero(tablero);
            //Helpers.mostrarTablero(tablero);
            // Console.ReadKey();


            #region Variables
            List<string> movimientosP = new List<string>();
            List<string> movimientosp = new List<string>();
            bool exit = false;
            #endregion

            #region Juego

            Helpers.posicionInicial(tablero, pinocho.getPosI(), pinocho.getPosJ(), pinocho.getId());

            Helpers.moverJugador(ref tablero, pinocho, pepito);
            movimientosP.Add("(" + pinocho.getPosI() + "," + pinocho.getPosJ() + ")");

            Helpers.posicionInicial(tablero, pepito.getPosI(), pepito.getPosJ(), pepito.getId());

            try
            {
                while (!exit)
                {
                    
                    if (pepito.getVidas() > 0 && pepito.getSaltos() > 0)
                    {
                        Helpers.moverJugador(ref tablero, pepito, pinocho);
                        movimientosp.Add("(" + pepito.getPosI() + "," + pepito.getPosJ() + ")");
                    }

                    if (pinocho.getVidas() > 0 && pinocho.getSaltos() > 0)
                    {
                        Helpers.moverJugador(ref tablero, pinocho, pepito);
                        movimientosP.Add("(" + pinocho.getPosI() + "," + pinocho.getPosJ() + ")");

                    }

                    if (pinocho.getVidas() == 0 && pepito.getVidas() == 0)
                    {
                        exit = true;
                    }
                    
                    if(pepito.getPeces() == 5 && pepito.getPosI() == 5 && pepito.getPosJ() == 5)
                    {
                        exit = true;
                    }

                    if (pinocho.getPeces() == 5 && pinocho.getPosI() == 5 && pinocho.getPosJ() == 5)
                    {
                        exit = true;
                    }

                    if (pinocho.getSaltos() <= 0 && pepito.getSaltos() <= 0)
                    {
                        exit = true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error, " + ex.ToString());
            }
            #endregion
            Helpers.mostrarFinal(pinocho, pepito, movimientosP, movimientosp);
        }
    }
}