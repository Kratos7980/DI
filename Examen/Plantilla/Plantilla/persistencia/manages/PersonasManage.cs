using Mysqlx.Crud;
using Plantilla.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Plantilla.persistencia.manages
{
    internal class PersonasManage
    {
        private DataTable table { get; set; }
        private List<Persona> listaPersonas { get; set; }
        int Id;

        public PersonasManage()
        {
            table = new DataTable();
            listaPersonas = new List<Persona>();
        }

        // SIMULACION DE LECTURA DE BASE DE DATOS
        public List<Persona> leerPersonas()
        {
            Persona persona = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from mydb.persona;"); ;
            foreach (List<Object> c in aux)
            {
                persona = new Persona(/*ID*/Convert.ToInt32(c[0]),/*NOMBRE*/ c[1].ToString(), /*APELLIDOS*/c[2].ToString());
                listaPersonas.Add(persona);
            }

            return listaPersonas;
        }

        public void insertarPersona(Persona p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            MessageBox.Show("Insert into mydb.persona (nombre,apellidos) values('" + p.Nombre + "','" + p.Apellidos + "')");
            dbBroker.modificar("Insert into mydb.persona (nombre,apellidos) values('" + p.Nombre + "','" + p.Apellidos + "')");
        }

        public void eliminarPersona(Persona p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("delete from mydb.persona where idPersona = " + p.Id);
            dBBroker.modificar("delete from mydb.persona where idPersona = " + p.Id);
        }

        public void actualizarPersona(Persona p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("update mydb.persona set nombre = '" + p.Nombre + "', apellidos ='" + p.Apellidos + "' where idPersona = " + p.Id);
            dBBroker.modificar("update mydb.persona set nombre = '" + p.Nombre + "', apellidos ='" + p.Apellidos + "' where idPersona = " + p.Id);
        }

        //public void modificarPersona(Persona p)

        
    }
}
