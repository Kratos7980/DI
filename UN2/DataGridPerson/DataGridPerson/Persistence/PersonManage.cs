using DataGridPerson.Domain;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataGridPerson.Persistance
{
    class PersonManage
    {
        private DataTable table;

        public PersonManage()
        {
            this.table = new DataTable();
        }

        public static List<Person> leePersonas()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person("Carlos", "Garcia", 20));

            return list;
        }
    }
}
