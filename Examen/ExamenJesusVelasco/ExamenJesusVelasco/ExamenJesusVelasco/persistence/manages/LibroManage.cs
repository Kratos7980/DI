using ExamenJesusVelasco.domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.persistence.manages
{
    public class LibroManage
    {
        public List<Libro> selectAll()
        {
            Libro libro = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.LIBRO;");
            List<Libro> listaUsuarios = new List<Libro>();
            foreach (List<Object> c in aux)
            {
                //  public Libro(int id, string titulo, int año, string autor, int genero)
                libro = new Libro(Convert.ToInt32(c[0]), c[1].ToString(),c[2].ToString(), Convert.ToInt32(c[3]), Convert.ToInt32(c[4]));
                listaUsuarios.Add(libro);
            }
            return listaUsuarios;
        }
        public void insertar(Libro l)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            string consulta = "INSERT INTO examen.LIBRO (Titulo, Autor, IDGenero, AñoPublicacion) VALUES ('" + l.Titulo + "', '" + l.Autor + "', " + l.Genero + " ," + l.Año + ");";

            dBBroker.modificar(consulta);
        }
        public void modificar(Libro p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            string consulta = "UPDATE examen.LIBRO SET Titulo = '" + p.Titulo + "', Autor = '" + p.Autor + "', IDGenero = '" + p.Genero + "', AñoPublicacion=" + p.Año + " WHERE ID = " + p.Id + ";";
            db.modificar(consulta);

        }
        public void borrar(Libro p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("DELETE FROM examen.LIBRO where ID=" + p.Id + ";");
        }
    }
}
