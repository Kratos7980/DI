using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPortterGame.domain
{
    internal class Ability
    {
        public int id {  get; set; }
        public String name { get; set; }
        public int points { get; set; }

        public Ability(String name) {
            this.id = 0;
            this.name = name;
            this.points = 100;
        }

        public Ability(String name, int points)
        {
            this.id = 0;
            this.name = name;
            this.points = points;
        }
    }
}
