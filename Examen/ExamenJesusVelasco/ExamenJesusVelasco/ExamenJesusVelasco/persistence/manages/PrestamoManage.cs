using ExamenJesusVelasco.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.persistence.manages
{
    public class PrestamoManage
    {
        public List<Prestamo> selectAll()
        {
            Prestamo user = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.PRESTAMO;");
            List<Prestamo> listaUsuarios = new List<Prestamo>();
            foreach (List<Object> c in aux)
            {
                Socio socio = new Socio(Convert.ToInt32(c[0]));
                user = new Prestamo(socio, new Libro(Convert.ToInt32(c[1])), Convert.ToDateTime(c[2]), Convert.ToDateTime(c[3]));
                listaUsuarios.Add(user);
            }
            return listaUsuarios;
        }
        public void insertar(Prestamo p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();

            string fechaPres = p.FechaPrestamo.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaDev=p.FechaDevolucion.ToString("yyyy-MM-dd HH:mm:ss");
            string consulta = "INSERT INTO examen.PRESTAMO (IDSocio, IDLibro, FechaPrestamo, FechaDevolucion) VALUES (" + p.Socio.Id + ", " + p.Libro.Id + ", '" + fechaPres + "' ,'" + fechaDev + "');";

            dBBroker.modificar(consulta);
        }
        public void modificar(Prestamo p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            string fechaPres = p.FechaPrestamo.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaDev = p.FechaDevolucion.ToString("yyyy-MM-dd HH:mm:ss");
            string consulta = "UPDATE examen.PRESTAMO SET FechaPrestamo = '" + fechaPres + "', FechaDevolucion='" + fechaDev + "' WHERE IDSocio = " + p.Socio.Id + " AND IDLibro="+p.Libro.Id+";";
            db.modificar(consulta);

        }
        public void borrar(Prestamo p)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("DELETE FROM examen.PRESTAMO where IDSocio=" + p.Socio.Id + " AND IDLibro="+p.Libro.Id+";");
        }
    }
}

