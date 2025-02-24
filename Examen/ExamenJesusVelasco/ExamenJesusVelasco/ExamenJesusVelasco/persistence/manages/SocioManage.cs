using ExamenJesusVelasco.domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.persistence.manages
{
    public class SocioManage
    {
        public List<Socio> selectAll()
        {
            Socio user = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.SOCIO;");
            List<Socio> listaUsuarios = new List<Socio>();
            foreach (List<Object> c in aux)
            {
                user = new Socio(Convert.ToInt32(c[0]), c[1].ToString(), Convert.ToDateTime(c[2]), c[3].ToString(), Convert.ToInt32(c[4]));
                listaUsuarios.Add(user);
            }
            return listaUsuarios;
        }
        public void insertar(Socio p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            string fecha = p.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss");
            string consulta = "INSERT INTO examen.SOCIO (Nombre, FechaNacimiento, Email, Telefono) VALUES ('" + p.Nombre + "', '" + fecha + "', '" + p.Email + "' ," + p.Telefono + ");";

            dBBroker.modificar(consulta);
        }
        public void modificar(Socio p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            string fecha = p.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss");
            string consulta = "UPDATE examen.SOCIO SET Nombre = '" + p.Nombre + "', Email = '" + p.Email + "', FechaNacimiento = '" + fecha + "', Telefono=" + p.Telefono + " WHERE ID = " + p.Id + ";";
            db.modificar(consulta);

        }
        public void borrar(Socio p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("DELETE FROM examen.SOCIO where ID=" + p.Id + ";");
        }
    }
}
