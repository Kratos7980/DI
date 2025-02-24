using GUESTPRO.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.model
{
    internal class Factura
    {
        public int idfactura { get; set; }
        public string numfactura { get; set; }
        public string descfactura { get; set; }

        public float importe { get; set; }

        private FacturaManage fm;

        public Factura()
        {
            fm = new FacturaManage();
        }

        public Factura(int idfactura)
        {
            this.idfactura = idfactura;
            fm = new FacturaManage();
        }

        public Factura(int idfactura, string numfactura, string descfactura, float importe)
        {
            this.idfactura = idfactura;
            this.numfactura = numfactura;
            this.descfactura = descfactura;
            this.importe = importe;
            fm = new FacturaManage();
        }
    }
}
