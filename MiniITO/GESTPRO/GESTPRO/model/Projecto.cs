using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTPRO.model
{
    internal class Projecto
    {
        private int id;
        private String name;
        private String fechaI;
        private String fechaF;

        public Projecto(int id, string name, string fechaI, string fechaF)
        {
            this.id = id;
            this.name = name;
            this.fechaI = fechaI;
            this.fechaF = fechaF;
        }

        public int Id { get =>  id; set => id = value; }
        public String Name { get => name; set => name = value; }

        public String FechaI { get => fechaI; set => fechaI = value; }

        public String FechaF { get => fechaF; set => fechaF = value; }
    }
}
