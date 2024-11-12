using DataGridPerson.Domain;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataGridPerson.Persistence.Manage
{
    class PeopleManage
    {
        public List<People> listPeople {  get; set; }   

        public PeopleManage()
        {
            listPeople = new List<People>();
        }

        public List<People> readPeople()
        {
            /*List<People> list = new List<People>();
            list.Add(new People("Carlos", "Garcia", 20));*/

            People p = null;
            List<Object> lpeople;
            lpeople = DBBroker.obtenerAgente().leer("select * from people order by idpeople");
            foreach (List<Object> aux in lpeople)
            {
                p = new People(Int32.Parse(aux[0].ToString()));
                p.Name = aux[1].ToString();
                p.Age = Int32.Parse(aux[2].ToString());
                this.listPeople.Add(p);
            }

            return this.listPeople;
        }
    }
}
