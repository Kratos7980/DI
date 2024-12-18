using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV_Proyecto.Domain
{
    internal class Ticket
    {
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public double total { get; set; }

        public Ticket(int cantidad, string descripcion, double precio, double total)
        {
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.precio = precio;
            this.total = total;
        }

    }
}
