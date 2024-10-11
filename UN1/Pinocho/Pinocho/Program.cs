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
            int vidasP = pinocho.getVidas();
            int pecesP = pinocho.getPeces();
            int vidasg = pepito.getVidas();
            int pecesg = pepito.getPeces();
            int posIP = pinocho.getPosI();
            int posJP = pinocho.getPosJ();
            int posIp = pepito.getPosI();
            int posJp = pepito.getPosJ();
            int saltosP = pinocho.getSaltos();
            int saltosp = pepito.getSaltos();
            int min = 0;
            int max = 3;
            bool exit = false;
            #endregion

            #region Juego
            //Posiciono a pinocho.
            Helpers.posicionInicial(tablero, pinocho.getPosI(), pinocho.getPosJ(), pinocho.getId());
            /*
            Helpers.mostrarTablero(tablero);
            Console.WriteLine();
            Console.ReadKey();
            */

            Helpers.moverJugador(ref tablero, pinocho, pepito, ref posIP,ref posJP,ref vidasP,ref pecesP,ref saltosP,min,max);
            pinocho.setPosI(posIP);
            pinocho.setPosJ(posJP);
            posIP = pinocho.getPosI();
            posJP = pinocho.getPosJ();
            /*
            Helpers.mostrarTablero(tablero);
            Console.WriteLine();
            Console.ReadKey();
            */

            Helpers.posicionInicial(tablero, pepito.getPosI(), pepito.getPosJ(), pepito.getId());
            /*
            Helpers.mostrarTablero(tablero);
            Console.WriteLine();
            Console.ReadKey();
            */
            
            try
            {
                while (!exit)
                {
                    if (pinocho.getVidas() > 0  && pinocho.getSaltos() > 0)
                    {
                        Helpers.moverJugador(ref tablero, pinocho, pepito, ref posIP, ref posJP, ref vidasP, ref pecesP, ref saltosP, min, max);
                        movimientosP.Add("(" + posIP + "," + posJP + ")");
                        pinocho.setPosI(posIP);
                        pinocho.setPosJ(posJP);
                        pinocho.setVidas(vidasP);
                        pinocho.setPeces(pecesP);
                        pinocho.setSaltos(saltosP);
                        posIP = pinocho.getPosI();
                        posJP = pinocho.getPosJ();
                        vidasP = pinocho.getVidas();
                        pecesP = pinocho.getPeces();
                        saltosP = pinocho.getSaltos();
                    }

                    if (pepito.getVidas() > 0 && pepito.getSaltos() > 0)
                    {
                        Helpers.moverJugador(ref tablero, pepito, pinocho, ref posIp, ref posJp, ref vidasg, ref pecesg, ref saltosp, min, max);
                        movimientosp.Add("(" + posIp + "," + posJp + ")");
                        pepito.setPosI(posIp);
                        pepito.setPosJ(posIp);
                        pepito.setVidas(vidasg);
                        pepito.setPeces(pecesg);
                        pepito.setSaltos(saltosp);
                        posIp = pepito.getPosI();
                        posJp = pepito.getPosJ();
                        vidasg = pepito.getVidas();
                        pecesg = pepito.getPeces();
                        saltosp = pepito.getSaltos();
                    }
                    if(pinocho.getVidas() == 0 && pepito.getVidas() == 0)
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
                    Helpers.mostrarTablero(tablero);
                    Console.WriteLine();
                    Console.ReadKey();


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
