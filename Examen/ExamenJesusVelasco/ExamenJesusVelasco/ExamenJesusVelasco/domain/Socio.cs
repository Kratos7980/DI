using ExamenJesusVelasco.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.domain
{
    public class Socio
    {

        public SocioManage sm;
        public Socio()
        {
            sm = new SocioManage();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public Socio(int id)
        {
            sm = new SocioManage();
            this.Id = id;
        }
        public Socio(string nombre, DateTime fechaNacimiento, string email, int telefono)
        {
            sm = new SocioManage();
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
        }

        public Socio(int id, string nombre, DateTime fechaNacimiento, string email, int telefono)
        {
            sm = new SocioManage();
            Id = id;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
        }

        public List<Socio> gLista()
        {
            return sm.selectAll();
        }
        public void insertar()
        {
            sm.insertar(this);
        }
        public void modificar()
        {
            sm.modificar(this);
        }
        public void borrar()
        {
            sm.borrar(this);
        }
        public override string ToString()
        {
            return Id+" "+Nombre;
        }
    }
}
