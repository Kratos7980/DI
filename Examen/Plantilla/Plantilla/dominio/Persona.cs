using Plantilla.persistencia.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantilla.dominio
{
    internal class Persona
    {
        private int id;
        private String nombre;
        private String apellidos;
        private List<Persona> lista;
        public PersonasManage pm;

        public Persona()
        {
            pm = new PersonasManage();
        }
        public Persona(int id)
        {
            pm = new PersonasManage();
            this.id = id;
        }


        public Persona(int id, string nombre, string apellidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            pm = new PersonasManage();
        }

        public Persona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            pm = new PersonasManage();
        }


        //VALORES DEL DATAGRID
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }


        public List<Persona> getPersonas()
        {
            lista = pm.leerPersonas();
            return lista;
        }

        public void insertar()
        {
            pm.insertarPersona(this);
            Id++;
        }

        public void eliminar()
        {
            pm.eliminarPersona(this);
            Id--;
        }

        public void actualizar()
        {
            pm.actualizarPersona(this);
        }

    }
}
