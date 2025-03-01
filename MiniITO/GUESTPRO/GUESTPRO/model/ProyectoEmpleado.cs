using GUESTPRO.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.model
{
    internal class ProyectoEmpleado
    {
        public int idproyecto { get; set; }
        public int idempleado { get; set; }
        public string nombreproygestion {  get; set; }
        public string nombreempgestion {  get; set; }
        public DateTime fecha { get; set; }
        public float costes { get; set; }
        public int horas { get; set; }

        private ProyectoEmpleadoManage pem;

        public ProyectoEmpleado()
        {
            pem = new ProyectoEmpleadoManage();
        }

        public ProyectoEmpleado(int idproyecto, int idempleado, DateTime fecha)
        {
            this.idproyecto = idproyecto;
            this.idempleado = idempleado;
            this.fecha = fecha;
            pem = new ProyectoEmpleadoManage();
        }

        public ProyectoEmpleado(int idproyecto, int idempleado, DateTime fecha, float costes, int horas)
        {
            this.idproyecto = idproyecto;
            this.idempleado = idempleado;
            this.fecha = fecha;
            this.costes = costes;
            this.horas = horas;
            pem = new ProyectoEmpleadoManage();
        }

        public bool insertar()
        {
            return pem.insertarProyectosEmpleados(this);
        }

        public bool modificar()
        {
            return pem.modificarProyectosEmpleados(this);
        }

        public bool eliminar()
        {
            return pem.eliminarProyectosEmpleados(this);
        }

        public List<ProyectoEmpleado> getAllProyEmp()
        {
            return pem.getProyectosEmpleados();
        }
    }  
}
