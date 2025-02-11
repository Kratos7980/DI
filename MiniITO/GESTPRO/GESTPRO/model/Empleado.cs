using GESTPRO.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GESTPRO.model
{
    internal class Empleado:Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public double Csr { get; set; }

        public int idRol {  get; set; }

        private EmpleadoManage em;

        public Empleado() { }

        public Empleado(int id)
        {
            this.Id = id;
        }

        public Empleado(string nombre, string password)
        {
            new Usuario(nombre, password);
        }

        public Empleado(string nombre, string apellido, double csr)
        {
            this.Name = nombre;
            this.Surname = apellido;
            this.Csr = csr;
        }

        public void insertEmpleado()
        {
            em = new EmpleadoManage();
            em.add(this);
        }

        public void deleteEmpleado()
        {
            em = new EmpleadoManage();
            em.remove(this);
        }

        public List<Empleado> getListEmpleado()
        {
            em = new EmpleadoManage();
            return em.readEmpleado();
        }
    }
}
