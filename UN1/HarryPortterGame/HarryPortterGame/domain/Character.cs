using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HarryPortterGame.domain
{
    /// <summary>
    /// Character 
    /// </summary>
    internal class Character
    {
        public int id { get; set; }
        public String name { get; set; }
        public int points { get; set; }

        int idCounter { get; set; }

        /// <summary>
        /// Constructor for a character when id, name and point are know information
        /// </summary>
        /// <param name="id">Unique identifacator for the character</param>
        /// <param name="name">Description name for the character</param>
        /// <param name="points">Total points for ghe character, default 0</param>
        //public Character(int id, string name, int points = 0)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        MessageBox.Show($"\"{nameof(name)}\"Can`t be null.", nameof(name));
        //        throw new ArgumentNullException($"\"{nameof(name)}\"Can`t be null.", nameof(name));
        //    }
        //    this.id = id;
        //    this.name = name;
        //    this.points = points;
        //    if(id > idCounter)
        //    {
        //        idCounter = id;
        //    }
        //    else
        //    {
        //        this.idCounter++;
        //    } 
        //}

        public Character(string name, int points = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show($"\"{nameof(name)}\"Can`t be null.", nameof(name));
                throw new ArgumentNullException($"\"{nameof(name)}\"Can`t be null.", nameof(name));
            }
            this.id = this.idCounter++; ;
            this.name = name;
            this.points = points;
        }
    }
}
