using GUESTPRO.model;
using GUESTPRO.persistence;
using GUESTPRO.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUESTPRO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Proyecto> listProyectos;
        private List<Empleado> listEmpleados;
        private List<Usuario> listUsuarios;
        private List<ProyectoEmpleado> listProyEmp;
        private int numFactura;
        private DataTable dt;
        public MainWindow()
        {
            InitializeComponent();

            inicializarProyecto();
            inicializarEmpleado();
            inicializarUsuario();
            inicializarGestion();
        }

        private void inicializarProyecto()
        {
            Proyecto proyecto = new Proyecto();
            listProyectos = proyecto.getAllProyectos();
            dataProyecto.ItemsSource = listProyectos;
            cbProyectos.ItemsSource = listProyectos;
            cbProyectos.DisplayMemberPath = "nombreproy";
            
        }

        private void inicializarEmpleado()
        {
            Empleado empleado = new Empleado();

            listEmpleados = empleado.getAllEmpleados();
            dtgEmpleados.ItemsSource = listEmpleados;
            cbEmpleados.ItemsSource = listEmpleados;
            cbEmpleados.DisplayMemberPath = "nombreemp";
        }

        private void inicializarUsuario()
        {
            Usuario usuario = new Usuario();
            listUsuarios = usuario.getAllUsuarios();
            cbUsuarios.ItemsSource = listUsuarios;
            cbUsuarios.DisplayMemberPath = "nombreusuario";
        }

        private void inicializarGestion()
        {
            ProyectoEmpleado pe = new ProyectoEmpleado();
            listProyEmp = pe.getAllProyEmp();
            foreach(ProyectoEmpleado proyectoEmpleado in listProyEmp)
            {
                int index = listProyectos.FindIndex(p => p.idproyecto == proyectoEmpleado.idproyecto);
                proyectoEmpleado.nombreproygestion = listProyectos[index].nombreproy;
            }

            foreach (ProyectoEmpleado proyectoEmpleado in listProyEmp)
            {
                int index = listEmpleados.FindIndex(e => e.idempleado == proyectoEmpleado.idempleado);
                proyectoEmpleado.nombreempgestion = listEmpleados[index].nombreemp;
            }

            dtgGestion.ItemsSource = listProyEmp;
        }


        // TABITEM PROYECTO
        private void startProyecto()
        {
            txtCodigoProy.Clear();
            txtNombreProy.Clear();
            txtDescProy.Clear();
            txtPresupuestoProy.Clear();

        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            listProyectos.Where(p => p.nombreproy.Contains(textBuscar.Text)).ToList().ForEach(p =>
            {
                listProyects.Items.Add(p);
            });

        }

        private void dataProyecto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataProyecto.SelectedItems.Count > 0)
            {
                btnAñadir.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                Proyecto proyecto = (Proyecto)dataProyecto.SelectedItems[0];
                txtCodigoProy.Text = proyecto.codigoproy;
                txtNombreProy.Text = proyecto.nombreproy;
                txtDescProy.Text = proyecto.descproy;
                txtPresupuestoProy.Text = proyecto.presupuesto.ToString();
            }
        }

        private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            List<String> listN = new List<String>();
            listN.Add("Allegro");
            listN.Add("Velneo");
            listN.Add("SAP");
            listN.Add("Naturgy");
            listN.Add("Santander");
            listN.Add("MutuaMadrileña");

            for (int i = 1; i <= 20; i++)
            {
                Random random = new Random();
                String nombre = listN[random.Next(0, listN.Count)];
                String codigo = "MTR" + i + nombre + DateTime.Now.Year;
                Proyecto p = new Proyecto(codigo, nombre, "", random.Next(1000, 5001),0);
                p.insertar();
                p.idproyecto =p.last().idproyecto;
                ((List<Proyecto>)dataProyecto.ItemsSource).Add(p);
                dataProyecto.Items.Refresh();
                cbProyectos.Items.Refresh();
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            Proyecto proyecto = new Proyecto();
            
            proyecto.codigoproy = txtCodigoProy.Text;
            proyecto.nombreproy = txtNombreProy.Text;
            proyecto.descproy = txtDescProy.Text;
            proyecto.presupuesto = float.Parse(txtPresupuestoProy.Text);
            proyecto.idfactura = 0;
            proyecto.insertar();
            proyecto.idproyecto = proyecto.last().idproyecto;

            ((List<Proyecto>)dataProyecto.ItemsSource).Add(proyecto);
            dataProyecto.Items.Refresh();
            cbProyectos.Items.Refresh();
            startProyecto();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to modify the project is selected?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Proyecto proyecto = (Proyecto)dataProyecto.SelectedItem;

                proyecto.codigoproy = txtCodigoProy.Text.ToString();
                proyecto.nombreproy = txtNombreProy.Text;
                proyecto.descproy = txtDescProy.Text;
                proyecto.presupuesto = float.Parse(txtPresupuestoProy.Text);

                proyecto.modificar();

                int index = ((List<Proyecto>)dataProyecto.ItemsSource).FindIndex(proy=> proy.idproyecto == proyecto.idproyecto);

                ((List<Proyecto>)dataProyecto.ItemsSource)[index] = proyecto;
                dataProyecto.Items.Refresh();
                cbProyectos.Items.Refresh();
                startProyecto();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this project?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Proyecto proyecto = (Proyecto)dataProyecto.SelectedItem;
                proyecto.eliminar();

                ((List<Proyecto>)dataProyecto.ItemsSource).Remove(proyecto);
                dataProyecto.Items.Refresh();
                cbProyectos.Items.Refresh();
                startProyecto();
            }
        }


        //TABITEM EMPLEADOS
        private void startEmpleado()
        {
            txtNombreEmple.Clear();
            txtApellidoEmple.Clear();
            txtRegUsuario.Clear();
            txtRegPassword.Clear();
            cbRoles.Items.Clear();
        }

        private void dtgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Empleado empleado = (Empleado) dtgEmpleados.SelectedItem;

            txtNombreEmple.Text = empleado.nombreemp;
            txtApellidoEmple.Text = empleado.apellidos;
            txtCsr.Text = empleado.csr.ToString();
        }

        private void btnAddEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario) cbUsuarios.SelectedItem;
            //Rol rol = (Rol) cbRoles.SelectedItem;

            Empleado empleado = new Empleado(txtNombreEmple.Text, txtApellidoEmple.Text, float.Parse(txtCsr.Text), usuario.idusuario, 1);
            try
            {
                empleado.insertar();
                empleado.idempleado = empleado.last().idempleado;
                ((List<Empleado>)dtgEmpleados.ItemsSource).Add(empleado);
                cbEmpleados.Items.Refresh();
                dtgEmpleados.Items.Refresh();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("El empleado ya existe en la base de datos");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            startEmpleado();
        }

        private void btnModifyEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = (Empleado)dtgEmpleados.SelectedItem;
            Rol rol = (Rol)cbEmpleados.SelectedItem;

            empleado.nombreemp = txtNombreEmple.Text;
            empleado.apellidos = txtApellidoEmple.Text;
            empleado.csr = float.Parse(txtCsr.Text);
            empleado.idrol = rol.idrol;
            
            empleado.modificar();

            int index = ((List<Empleado>)dtgEmpleados.ItemsSource).FindIndex(emp => emp.idempleado == empleado.idempleado);

            ((List<Empleado>)dtgEmpleados.ItemsSource)[index] = empleado;
            dtgEmpleados.Items.Refresh();
            cbEmpleados.Items.Refresh();
            startEmpleado();
        }

        private void btnDelEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this empleado?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Empleado empleado = new Empleado();
                empleado = (Empleado)dtgEmpleados.SelectedItem;
                empleado.eliminar();
                ((List<Empleado>)dtgEmpleados.ItemsSource).Remove(empleado);
                dtgEmpleados.Items.Refresh();
                cbEmpleados.Items.Refresh();

                startEmpleado();
            }
        }

        private void btnRegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario(txtRegUsuario.Text, txtRegPassword.Text);
            try
            {
                usuario.insertar();
                usuario.idusuario = usuario.last().idusuario;
                ((List<Usuario>)dtgUsuarios.ItemsSource).Add(usuario);
                dtgUsuarios.Items.Refresh();
                cbUsuarios.Items.Refresh();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("El usuario ya existe en la base de datos");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //TABITEM G.ECONOMICA
        private void startGestion()
        {
            cbProyectos.SelectedValue = 0;
            cbEmpleados.SelectedValue = 0;
            txtFecha.Clear();
            txtHoras.Clear();
        }

        private void dtgGestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProyectoEmpleado pe = (ProyectoEmpleado)dtgGestion.SelectedItem;
            txtFecha.Text = pe.fecha.ToString();
            txtHoras.Text = pe.horas.ToString();
        }

        private async void btnImputHoras_Click(object sender, RoutedEventArgs e)
        {
            //ApiObject obj = new ApiObject();
            //string textFecha = txtFecha.Text;
            //DateTime fecha = DateTime.Parse(textFecha);
            //Proyecto

            //var objects = await obj.getFestivos();

            //foreach (var objeto in objects)
            //{
            //    if (fecha == DateTime.Parse(objeto.date))
            //    {
            //        MessageBox.Show("Es festivo no puedes añadir horas de trabajo.");
            //    }
            //    else
            //    {

            //    }
            //}
            Proyecto proyecto = (Proyecto) cbProyectos.SelectedItem;
            Empleado empleado = (Empleado) cbEmpleados.SelectedItem;

            ProyectoEmpleado pe = new ProyectoEmpleado();
            pe.idproyecto = proyecto.idproyecto;
            pe.nombreproygestion = proyecto.nombreproy;
            pe.idempleado = empleado.idempleado;
            pe.nombreempgestion = empleado.nombreemp;
            pe.fecha = DateTime.Parse(txtFecha.Text);
            pe.costes = 0.00F;
            pe.horas = Int32.Parse(txtHoras.Text);

            pe.insertar();

            ((List<ProyectoEmpleado>)dtgGestion.ItemsSource).Add(pe);
            dtgGestion.Items.Refresh();

        }

        private void btnModificarGestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarGestion_Click(object sender, RoutedEventArgs e)
        {

        }


        //TABITEM ESTADÍSTICAS
        private void btnCargarInforme_Click(object sender, RoutedEventArgs e)
        {
            cargarInforme1();
        }

        private void cargarInforme1()
        {
            dt = new DataTable("DataTable1");

            dt.Columns.Add("nombreproyecto");
            dt.Columns.Add("nombreempleado");
            dt.Columns.Add("fecha");
            dt.Columns.Add("costes");
            dt.Columns.Add("horas");

            foreach(ProyectoEmpleado pe in listProyEmp)
            {
                String nombreproyecto = null;
                List<Object> fila;
                fila = DBBroker.getInstancia().select("select nombreproy from mydb.proyecto where idproyecto = " + pe.idproyecto);
                foreach(List<Object> aux in fila)
                {
                    nombreproyecto = aux[0].ToString();
                }
                String nombreempleado = null;
                fila = DBBroker.getInstancia().select("select nombreemp from mydb.empleado where idempleado = " + pe.idempleado);
                foreach (List<Object> aux in fila)
                {
                    nombreempleado = aux[0].ToString();
                }

                DataRow row = dt.NewRow();
                row["nombreproyecto"] = nombreproyecto;
                row["nombreempleado"] = nombreempleado;
                row["fecha"] = pe.fecha;
                row["costes"] = pe.costes;
                row["horas"] = pe.horas;

                dt.Rows.Add(row);
            }

            Informe1 cr = new Informe1();

            cr.Database.Tables["DataTable1"].SetDataSource(dt);

            visor.ViewerCore.ReportSource = cr;
        }

        //TABITEM USUARIOS

        private void startUsuario()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }

        private void dtgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usuario usuario = (Usuario)dtgUsuarios.SelectedItem;
            txtUsuario.Text = usuario.nombreusuario;
        }

        private void btnDarAlta_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.nombreusuario = txtUsuario.Text;
            usuario.passusuario = cifrar(txtPassword.Text);
            try
            {
                usuario.insertar();
                usuario.idusuario = usuario.last().idusuario;
                ((List<Usuario>)dtgUsuarios.ItemsSource).Add(usuario);
                ((List<Usuario>)cbUsuarios.ItemsSource).Add(usuario);
                dtgUsuarios.Items.Refresh();
                cbUsuarios.Items.Refresh();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("El usuario ya existe en la base de datos");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this user?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)dtgUsuarios.SelectedItem;
                usuario.eliminar();
                ((List<Usuario>)dtgUsuarios.ItemsSource).Remove(usuario);
                dtgUsuarios.Items.Refresh();
                cbUsuarios.Items.Refresh();
                startUsuario();
            }
        }

        private void btnActualizarContraseña_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario)dtgUsuarios.SelectedItem;
            usuario.passusuario = cifrar(txtPassword.Text);
            usuario.cambiarPassword();

            int index = ((List<Usuario>)dtgUsuarios.ItemsSource).FindIndex(u => u.idusuario == usuario.idusuario);
            ((List<Usuario>)dtgUsuarios.ItemsSource)[index] = usuario;
            dtgUsuarios.Items.Refresh();
            cbUsuarios.Items.Refresh();

            MessageBox.Show("Contraseña actualizada correctamente");
        }


        //UTILIDADES
        private String cifrar(String pass)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < pass.Length; i++)
            {
                char c = pass[i];
                int s = c + 3;
                c = (char)s;
                sb.Append(c);
            }
            return sb.ToString();
        }

        private String generarNumFactura()
        {
            numFactura = 0;
            StringBuilder sb = new StringBuilder();
            numFactura++;
            sb.Append("FACT_").Append(numFactura);
            return sb.ToString();
        }

        
    }
}
