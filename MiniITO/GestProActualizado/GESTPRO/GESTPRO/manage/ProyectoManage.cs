using FormularioExamen.model;
using FormularioExamen.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.manage
{
    internal class ProyectoManage
    {
        private List<Proyecto> listProyectos;

        public ProyectoManage()
        {
            listProyectos = new List<Proyecto>();
        }

        public bool insertarProyecto(Proyecto p)
        {
            bool ok = false;
            int resultado = DBBroker.getInstancia().update("insert into mydb.proyecto (codigoproy, nombreproy, descproy, presupuesto) values('" 
                                            + p.codigoproy + "', '" + p.nombreproy + "', '" + p.descproy + "', " + p.presupuesto + ")");
            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool cambianNombreProyecto(Proyecto p)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.proyecto set nombreproy = '" + p.nombreproy + "' where codigoproy = '" + p.codigoproy + "')");

            if(resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public bool asociarAFactura(Proyecto p)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.proyecto set idfactura = " + p.idfactura + " where codigoproy = '" + p.codigoproy + "')");

            if(resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public bool eliminarProyecto(Proyecto p)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("delete from mydb.proyecto where idproyecto = " + p.idproyecto + ")");

            if(resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public Proyecto getProyecto(int idproyecto)
        {
            List<Object> fila;
            Proyecto project = null;

            fila = DBBroker.getInstancia().select("select * from mydb.proyecto where idproyecto = '" + idproyecto + "')");

            foreach(List<Object> aux in fila)
            {
                project = new Proyecto(Int32.Parse(aux[0].ToString()));
                project.codigoproy = aux[1].ToString();
                project.nombreproy = aux[2].ToString();
                project.descproy = aux[3].ToString();
                project.presupuesto = float.Parse(aux[4].ToString());
                if (aux[5].ToString() != null)
                {
                    project.idfactura = Int32.Parse(aux[5].ToString());
                }
            }

            return project;
        }

        public List<Proyecto> getAllProyecto()
        {
            List<Object> fila;
            Proyecto project = null;

            fila = DBBroker.getInstancia().select("select * from mydb.proyecto");

            foreach(List<Object> aux in fila)
            {
                project = new Proyecto(Int32.Parse(aux[0].ToString()));
                project.codigoproy = aux[1].ToString();
                project.nombreproy = aux[2].ToString();
                project.descproy = aux[3].ToString();
                project.presupuesto = float.Parse(aux[4].ToString());
                if (aux[5].ToString() != null)
                {
                    project.idfactura = Int32.Parse(aux[5].ToString());
                }
                this.listProyectos.Add(project);
            }
            return this.listProyectos;
        }

        public Dictionary<String,int> countEmpleRol(Proyecto p)
        {
            List<Object> roles;
            List<Object> numEmpleadosRol;
            Dictionary<String, int> resultado = new Dictionary<string, int>();
            roles = DBBroker.getInstancia().select("select idrol, nombrerol from mydb.rol");
            foreach(List<Object> aux in roles)
            {
                numEmpleadosRol = DBBroker.getInstancia().select("select count(pe.idempleado) from mydb.proyecto_has_empleado pe, mydb.empleado e where pe.idempleado = e.idempleado " +
                                                                 "and e.idrol = " + Int32.Parse(aux[0].ToString()) + "and pe.idproyecto = " + p.idproyecto + ")");
                resultado.Add(aux[1].ToString(), Int32.Parse(numEmpleadosRol[0].ToString()));
            }
          

            return resultado;
        }

    }
}
