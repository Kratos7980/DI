﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable posiciones
            int posI = 0;
            int posJ = 0;
            

            //Inicio del Juego.
            Operaciones.mostrarInicio();

            //Reglas del Juego.
            Operaciones.mostrarReglas();

            //Creo el tablero
            string[,] tablero = new string[8, 8];
            
            //Relleno el tablero
            Operaciones.rellenarTablero(tablero);

            //Coloco al Judador
            Operaciones.posicionInicial(tablero, posI, posJ, "M");

            //Muestro el tablero
            Operaciones.mostrarTablero(tablero,posI,posJ);

            //Comienza el Juego
            Operaciones.iniciarJuego(tablero,posI,posJ);
            
        }
    }
}
