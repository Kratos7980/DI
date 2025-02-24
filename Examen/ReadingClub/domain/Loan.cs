using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.persistence.manage;

namespace ReadingClub.domain
{
    internal class Loan
    {
        public Member MemberL { get; private set; }
        public Book BookL { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        private LoanManage lm = new LoanManage();

        public Loan() { }

        public Loan(Member member, Book book, DateTime loanDate, DateTime returnDate)
        {
            MemberL = member;
            BookL = book;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }
        public List<Loan> getLoans()
        {
            return lm.selectAll();
        }
        public void insert()
        {
            lm.insert(this);
        }
        
        public void delete()
        {
            lm.delete(this);
        }

    }
}
