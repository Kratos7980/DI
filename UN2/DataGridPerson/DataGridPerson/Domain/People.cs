using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataGridPerson.Domain
{
    class People
    {
        private String name;
        private String surName;
        private int age;
        private int id;

        public People(int id)
        {
            this.id = id;
        }

        public People(int id, String name, String surName, int age)
        {
            this.id = id;
            this.name = name;
            this.surName = surName;
            this.age = age;
        }


        public string Name { get => this.name; set => this.name = value; }
        public string SurName { get => this.surName; set => this.surName = value; }
        public int Age { get => this.age; set => this.age = value; }
    }
}
