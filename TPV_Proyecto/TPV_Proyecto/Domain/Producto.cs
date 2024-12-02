using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV_Proyecto.Domain
{
    internal class Producto
    {
        public int codigo_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio {  get; set; }
        public int idcategoria {  get; set; }

        public Producto(int codigo_producto, string nombre, string descripcion, double precio, int idcategoria)
        {
            this.codigo_producto = codigo_producto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.idcategoria = idcategoria;
        }

        public Producto(int codigo_producto)
        {
            this.codigo_producto = codigo_producto;
        }
    }
}
