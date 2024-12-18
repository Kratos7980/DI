using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV_Proyecto.Domain
{
    internal class Categoria
    {
        public int idcategoria { get; set; }
        public string nombre { get; set; }

        public Categoria(int idcategoria, string nombre)
        {
            this.idcategoria = idcategoria;
            this.nombre = nombre;
        }

        public Categoria(int idcategoria)
        {
            this.idcategoria=idcategoria;
        }
    }
}
