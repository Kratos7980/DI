using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.domain;

namespace ReadingClub.persistence.manage
{
    internal class BookManage
    {
        public List<Book> selectAll()
        {
            Book book = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.LIBRO;");
            List<Book> books = new List<Book>();
            foreach (List<Object> c in aux)
            {

                book = new Book(Convert.ToInt32(c[0]), c[1].ToString(), c[2].ToString(), Convert.ToInt32(c[3]), Convert.ToInt32(c[4]));
                books.Add(book);
            }
            return books;
        }
        public int getLastId()
        {
            int id = 0;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT MAX(ID) FROM examen.LIBRO;");

            if (aux.Count > 0 && aux[0] is List<object> fila && fila.Count > 0 && fila[0] != DBNull.Value)
            {
                id = Convert.ToInt32(fila[0]);
            }

            return id;
        }

        public void insert(Book p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            string query = "INSERT INTO examen.LIBRO (Titulo, Autor, IDGenero, AñoPublicacion) VALUES ('" + p.Title + "', '" + p.Author + "', " + p.Genre + " ," + p.PYear + ");";

            dBBroker.modificar(query);
        }
        public void modify(Book p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            
            string query = "UPDATE examen.LIBRO SET Titulo = '" + p.Title + "', Autor = '" + p.Author + "', IDGenero = " +p.Genre + ", AñoPublicacion=" + p.PYear + " WHERE ID = " + p.IdBook + ";";
            db.modificar(query);

        }
        public void delete(Book p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("DELETE FROM examen.Libro where ID=" + p.IdBook + ";");
        }
    }
}
