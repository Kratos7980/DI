using DataGridPerson.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataGridPerson.Domain
{
    internal class People
    {
        public int id { get; set; }
        public String name { get; set; }   
        public int age { get; set; }

        public PeopleManage Pm { get; set; }
        
        public People()
        {
            Pm = new PeopleManage();
        }
        public People(int id)
        {
            Pm = new PeopleManage();
            this.id = id;
        }
        public People(String name, int age)
        {
            this.name = name;
            this.age = age;
            Pm = new PeopleManage();
        }

        public void readP()
        {
            Pm.readPeople();
        }

        public List<People> getListPeople()
        {
            return Pm.listPeople;
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
