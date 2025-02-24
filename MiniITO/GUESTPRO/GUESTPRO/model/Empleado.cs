using GUESTPRO.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.model
{
    internal class Empleado
    {
        public int idempleado { get; set; }
        public string nombreemp { get; set; }
        public string apellidos { get; set; }
        public float csr { get; set; }
        public int idusuario { get; set; }
        public int idrol { get; set; }

        private EmpleadoManage em;

        public Empleado()
        {
            em = new EmpleadoManage();
        }

        public Empleado(int idempleado)
        {
            this.idempleado = idempleado;
            em = new EmpleadoManage();
        }

        public Empleado(string nombreemp, string apellidos, float csr, int idusuario, int idrol)
        {
            this.nombreemp = nombreemp;
            this.apellidos = apellidos;
            this.csr = csr;
            this.idusuario = idusuario;
            this.idrol = idrol;
            em = new EmpleadoManage();
        }

        public bool insertar()
        {
            return em.insertarEmpleado(this);
        }

        public bool modificar()
        {
            return em.modificarEmpleado(this);
        }

        //public bool cambiarNombreApellidos()
        //{
        //    return em.cambiarNombreApellidos(this);
        //}

        //public bool cambiarCsr()
        //{
        //    return em.cambiarCsr(this);
        //}

        //public bool cambiarRol()
        //{
        //    return em.cambiarRol(this);
        //}

        public bool eliminar()
        {
            return em.eliminarEmpleado(this);
        }

        public Empleado last()
        {
            return em.last();
        }
        public Empleado getEmpleado(int idempleado)
        {
            return em.getEmpleado(idempleado);
        }

        public List<Empleado> getAllEmpleados()
        {
            return em.getListEmpleados();
        }
    }
}
