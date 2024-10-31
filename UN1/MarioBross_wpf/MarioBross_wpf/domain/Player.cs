using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBross_wpf.domain
{
    internal class Player
    {
        private int lives;
        private String name;
        private int potions;

        public Player(string name, int lives, int potions)
        {
            this.lives = lives;
            this.name = name;
            if(potions >= 5)
            {
                this.potions = potions;
            }
            else
            {
                this.potions = 0;
            }
            
        }

        public String getName()
        {
            return this.name;
        }

        public int getLives()
        {
            return this.lives;
        }

        public int getPotions()
        {
            return this.potions;
        }

        public void setPotions()
        {
            this.potions = 0;
        }

    }
}
