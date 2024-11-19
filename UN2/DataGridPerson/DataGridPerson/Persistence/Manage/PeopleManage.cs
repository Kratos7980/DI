using DataGridPerson.Domain;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            lpeople = DBBroker.obtenerAgente().leer("select * from people order by id");
            foreach (List<Object> aux in lpeople)
            {
                p = new People(Int32.Parse(aux[0].ToString()));
                p.name = aux[1].ToString();
                p.age = Int32.Parse(aux[2].ToString());
                this.listPeople.Add(p);
            }

            return this.listPeople;
        }

        public void insertPeople(People p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into people (name,age) values('" +  p.name +"'," + p.age + ")");
            MessageBox.Show("Insert into people (name,age) values('" + p.name + "'," + p.age + ")");
        }

        public void lastId(People p)
        {
            List<Object> lpeople;
            lpeople = DBBroker.obtenerAgente().leer("select MAX(id) FROM people");

            if (lpeople.Any())
            {
                List<Object> aux = (List<Object>)lpeople.First();
                p.id = Convert.ToInt32(aux[0]);
            }
        }

        public void deletePeople(People p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from people where id =" + p.id);
        }
    }
}
