using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV_Proyecto.Domain
{
    internal class Ticket
    {
        public int codigo_ticket {  get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public double total { get; set; }

        public Ticket(int codigo_ticket, int cantidad, string descripcion, double precio, double total)
        {
            this.codigo_ticket = codigo_ticket;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.precio = precio;
            this.total = total;
        }

        public Ticket(int cantidad, string descripcion, double precio, double total)
        {
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.precio = precio;
            this.total = total;
        }
    }
}
