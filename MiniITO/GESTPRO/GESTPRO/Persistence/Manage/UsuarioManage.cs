using DataGridPerson.Persistence;
using GESTPRO.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GESTPRO.Persistence.Manage
{
    internal class UsuarioManage
    {
        private List<Usuario> usuarios;

        public void add(Usuario u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into mydb.usuario (nombreusuario,passusuario) values('" + u.Name + "','" + u.Password +"')");
            MessageBox.Show("Insert into mydb.usuario (nombreusuario,passusuario) values('" + u.Name + "','" + u.Password + "')");
        }

        public void remove(Usuario u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            List<Object> list =  dBBroker.leer("Select idusuario from mydb.usuario where nombreusuario = '" + u.Name + "'");
            foreach (List<Object> aux in list)
            {
                u.Id = Int32.Parse(aux[0].ToString());
            }

            dBBroker.modificar("Delete from mydb.usuario where idusuario = " + u.Id);
        }

        public List<Usuario> readUsuario()
        {
            usuarios = new List<Usuario>();
            Usuario u = null;
            List<Object> lusuario;
            lusuario = DBBroker.obtenerAgente().leer("select idusuario, nombreusuario from mydb.usuario order by idusuario");
            foreach (List<Object> aux in lusuario)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.Name = aux[1].ToString();
                this.usuarios.Add(u);
            }

            return this.usuarios;
        }
    }
}
