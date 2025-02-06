using GESTPRO.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTPRO.model
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        private UsuarioManage um;
        public Usuario()
        {
            um = new UsuarioManage();
        }

        public Usuario(int id)
        {
            this.Id = id;
            um = new UsuarioManage();
        }

    public Usuario(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            um = new UsuarioManage();
        }

        public void insert()
        {
            um = new UsuarioManage();
            um.add(this);
        }

        public void delete()
        {
            um = new UsuarioManage();
            um.remove(this);
        }

        public List<Usuario> getListUsuarios()
        {
            return um.readUsuario();
        }

        public String cifrar(string pass)
        {

            StringBuilder bd = new StringBuilder();

            for(int i = 0; i < pass.Length; i++)
            {
                int n = pass[i] + 3;
                char c = (char) n;
                bd.Append(c);
            }

            return bd.ToString();
        }

        

    }
}
