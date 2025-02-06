using DataGridPerson.Persistence;
using GESTPRO.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GESTPRO.Persistence.Manage
{
    internal class EmpleadoManage
    {

        private List<Empleado> empleados = new List<Empleado>();
        public EmpleadoManage() { }

        public void add(Empleado e)
        {
            DBBroker db = DBBroker.obtenerAgente();
            db.modificar("Insert into mydb.empleado (nombreemp,csr) values('" + e.Name + "'," + e.Csr + ")");
            MessageBox.Show("Insert into mydb.empleado (nombreemp,csr) values('" + e.Name + "'," + e.Csr + ")");
        }

        public void remove(Empleado e)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            List<Object> list = dBBroker.leer("Select idempleado from mydb.empleado where nombreemp = '" + e.Name + "'");
            foreach (List<Object> aux in list)
            {
                e.Id = Int32.Parse(aux[0].ToString());
            }

            dBBroker.modificar("Delete from mydb.usuario where idusuario = " + e.Id);
        }

        public void modify(Empleado e)
        {
            //

        }

        public List<Empleado> readEmpleado()
        {
            empleados = new List<Empleado>();
            Empleado e = null;
            List<Object> lusuario;
            lusuario = DBBroker.obtenerAgente().leer("select idempleado, nombreemp from mydb.empleado order by idempleado");
            foreach (List<Object> aux in lusuario)
            {
                e = new Empleado(Int32.Parse(aux[0].ToString()));
                e.Name = aux[1].ToString();
                this.empleados.Add(e);
            }

            return this.empleados;
        }
    }
}
