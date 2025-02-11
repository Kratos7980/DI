using DataGridPerson.Persistence;
using GESTPRO.model;
using GESTPRO.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GESTPRO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Proyecto> list;

        private DataTable dt;

        private List<Empleado> listEmpleado;
        private List<Proyecto> listProjects;
        public MainWindow()
        {
            InitializeComponent();
            Proyecto proyecto = new Proyecto();
            Usuario usuario = new Usuario();
            Empleado empleado = new Empleado();
            proyecto.readP();
            
            listEmpleado = empleado.getListEmpleado();
            listProjects = proyecto.getListProyectos();
            dataProjecto.ItemsSource = proyecto.getListProyectos();
            dtgUsuarios.ItemsSource = usuario.getListUsuarios();
            dtgEmpleados.ItemsSource = empleado.getListEmpleado();
            cbEmpleados.ItemsSource = empleado.getListEmpleado();
            cbProyectos.ItemsSource = proyecto.getListProyectos();
            cbUsuarios.ItemsSource = usuario.getListUsuarios();

            btnEliminar.IsEnabled = false;
            btnAñadir.IsEnabled = false;
            textCodigo.Text = "";
            textNombre.Text = "";

            
        }

        /// <summary>Actuar cuan el texto de textBuscar cambia</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs" /> instance containing the event data.</param>
        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            list.Where(p => p.name.Contains(textBuscar.Text)).ToList().ForEach(p =>
            {
                listProyects.Items.Add(p);
            });

        }

        /// <summary>Accion cuando seleccion un item del datagrid</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void dataProyecto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataProjecto.SelectedItems.Count > 0)
            {
                btnAñadir.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                Proyecto proyecto = (Proyecto)dataProjecto.SelectedItems[0];
                textCodigo.Text = proyecto.id.ToString();
                textNombre.Text = proyecto.name;
            }
        }

        /// <summary>Inicializar textos  y botones</summary>
        private void start()
        {
            textCodigo.Text = "";
            textNombre.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";

            btnEliminar.IsEnabled = false;
            btnAñadir.IsEnabled = false;
            dataProjecto.SelectedItems.Clear();
        }

        /// <summary>Evento boton añadir</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            start();
            
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            btnAñadir.Content = "Actualizar";
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            Proyecto project = (Proyecto)dataProjecto.SelectedItem;
            list.Where(p => p.id.Equals(project.id) && p.name.Equals(project.name)).ToList().ForEach(p =>
            {
                textCodigo.Text = p.id.ToString();
                textNombre.Text = p.name;
            });
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this project?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Proyecto proyecto = (Proyecto)dataProjecto.SelectedItem;
                proyecto.delete();
                List<Proyecto> lst = (List<Proyecto>)dataProjecto.ItemsSource;
                lst.Remove(proyecto);
                dataProjecto.Items.Refresh();
                dataProjecto.ItemsSource = lst;
                start();
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
                
                if (!btnAñadir.IsEnabled)
                {
                    if (MessageBox.Show("Do you want to add this project?", "Confimation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Random random = new Random();
                        String nombre = listN[random.Next(0, listN.Count)];
                        String codigo = "MTR" + i + nombre + DateTime.Now.Year;
                        Proyecto p = new Proyecto(codigo, nombre);
                        p.insert();
                        p.last();
                        ((List<Proyecto>)dataProjecto.ItemsSource).Add(p);
                        dataProjecto.Items.Refresh();
                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to modify the project is selected?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        List<Proyecto> listProjecto = (List<Proyecto>)dataProjecto.ItemsSource;
                        listProjecto[dataProjecto.SelectedIndex].id = textCodigo.Text.ToString();
                        listProjecto[dataProjecto.SelectedIndex].name = textNombre.Text;
                        dataProjecto.Items.Refresh();
                    }
                }
                start();
            }
            
        }

        private void btnDarAlta_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Name = txtUsuario.Text;
            usuario.Password = usuario.cifrar(txtPassword.Text);
            usuario.insert();
            dtgUsuarios.Items.Refresh();
        }

        private void btnDelUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this user?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)dtgUsuarios.SelectedItem;
                usuario.delete();
                List<Usuario> lst = (List<Usuario>)dtgUsuarios.ItemsSource;
                lst.Remove(usuario);
                dtgUsuarios.Items.Refresh();
                dtgUsuarios.ItemsSource = lst;
                start();
            }
        }

        private void btnActualizarContraseña_Click(object sender, RoutedEventArgs e)
        {
            ////Codigo.
        }

        private void btnAddEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = new Empleado(txtNombreEmpleado.Text, txtApellidoEmpleado.Text, Double.Parse(txtCSR.Text));
            emp.insertEmpleado();
            dtgEmpleados.Items.Refresh();

        }

        private void btnModifyEmpleado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this empleado?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Empleado empleado = new Empleado();
                empleado = (Empleado)dtgEmpleados.SelectedItem;
                empleado.delete();
                empleado.deleteEmpleado();
                List<Empleado> lst = (List<Empleado>)dtgEmpleados.ItemsSource;
                lst.Remove(empleado);
                dtgEmpleados.Items.Refresh();
                dtgEmpleados.ItemsSource = lst;
                start();
            }
        }

        private void btnRegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnImputHoras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificarGestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarGestion_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>Deshabilita los campos necesarios para crear un nuevo usuario.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void CheckBox_RegisteredUser(object sender, RoutedEventArgs e)
        {
            btnAddEmpleado.IsEnabled = true;
            btnRegistrarUsuario.IsEnabled = true;
        }

        private void CheckBox_NotRegisteredUser(object sender, RoutedEventArgs e)
        {
            btnAddEmpleado.IsEnabled = false;
            btnModifyEmpleado.IsEnabled = false;
            btnDelEmpleado.IsEnabled = false;
        }

        private void cargarInforme()
        {
           
            //Inicializar tabla
            dt = new DataTable("TablaProyecto");

            //Crear columnas
            dt.Columns.Add("Project");
            dt.Columns.Add("Month/Year");
            dt.Columns.Add("Total Cost");

            //Meter contenido a la tabla

            foreach (Proyecto project in listProjects)
            {
                //Creo la fila
                DataRow row = dt.NewRow();
                row["Project"] = project.name;
                row["Month/Year"] = project.getDate(Int32.Parse(project.id));
                row["Total Cost"] = project.totalCost(Int32.Parse(project.id));

                //Añadir la fila a la tabla.
                dt.Rows.Add(row);
            }

            CostByProject cr = new CostByProject();

            cr.Database.Tables["TablaProyecto"].SetDataSource(dt);

            visor.ViewerCore.ReportSource = cr;

        }

        private void cargarInforme2()
        {
            //Inicializar tabla
            dt = new DataTable("ProjectProfile");

            //Crear columnas
            dt.Columns.Add("Project");
            dt.Columns.Add("Month/Year");
            dt.Columns.Add("Employe Profile");
            dt.Columns.Add("Number of people");

            //Meter contenido a la tabla

            
            foreach (Proyecto project in listProjects)
            {
                List<String> list = project.getListRoles(Int32.Parse(project.id));
                //Creo la fila
                DataRow row = dt.NewRow();
                foreach (String role in list)
                {
                    row["Project"] = project.name;
                    row["Month/Year"] = project.getDate(Int32.Parse(project.id));
                    row["Employe Profile"] = role;
                    row["Number of People"] = 3;
                }
                 

                //Añadir la fila a la tabla.

                dt.Rows.Add(row);
            }

            NumberOfProfiles cr = new NumberOfProfiles();

            cr.Database.Tables["ProjectProfile"].SetDataSource(dt);

            visor.ViewerCore.ReportSource = cr;
        }

        private void btnMostrarInforme_Click(object sender, RoutedEventArgs e)
        {
            
            if(cbInforme.SelectedValue.Equals("Cost by project"))
            {
                cargarInforme();
            }
            else if(cbInforme.SelectedValue.Equals("Number of profiles"))
            {
                cargarInforme2();
            }
            
        }
    }
}
