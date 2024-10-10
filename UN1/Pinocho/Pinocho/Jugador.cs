using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Jugador
    {
        private String id;
        private int vidas;
        private int peces;
        private int saltos;
        private int posI;
        private int posJ;


        public Jugador(string id)
        {
            this.id = id;
            this.vidas = 10;
            this.peces = 0;
            this.saltos = 18;
            this.posI = 0;
            this.posJ = 0;
        }

        public String getId()
        {
            return this.id;
        }

        public int getVidas()
        {
            return this.vidas;
        }

        public int getPeces()
        {
            return this.peces;
        }
        public int getSaltos()
        {
            return this.saltos;
        }

        public int getPosI()
        {
            return this.posI;
        }

        public int getPosJ()
        {
            return this.posJ;
        }

        public void setVidas(int vidas)
        {
            this.vidas = vidas;
        }

        public void setPeces(int peces)
        {
            this.peces = peces;
        }

        public void setSaltos(int saltos)
        {
            this.saltos = saltos;
        }

        public void setPosI(int pos)
        {
            this.posI= pos;
        }

        public void setPosJ(int pos)
        {
            this.posJ= pos;
        }
    }
}
