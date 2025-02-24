using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.domain;

namespace ReadingClub.persistence.manage
{
    internal class GenreManage
    {
        public List<Genre> selectAll()
        {
            Genre genre = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.GENERO;");
            List<Genre> genres = new List<Genre>();
            foreach (List<Object> c in aux)
            {

                genre = new Genre(Convert.ToInt32(c[0]), c[1].ToString());
                genres.Add(genre);
            }
            return genres;
        }
    }
}
