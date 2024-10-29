using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBross_wpf.domain
{
    internal class Player
    {
        private int lives {  get; set; }
        private String name;
        private int potions {  get; set; }

        public Player(string name, int lives)
        {
            this.lives = lives;
            this.name = name;
            this.potions = 0;
        }

    }
}
