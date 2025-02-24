using GUESTPRO.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.model
{
    internal class Proyecto
    {
        public int idproyecto { get; set; }
        public string codigoproy { get; set; }
        public string nombreproy { get; set; }

        public string descproy { get; set; }
        public float presupuesto { get; set; }
        public int idfactura { get; set; }

        private ProyectoManage pm;

        public Proyecto()
        {
            pm = new ProyectoManage();
        }

        public Proyecto(int idproyecto)
        {
            this.idproyecto = idproyecto;
            pm = new ProyectoManage();
        }

        public Proyecto(string codigoproy, string nombreproy, string descproy, float presupuesto, int idfactura)
        {
            this.codigoproy = codigoproy;
            this.nombreproy = nombreproy;
            this.descproy = descproy;
            this.presupuesto = presupuesto;
            this.idfactura = idfactura;
            pm = new ProyectoManage();
        }

        public bool insertar()
        {
            return pm.insertarProyecto(this);
        }

        public bool modificar()
        {
            return pm.modificarProyecto(this);
        }
        //public bool modificarNombre()
        //{
        //    return pm.cambianNombreProyecto(this);
        //}

        //public bool addFactura()
        //{
        //    return pm.asociarAFactura(this);
        //}

        public bool eliminar()
        {
            return pm.eliminarProyecto(this);
        }

        public Proyecto last()
        {
            return pm.last();
        }
        public Proyecto getProyecto(int idproyecto)
        {
            return pm.getProyecto(idproyecto);
        }

        public List<Proyecto> getAllProyectos()
        {
            return pm.getAllProyecto();
        }

        public Dictionary<String, int> getRolEmpleNum()
        {
            return pm.countEmpleRol(this);
        }
    }
}
