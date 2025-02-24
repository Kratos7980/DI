using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.persistence.manage;

namespace ReadingClub.domain
{
    internal class Member
    {
        public int IdMember { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        private MemberManage mm = new MemberManage();
        public Member() { }
        public Member(int id, string name, DateTime birthdate, string email, int phone)
        {
            IdMember = id;
            Name = name;
            BirthDate = birthdate;
            Email = email;
            Phone = phone;
        }
       
        public Member(string name, DateTime birthdate, string email, int phone)
        {
            Name = name;
            BirthDate = birthdate;
            BirthDate = birthdate;
            Email = email;
            Phone = phone;
            IdMember = mm.getLastId() + 1;
        }
        public void insert()
        {
            mm.insert(this);
        }
        public List<Member> getMembers()
        {
            return mm.selectAll();
        }
        public void modify()
        {
            mm.modify(this);
        }
        public void delete()
        {
            mm.delete(this);
        }
        public override string ToString()
        {
            return IdMember + " " + Name;
        }


    }
}
