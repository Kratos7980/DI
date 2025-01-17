using DataGridPerson.Domain;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataGridPerson.Persistence.Manage
{
    class PeopleManage
    {
        public List<People> listPeople {  get; set; }

        private string path;

        public PeopleManage()
        {
            //listPeople = new List<People>();
            path = "example.json";
        }

        public List<People> readPeople()
        {
            //Read the file content
            string jsonContent = File.ReadAllText(path);

            //Deseralize the JSON content
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonContent);

            // Validate that the deserialized object is not null.
            if(rootObject == null || rootObject.personList == null)
            {
                MessageBox.Show("");
            }
            
            People p = null;
            List<People> lpeople;
            lpeople = rootObject.personList;
            
            foreach (People aux in lpeople)
            {
                p = new People(aux.id);
                p.name = aux.name;
                p.age = aux.age;
                this.listPeople.Add(p);
            }
            
        }

        public void insertPeople(People p)
        {
            //DBBroker dBBroker = DBBroker.obtenerAgente();
            //dBBroker.modificar("Insert into people (name,age) values('" +  p.name +"'," + p.age + ")");
            //MessageBox.Show("Insert into people (name,age) values('" + p.name + "'," + p.age + ")");

            RootObject rootObject = new RootObject { personList = this.listPeople };
            rootObject.personList.Add(p);
            string updatedJsonContent = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(path, updatedJsonContent);
        }

        public void lastId(People p)
        {
            //List<Object> lpeople;
            //lpeople = DBBroker.obtenerAgente().leer("select MAX(id) FROM people");

            //if (lpeople.Any())
            //{
            //    List<Object> aux = (List<Object>)lpeople.First();
            //    p.id = Convert.ToInt32(aux[0]);
            //}
        }

        public void deletePeople(People p)
        {
            //DBBroker dBBroker = DBBroker.obtenerAgente();
            //dBBroker.modificar("Delete from people where id =" + p.id);
        }
    }

    class RootObject
    {
        [JsonProperty("people")]

        public List<People> personList { get; set; }
    }
}
