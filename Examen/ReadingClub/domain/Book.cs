using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.persistence.manage;

namespace ReadingClub.domain
{
    internal class Book
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Genre { get; set; }
        public string GenreString { get; set; }
        public int PYear { get; set; }
        private BookManage bm = new BookManage();
        private GenreManage gm = new GenreManage();

        public Book() { }
        public Book(int id, string title, string author, int genre, int pyear)
        {
            IdBook = id;
            Title = title;
            Author = author;
            Genre = genre;
            GenreString = gm.selectAll().Find(x => x.IdGenre == genre).Name;
            PYear = pyear;
        }
        public Book(string title, string author, int genre, int pyear)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PYear = pyear;
            GenreString = gm.selectAll().Find(x => x.IdGenre == genre).Name;
        }
        public List<Book> getBooks()
        {
            return bm.selectAll();
        }
        public void insert()
        {
            bm.insert(this);
        }
        public void modify()
        {
            GenreString = gm.selectAll().Find(x => x.IdGenre == Genre).Name;
            bm.modify(this);
        }
        public void delete()
        {
            bm.delete(this);
        }
        public override string ToString()
        {
            return IdBook + " " + Title;
        }
    }
}
