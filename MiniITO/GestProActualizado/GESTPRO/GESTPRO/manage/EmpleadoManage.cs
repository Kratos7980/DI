using FormularioExamen.model;
using FormularioExamen.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.manage
{
    internal class EmpleadoManage
    {
        private List<Empleado> listEmpleados;

        public EmpleadoManage()
        {
            listEmpleados = new List<Empleado>();
        }

        public bool insertarEmpleado(Empleado e)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("insert into mydb.empleado (nombreemp, apellidos, csr, idusuario, idrol) values('"
                                                            + e.nombreemp + "', '" + e.apellidos + "', " + e.csr + ", " + e.idusuario + ", "
                                                            + e.idrol + ")");
            if (resultado != 0)
            {
                ok = true;   
            }
            return ok;
        }

        public bool cambiarNombreApellidos(Empleado e)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.empleado set nombreemp = '" + e.nombreemp + "', apellidos = '" + e.apellidos 
                                                           + "' where idempleado = " + e.idempleado);

            if(resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public bool cambiarCsr(Empleado e)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.empleado set csr = " + e.csr + " where idempleado = " + e.idempleado);

            if(resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public bool cambiarRol(Empleado e)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.empleado set idrol = " + e.idrol + " where idempleado = " + e.idempleado);

            if(resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public bool eliminarEmpleado(Empleado e)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("delete from mydb.empleado where idempleado = " + e.idempleado);

            if(resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public Empleado getEmpleado(int idempleado)
        {
            Empleado e = null;
            List<Object> fila;

            fila = DBBroker.getInstancia().select("select * from mydb.empleado where idempleado = " + idempleado);

            foreach(List<Object> aux in fila)
            {
                e = new Empleado(Int32.Parse(aux[0].ToString()));
                e.nombreemp = aux[1].ToString();
                e.apellidos = aux[2].ToString();
                e.csr = float.Parse(aux[3].ToString());
                e.idusuario = Int32.Parse(aux[4].ToString());
                e.idrol = Int32.Parse(aux[5].ToString());
            }

            return e;
        }

        public List<Empleado> getListEmpleados()
        {
            List<Object> fila;
            Empleado e = null;
            fila = DBBroker.getInstancia().select("select * from mydb.empleado");

            foreach(List<Object> aux in fila)
            {
                e = new Empleado(Int32.Parse(aux[0].ToString()));
                e.nombreemp = aux[1].ToString();
                e.apellidos = aux[2].ToString();
                e.csr = float.Parse(aux[3].ToString());
                e.idusuario = Int32.Parse (aux[4].ToString());
                e.idrol = Int32.Parse(aux[5].ToString());

                this.listEmpleados.Add(e);
            }

            return this.listEmpleados;
        }
    }
}
