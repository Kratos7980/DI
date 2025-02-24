using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingClub.domain;

namespace ReadingClub.persistence.manage
{
    internal class MemberManage
    {
        public List<Member> selectAll()
        {
            Member user = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.SOCIO;");
            List<Member> members = new List<Member>();
            foreach (List<Object> c in aux)
            {
                user = new Member(Convert.ToInt32(c[0]), c[1].ToString(), Convert.ToDateTime(c[2]), c[3].ToString(), Convert.ToInt32(c[4]));
                members.Add(user);
            }
            return members;
        }
        public int getLastId()
        {
            int id = 0;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT MAX(ID) FROM examen.SOCIO;");

            if (aux.Count > 0 && aux[0] is List<object> fila && fila.Count > 0 && fila[0] != DBNull.Value)
            {
                id = Convert.ToInt32(fila[0]);
            }

            return id;
        }

        public void insert(Member p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            string date = p.BirthDate.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "INSERT INTO examen.SOCIO (Nombre, FechaNacimiento, Email, Telefono) VALUES ('" + p.Name + "', '" + date + "', '" + p.Email + "' ," + p.Phone + ");";

            dBBroker.modificar(query);
        }
        public void modify(Member p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            string date = p.BirthDate.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "UPDATE examen.SOCIO SET Nombre = '" + p.Name + "', Email = '" + p.Email + "', FechaNacimiento = '" + date + "', Telefono=" + p.Phone + " WHERE ID = " + p.IdMember + ";";
            db.modificar(query);

        }
        public void delete(Member p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("DELETE FROM examen.SOCIO where ID=" + p.IdMember + ";");
        }

    }
}
