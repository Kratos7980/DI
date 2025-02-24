using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.domain;

namespace ReadingClub.persistence.manage
{
    internal class LoanManage
    {
        
        private List<Member> members = new List<Member>();
        private List<Book> books = new List<Book>();

        public List<Loan> selectAll()
        {
            Loan loan = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.PRESTAMO;");
            List<Loan> loans = new List<Loan>();
            foreach (List<Object> c in aux)
            {
                Member member = new Member();
                members = member.getMembers();
                Book book = new Book();
                books = book.getBooks();
                member = members.Find(x => x.IdMember == Convert.ToInt32(c[0]));
                book = books.Find(x => x.IdBook == Convert.ToInt32(c[1]));
                loan = new Loan(member, book, Convert.ToDateTime(c[2]), Convert.ToDateTime(c[3]));
                loans.Add(loan);
            }
            return loans;
        }
        public void insert(Loan loan)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            string dateLoan = loan.LoanDate.ToString("yyyy-MM-dd HH:mm:ss");
            string dateReturn = loan.ReturnDate.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "INSERT INTO examen.PRESTAMO (IDSocio, IDLibro, FechaPrestamo, FechaDevolucion) VALUES (" + loan.MemberL.IdMember + ", " + loan.BookL.IdBook + ", '" + dateLoan + "' ,'" + dateReturn + "');";

            dBBroker.modificar(query);
        }
        
        public void delete(Loan loan)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("DELETE FROM examen.PRESTAMO where IDSocio=" + loan.MemberL.IdMember + " AND IDLibro=" + loan.BookL.IdBook + ";");
        }
    }
}
