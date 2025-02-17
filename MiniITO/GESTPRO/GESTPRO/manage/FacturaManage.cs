using FormularioExamen.model;
using FormularioExamen.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.manage
{
    internal class FacturaManage
    {
        private List<Factura> listFacturas;

        public FacturaManage()
        {
            listFacturas = new List<Factura>();
        }

        public bool insertarFactura(Factura f)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("insert into mydb.factura (numfactura, descfactura, importe) values('" + f.numfactura + "', '" 
                                                           + f.descfactura + "', " + f.importe + ")");
            if (resultado != 0) 
            {
                ok = true;
            }
            return ok;
        }

        public bool updateFacutura(Factura f)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.factura set numfactura = '" + f.numfactura + "', descfactura = '" + f.descfactura + "'");

            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool eliminarFactura(Factura f)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("delete from mydb.factura where idfactura = " + f.idfactura);

            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public Factura getFactura(int idfactura)
        {
            List<Object> filas;
            Factura f = null;

            filas = DBBroker.getInstancia().select("select * from mydb.factura where idfactura = " + idfactura);

            foreach(List<Object> aux in filas)
            {
                f = new Factura(Int32.Parse(aux[0].ToString()));
                f.numfactura = aux[1].ToString();
                f.descfactura = aux[2].ToString();
                f.importe = float.Parse(aux[3].ToString());
            }
            return f;
        } 

        public List<Factura> getListFacturas()
        {
            List<Object> filas;
            Factura f = null;

            filas = DBBroker.getInstancia().select("select * from mydb.factura");

            foreach (List<Object> aux in filas)
            {
                f = new Factura(Int32.Parse(aux[0].ToString()));
                f.numfactura = aux[1].ToString();
                f.descfactura = aux[2].ToString();
                f.importe = float.Parse(aux[3].ToString());

                listFacturas.Add(f);
            }
            return listFacturas;
        }
    }
}
