using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.domain
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Genero(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public override string ToString()
        {
            return Id + " " + Nombre;
        }
    }

    

}
