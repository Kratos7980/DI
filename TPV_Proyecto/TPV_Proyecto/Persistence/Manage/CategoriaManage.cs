using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV_Proyecto.Domain;

namespace TPV_Proyecto.Persistence.Manage
{
    internal class CategoriaManage
    {
        public List<Categoria> listCategoria {  get; set; }

        public CategoriaManage()
        {
            listCategoria = new List<Categoria>();
        }

        public List<Categoria> readCategoria()
        {
            Categoria c = null;
            List<Object> lcategoria;
            lcategoria = DBBroker.obtenerAgente().leer("select * from categorias");

            foreach(List<Object> aux in lcategoria)
            {
                c = new Categoria(Int32.Parse(aux[0].ToString()));
                c.nombre = aux[1].ToString();
                listCategoria.Add(c);
            }
            return listCategoria;
        }
    }
}
