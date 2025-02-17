using FormularioExamen.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.model
{
    internal class Usuario
    {
        public int idusuario {  get; set; }
        public string nombreusuario { get; set; }
        public string passusuario { get; set; }

        private UsuarioManage um;
        public Usuario()
        {
            um = new UsuarioManage();
        }

        public Usuario(int idusuario)
        {
            this.idusuario = idusuario;
            um = new UsuarioManage();
        }

        public Usuario(int idusuario, string nombreusuario, string passusuario)
        {
            this.idusuario = idusuario;
            this.nombreusuario = nombreusuario;
            this.passusuario = passusuario;
            um = new UsuarioManage();
        }

        public bool insertar()
        {
            return um.insertarUsuario(this);
        }

        public bool cambiarNombre()
        {
            return um.cambiarNombre(this);
        }

        public bool cambiarPassword()
        {
            return um.cambiarPassword(this);
        }

        public bool eliminar()
        {
            return um.eliminarUsuario(this);
        }

        public Usuario getUsuario(int idusuario)
        {
            return um.getUsuario(idusuario);
        }

        public List<Usuario> getAllUsuarios()
        {
            return um.getListUsuarios();
        }

    }
}
