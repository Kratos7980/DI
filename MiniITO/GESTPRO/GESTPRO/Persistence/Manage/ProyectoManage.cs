using GESTPRO.model;
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
    class ProyectoManage
    {
        public List<Proyecto> listProyecto {  get; set; }  
        public List<Empleado> listEmpleado { get; set; }

        public ProyectoManage()
        {
            listProyecto = new List<Proyecto>();
            listEmpleado = new List<Empleado>();
           
        }

        public List<Proyecto> readProject()
        {
            /*List<People> list = new List<People>();
            list.Add(new People("Carlos", "Garcia", 20));*/

            Proyecto p = null;
            List<Object> lpeople;
            lpeople = DBBroker.obtenerAgente().leer("select * from mydb.proyecto order by idproyecto");
            foreach (List<Object> aux in lpeople)
            {
                p = new Proyecto(aux[0].ToString());
                p.id = aux[0].ToString();
                p.name = aux[1].ToString();
                this.listProyecto.Add(p);
            }

            return this.listProyecto;
        }

        public List<int> getNumEmple(int idProyecto)
        {
         
        }

        public List<String> getRolesProyecto(int idProyecto)
        {
            List<String> listRol = new List<String>();
            List<Object> fila;
            fila = DBBroker.obtenerAgente().leer("select r.nombrerol from mydb.rol r inner join mydb.empleado e on r.idrol = e.rol_idrol inner join mydb.proyecto_has_empleado pe on pe.idempleado = e.idempleado where pe.idproyecto = " + idProyecto);
            foreach(Object aux in fila)
            {
                listRol.Add(aux.ToString());
            }
            return listRol;
        }
        public string getDate(int idProyecto)
        {
            Object fila;
            fila = DBBroker.obtenerAgente().leer("select fecha from mydb.proyecto_has_empleado where idproyecto = " + idProyecto);
            return (string) fila;
        }

        public int totalCost(int idProyecto)
        {
            Object fila;
            fila = DBBroker.obtenerAgente().leer("select sum(costes) from mydb.proyecto_has_empleado where idproyecto = " + idProyecto);
            return (int) fila;
        }
        public void insertPeople(Proyecto p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into mydb.proyecto (codigoproy,nombreproy) values('" + p.id +"','" + p.name + "')");
            MessageBox.Show("Insert into mydb.proyecto (codigoproy,nombreproy) values(" + p.id + ",'" + p.name + "')");
        }

        public void lastId(Proyecto p)
        {
            List<Object> lpeople;
            lpeople = DBBroker.obtenerAgente().leer("select MAX(codigoproy) FROM mydb.proyecto");

            if (lpeople.Any())
            {
                List<Object> aux = (List<Object>)lpeople.First();
                p.id = aux[0].ToString();
            }
        }

        public void deletePeople(Proyecto p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from mydb.proyecto where codigoproy ='" + p.id+"'");
        }
    }
}
