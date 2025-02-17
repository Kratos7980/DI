using FormularioExamen.model;
using FormularioExamen.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.manage
{
    internal class ProyectoEmpleadoManage
    {
        private List<ProyectoEmpleado> listProyectosEmpleados;

        public ProyectoEmpleadoManage()
        {
            listProyectosEmpleados = new List<ProyectoEmpleado>();
        }

        public bool insertarProyectosEmpleados(ProyectoEmpleado pe)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("insert into mydb.proyecto_has_empleado (idproyecto, idempleado, fecha, costes, horas) values("
                                                           + pe.idproyecto + ", " + pe.idempleado + ", '" + pe.fecha + "', " + pe.costes + ", " + pe.horas);
            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool cambiarHoras(ProyectoEmpleado pe)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.proyecto_has_empleado set horas = " + pe.horas);

            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool eliminarProyectosEmpleados(ProyectoEmpleado pe)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("delete from mydb.proyecto_has_empleado where idempleado = " + pe.idempleado);

            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public List<ProyectoEmpleado> getProyectoEmpleados(int idproyecto)
        {
            List<Object> filas;
            ProyectoEmpleado pe = null;
            List<ProyectoEmpleado> list = new List<ProyectoEmpleado>();

            filas = DBBroker.getInstancia().select("select * from mydb.proyecto_has_empleado where idproyecto = " + idproyecto);

            foreach (List<Object> aux in filas)
            {
                pe = new ProyectoEmpleado(Int32.Parse(aux[0].ToString()), Int32.Parse(aux[1].ToString()), DateTime.Parse(aux[2].ToString()));
                pe.costes = float.Parse(aux[3].ToString());
                pe.horas = Int32.Parse(aux[4].ToString());

                list.Add(pe);
            }
            return list;
        }

        public List<ProyectoEmpleado> getProyectosEmpleados()
        {
            List<Object> filas;
            ProyectoEmpleado pe = null;

            filas = DBBroker.getInstancia().select("select * from mydb.proyecto_has_empleado");

            foreach (List<Object> aux in filas)
            {
                pe = new ProyectoEmpleado(Int32.Parse(aux[0].ToString()), Int32.Parse(aux[1].ToString()), DateTime.Parse(aux[2].ToString()));
                pe.costes = float.Parse(aux[3].ToString());
                pe.horas = Int32.Parse(aux[4].ToString());

                listProyectosEmpleados.Add(pe);
            }
            return listProyectosEmpleados;
        }

    }
}
