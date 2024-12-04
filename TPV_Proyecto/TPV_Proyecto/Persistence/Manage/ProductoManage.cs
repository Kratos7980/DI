using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV_Proyecto.Domain;

namespace TPV_Proyecto.Persistence.Manage
{
    class ProductoManage
    {
        public List<Producto> listProducto{ get; set; }
        public ProductoManage()
        {
            listProducto = new List<Producto>();
        }

        public List<Producto> readProducto()
        {
            Producto p = null;
            List<Object> lproducto;
            lproducto = DBBroker.obtenerAgente().leer("select * from productos");

            foreach (List<Object> aux in lproducto)
            {
                p = new Producto(Int32.Parse(aux[0].ToString()));
                p.nombre = aux[1].ToString();
                p.descripcion = aux[2].ToString();
                p.precio = Double.Parse(aux[3].ToString());
                p.idcategoria = Int32.Parse(aux[4].ToString());
                listProducto.Add(p);
            }
            return listProducto;
        }

        public List<Producto> readProducto(int idcategoria)
        {
            List<Producto> listProducto = new List<Producto>();
            Producto p = null;
            List<Object> lproducto;
            lproducto = DBBroker.obtenerAgente().leer("select * from productos where id_categorias = "+idcategoria);

            foreach (List<Object> aux in lproducto)
            {
                p = new Producto(Int32.Parse(aux[0].ToString()));
                p.nombre = aux[1].ToString();
                p.descripcion = aux[2].ToString();
                p.precio = Double.Parse(aux[3].ToString());
                p.idcategoria = Int32.Parse(aux[4].ToString());
                listProducto.Add(p);
            }
            return listProducto;
        }
    }
}
