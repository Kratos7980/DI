using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Jugador
    {
        private String name;
        private int vidas;
        private int peces;

        public Jugador(String name)
        {
            this.name = name;
            this.vidas = 3;
            this.peces = 0;
        }

        public String getName()
        {
            return this.name;
        }

        public int getVidas()
        {
            return this.vidas;
        }

        public int getPeces()
        {
            return this.peces;
        }

        public void setVidas(int vidas)
        {
            this.vidas = vidas;
        }

        public void setPeces(int peces)
        {
            this.peces = peces;
        }

        public String toString(String jugador) 
        {
            return jugador;
        }
    }
}
