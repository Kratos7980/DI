using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPV_Proyecto.Domain;

namespace TPV_Proyecto.Persistence.Manage
{
    internal class TicketManage
    {
        public List<Ticket> listTickets {  get; set; }

        public TicketManage()
        {
            listTickets = new List<Ticket>();
        }
        
        public void insertTicket(string fecha, double total)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("insert into ticket (fecha,total) values ('"+ fecha + "'," + total + ")");
        }

        public void insertProductoTicket(int codigo_ticket, int codigo_producto, int cantidad)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("insert into productos_has_ticket (codigo_producto,codigo_ticket, unidades) values ("+codigo_producto+","+codigo_ticket+"," +cantidad + ")");
        }

        public int readCodigo(double total, string fecha)
        {
            int codigo = 0;
            DBBroker dbBroker = DBBroker.obtenerAgente();
            List<Object> list = new List<Object>();
            list = dbBroker.leer("select codigo_ticket from ticket where fecha = '"+fecha+"' and total = "+total);

            foreach(List<Object> aux in list)
            {
                codigo = Int32.Parse(aux[0].ToString());
                
            }
            return codigo;
        }
    }
}
