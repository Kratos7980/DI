using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.persistence.manage;

namespace ReadingClub.domain
{
    internal class Genre
    {
        public int IdGenre { get; set; }
        public string Name { get; set; }
        GenreManage gm = new GenreManage();
        public Genre() { }
        public Genre(int id, string name)
        {
            this.IdGenre = id;
            this.Name = name;
        }
        public List<Genre> getGenres()
        {
            return gm.selectAll();
        }
        public override string ToString()
        {
            return IdGenre + " " + Name;
        }
    }
}
