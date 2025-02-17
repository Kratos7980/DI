using FormularioExamen.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.model
{
    internal class Rol
    {
        public int idrol { get; set; }
        public string nombrerol { get; set; }
        public string descrol { get; set; }

        private RolManage rm;

        public Rol()
        {
            rm = new RolManage();
        }

        public Rol(int idrol)
        {
            this.idrol = idrol;
            rm = new RolManage();
        }

        public Rol(int idrol, string nombrerol, string descrol)
        {
            this.idrol = idrol;
            this.nombrerol = nombrerol;
            this.descrol = descrol;
            rm = new RolManage();
        }

        public bool insertar()
        {
            return rm.insertarRol(this);
        }

        public bool update()
        {
            return rm.updateRol(this);
        }

        public bool delete()
        {
            return rm.eliminarRol(this);
        }

        public Rol getRol(int idrol)
        {
            return rm.getRol(idrol);
        }

        public List<Rol> getAllRoles()
        {
            return rm.getListRoles();
        }
    }
}
