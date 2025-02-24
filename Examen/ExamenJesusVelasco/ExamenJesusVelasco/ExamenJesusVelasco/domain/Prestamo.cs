using ExamenJesusVelasco.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.domain
{
    public class Prestamo
    {
        public Socio Socio {  get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public PrestamoManage pm;
        public Prestamo()
        {
            pm = new PrestamoManage();
        }
        public Prestamo(Socio socio, Libro libro, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            pm = new PrestamoManage();
            Socio = socio;
            Libro = libro;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }
        public List<Prestamo> selectAll()
        {
            return pm.selectAll();
        }
        public void insertar()
        {
            pm.insertar(this);
        }
        public void modificar()
        {
            pm.modificar(this);
        }
        public void borrar()
        {
            pm.borrar(this);
        }
    }
}
