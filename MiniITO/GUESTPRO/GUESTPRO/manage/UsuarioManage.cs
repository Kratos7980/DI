using GUESTPRO.model;
using GUESTPRO.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.manage
{
    internal class UsuarioManage
    {
        private List<Usuario> listUsuarios;

        public UsuarioManage()
        {
            listUsuarios = new List<Usuario>();
        }

        public bool insertarUsuario(Usuario u)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("insert into mydb.usuario (nombreusuario, passusuario) values('"
                                                           + u.nombreusuario + "', '" + u.passusuario + "')");
            if (resultado != 0)
            {
                ok = true;
            }

            return ok;
        }

        public bool cambiarNombre(Usuario u)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.usuario set nombreusuario = '" + u.nombreusuario + "'");

            if (resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool cambiarPassword(Usuario u)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("update mydb.usuario set passusuario = '" + u.passusuario + "'");

            if (resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public bool eliminarUsuario(Usuario u)
        {
            bool ok = false;

            int resultado = DBBroker.getInstancia().update("delete from mydb.usuario where idusuario = " + u.idusuario);

            if (resultado != 0)
            {
                ok = true;
            }
            return ok;
        }

        public Usuario last()
        {
            Usuario usuario = null;
            List<Object> filas;

            filas = DBBroker.getInstancia().select("select max(idusuario) from mydb.usuario");

            foreach (List<Object> aux in filas)
            {
                usuario = new Usuario(Int32.Parse(aux[0].ToString()));
            }
            return usuario;
        }
        public Usuario getUsuario(int idusuario)
        {
            Usuario usuario = null;
            List<Object> filas;

            filas = DBBroker.getInstancia().select("select * from mydb.usuario where idusuario = " + idusuario);

            foreach (List<Object> aux in filas)
            {
                usuario = new Usuario(Int32.Parse(aux[0].ToString()));
                usuario.nombreusuario = aux[1].ToString();
                usuario.passusuario = aux[2].ToString();
            }
            return usuario;
        }

        public List<Usuario> getListUsuarios()
        {
            List<Object> filas;
            Usuario u = null;

            filas = DBBroker.getInstancia().select("select * from mydb.usuario");

            foreach (List<Object> aux in filas)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.nombreusuario = aux[1].ToString();
                u.passusuario = aux[2].ToString();

                listUsuarios.Add(u);
            }
            return listUsuarios;
        }
    }
}
