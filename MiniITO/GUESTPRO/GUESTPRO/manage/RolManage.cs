using GUESTPRO.model;
using GUESTPRO.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.manage
{
    internal class RolManage
    {
        private List<Rol> listRoles;

        public RolManage()
        {
            listRoles = new List<Rol>();
        }

        public bool insertarRol(Rol r)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("insert into mydb.rol (nombrerol, descrol) values('" + r.nombrerol + "', '" + r.descrol + "')");

            if (resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool updateRol(Rol r)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.rol set nombrerol = '" + r.nombrerol + "', descrol = '" + r.descrol + "'");

            if (resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool eliminarRol(Rol r)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("delete from mydb.rol where idrol = " + r.idrol);

            if (resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public Rol getRol(int idrol)
        {
            List<Object> filas;
            Rol r = null;

            filas = DBBroker.getInstancia().select("select * from mydb.rol where idrol = " + idrol);

            foreach (List<Object> aux in filas)
            {
                r = new Rol(Int32.Parse(aux[0].ToString()));
                r.nombrerol = aux[1].ToString();
                r.descrol = aux[2].ToString();
            }
            return r;
        }

        public List<Rol> getListRoles()
        {
            List<Object> filas;
            Rol r = null;

            filas = DBBroker.getInstancia().select("select * from mydb.rol");

            foreach (List<Object> aux in filas)
            {
                r = new Rol(Int32.Parse(aux[0].ToString()));
                r.nombrerol = aux[1].ToString();
                r.descrol = aux[2].ToString();

                listRoles.Add(r);
            }
            return listRoles;
        }
    }
}
