using DataGridPerson.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTPRO.model
{
    internal class Proyecto
    {
        public String id { get; set; }
        public String name { get; set; }

        public ProyectoManage Pm { get; set; }

        public Proyecto()
        {
            Pm = new ProyectoManage();
        }
        public Proyecto(String id)
        {
            Pm = new ProyectoManage();
            this.id = id;
        }
        public Proyecto(String id, String name)
        {
            this.id = id;
            this.name = name;
            Pm = new ProyectoManage();
        }

        public void readP()
        {
            Pm.readPeople();
        }

        public List<Proyecto> getListPeople()
        {
            return Pm.listProyecto;
        }

        public void insert()
        {
            Pm.insertPeople(this);
        }

        public void last()
        {
            Pm.lastId(this);
        }

        public void delete()
        {
            Pm.deletePeople(this);
        }
    }
}
