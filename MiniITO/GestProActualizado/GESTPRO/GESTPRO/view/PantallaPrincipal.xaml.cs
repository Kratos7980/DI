using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FormularioExamen.model;
using FormularioExamen.view;
using Org.BouncyCastle.Utilities;

namespace FormularioExamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            inicializarProyecto();
            inicializarEmpleado();
            inicializarUsuario();
        }
        

        private void inicializarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            dataProyecto.ItemsSource = proyecto.getAllProyectos();
            cbProyectos.ItemsSource = proyecto.getAllProyectos();
        }

        private void inicializarEmpleado()
        {
            Empleado empleado = new Empleado();

            dtgEmpleados.ItemsSource = empleado.getAllEmpleados();
            cbEmpleados.ItemsSource = empleado.getAllEmpleados();
        }

        private void inicializarUsuario()
        {
            Usuario usuario = new Usuario();

            cbUsuarios.ItemsSource = usuario.getAllUsuarios();
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
            //listProyecto.Where(p => p.name.Contains(textBuscar.Text)).ToList().ForEach(p =>
            //{
            //    listProyects.Items.Add(p);
            //});

        }

        private void dataProyecto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dataProyecto.SelectedItems.Count > 0)
            //{
            //    btnAñadir.IsEnabled = true;
            //    btnEliminar.IsEnabled = true;
            //    Proyecto proyecto = (Proyecto)dataProyecto.SelectedItems[0];
            //    textCodigo.Text = proyecto.cod_proy;
            //    textNombre.Text = proyecto.name;
            //    textDescripcion.Text = proyecto.descripcion;
            //    textPresupuesto.Text = proyecto.presupuesto.ToString();
            //}
        }

        private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            //List<String> listN = new List<String>();
            //listN.Add("Allegro");
            //listN.Add("Velneo");
            //listN.Add("SAP");
            //listN.Add("Naturgy");
            //listN.Add("Santander");
            //listN.Add("MutuaMadrileña");

            //for (int i = 1; i <= 20; i++)
            //{

            //    if (!btnAñadir.IsEnabled)
            //    {
            //        if (MessageBox.Show("Do you want to add this project?", "Confimation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //        {
            //            Random random = new Random();
            //            String nombre = listN[random.Next(0, listN.Count)];
            //            String codigo = "MTR" + i + nombre + DateTime.Now.Year;
            //            Proyecto p = new Proyecto(codigo, nombre, "", random.Next(1000, 5001));
            //            p.insert();
            //            p.last();
            //            ((List<Proyecto>)dataProyecto.ItemsSource).Add(p);
            //            ((List<Proyecto>)cbProyectos.ItemsSource).Add(p);
            //            dataProyecto.Items.Refresh();
            //            cbProyectos.Items.Refresh();
            //        }
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Do you want to modify the project is selected?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //        {
            //            List<Proyecto> listProyecto = (List<Proyecto>)dataProyecto.ItemsSource;
            //            Proyecto proyecto = listProyecto[dataProyecto.SelectedIndex];

            //            proyecto.cod_proy = textCodigo.Text.ToString();
            //            proyecto.name = textNombre.Text;
            //            proyecto.descripcion = textDescripcion.Text;
            //            proyecto.presupuesto = Double.Parse(textPresupuesto.Text);

            //            proyecto.modifyProyecto();

            //            dataProyecto.Items.Refresh();
            //            cbProyectos.Items.Refresh();
            //        }
            //    }
            //    start();
            //}
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            //Proyecto proyecto = new Proyecto();
            //if (btnAñadir.Content.Equals("Añadir"))
            //{
            //    proyecto.cod_proy = textCodigo.Text;
            //    proyecto.name = textNombre.Text;
            //    proyecto.descripcion = textDescripcion.Text;
            //    proyecto.presupuesto = Double.Parse(textPresupuesto.Text);
            //    proyecto.insert();
            //    proyecto.last();
            //    ((List<Proyecto>)dataProyecto.ItemsSource).Add(proyecto);
            //    ((List<Proyecto>)dataProyecto.ItemsSource).Add(proyecto);
            //    dataProyecto.Items.Refresh();
            //    cbProyectos.Items.Refresh();
            //    start();
            //}
            //else
            //{
            //    List<Proyecto> listProyecto = (List<Proyecto>)dataProyecto.ItemsSource;
            //    proyecto = listProyecto[dataProyecto.SelectedIndex];

            //    proyecto.cod_proy = textCodigo.Text;
            //    proyecto.name = textNombre.Text;
            //    proyecto.descripcion = textDescripcion.Text;
            //    proyecto.presupuesto = Double.Parse(textPresupuesto.Text);

            //    proyecto.modifyProyecto();

            //    dataProyecto.Items.Refresh();
            //    cbProyectos.Items.Refresh();
            //    start();
            //}
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //btnAñadir.Content = "Actualizar";
            //btnModificar.IsEnabled = false;
            //btnEliminar.IsEnabled = false;
            //Proyecto project = (Proyecto)dataProyecto.SelectedItem;
            //listProyecto.Where(p => p.cod_proy.Equals(project.cod_proy) && p.name.Equals(project.name)).ToList().ForEach(p =>
            //{
            //    textCodigo.Text = p.cod_proy;
            //    textNombre.Text = p.name;
            //    textDescripcion.Text = p.descripcion;
            //    textPresupuesto.Text = p.presupuesto.ToString();
            //});
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Do you want to remove this project?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Proyecto proyecto = (Proyecto)dataProyecto.SelectedItem;
            //    proyecto.delete();
            //    List<Proyecto> lst = (List<Proyecto>)dataProyecto.ItemsSource;
            //    lst.Remove(proyecto);
            //    dataProyecto.Items.Refresh();
            //    cbProyectos.Items.Refresh();
            //    dataProyecto.ItemsSource = lst;
            //    start();
            //}
        }


        //TABITEM EMPLEADOS
        private void startEmpleado()
        {
            txtNombreEmple.Clear();
            txtApellidoEmple.Clear();
            txtRegUsuario.Clear();
            txtRegPassword.Clear();

            cbUsuarios.IsEnabled = false;
            btnRegistrarUsuario.IsEnabled = false;
            txtRegUsuario.IsEnabled = false;
            txtRegPassword.IsEnabled = false;
        }

        private void btnAddEmpleado_Click(object sender, RoutedEventArgs e)
        {
            //Empleado emp = new Empleado(txtNombreEmpleado.Text, txtApellidoEmpleado.Text, Double.Parse(txtCSR.Text));
            //try
            //{
            //    emp.insertEmpleado();
            //    cbEmpleados.Items.Refresh();
            //    dtgEmpleados.Items.Refresh();
            //}
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        MessageBox.Show("El empleado ya existe en la base de datos");
            //    }
            //    else
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void btnModifyEmpleado_Click(object sender, RoutedEventArgs e)
        {
            //Empleado emp = (Empleado)dtgEmpleados.SelectedItem;
            //emp.Name = txtNombreEmpleado.Text;
            //emp.Surname = txtApellidoEmpleado.Text;
            //emp.Csr = Double.Parse(txtCSR.Text);
            //emp.modifyEmpleado();
            //cbEmpleados.Items.Refresh();
            //dtgEmpleados.Items.Refresh();
        }

        private void btnDelEmpleado_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Do you want to remove this empleado?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Empleado empleado = new Empleado();
            //    empleado = (Empleado)dtgEmpleados.SelectedItem;
            //    empleado.delete();
            //    empleado.deleteEmpleado();
            //    List<Empleado> lst = (List<Empleado>)dtgEmpleados.ItemsSource;
            //    lst.Remove(empleado);
            //    dtgEmpleados.Items.Refresh();
            //    cbEmpleados.Items.Refresh();
            //    dtgEmpleados.ItemsSource = lst;
            //    start();
            //}
        }

        private void btnRegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            //Usuario usuario = new Usuario(txtRegUsuario.Text, txtRegPassword.Text);
            //try
            //{
            //    usuario.insert();
            //    ((List<Usuario>)dtgUsuarios.ItemsSource).Add(usuario);
            //    ((List<Usuario>)cbUsuarios.ItemsSource).Add(usuario);
            //    dtgUsuarios.Items.Refresh();
            //    cbUsuarios.Items.Refresh();

            //}
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        MessageBox.Show("El usuario ya existe en la base de datos");
            //    }
            //    else
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }


        //TABITEM G.ECONOMICA
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

        }

        private void btnModificarGestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarGestion_Click(object sender, RoutedEventArgs e)
        {

        }


        //TABITEM ESTADÍSTICAS


        //TABITEM USUARIOS
        private void btnDarAlta_Click(object sender, RoutedEventArgs e)
        {
            //Usuario usuario = new Usuario();
            //usuario.Name = txtUsuario.Text;
            //usuario.Password = usuario.cifrar(txtPassword.Text);
            //usuario.insert();
            //dtgUsuarios.Items.Refresh();
            //cbUsuarios.Items.Refresh();
        }

        private void btnDelUsuario_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Do you want to remove this user?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Usuario usuario = new Usuario();
            //    usuario = (Usuario)dtgUsuarios.SelectedItem;
            //    usuario.delete();
            //    List<Usuario> lst = (List<Usuario>)dtgUsuarios.ItemsSource;
            //    lst.Remove(usuario);
            //    dtgUsuarios.Items.Refresh();
            //    cbUsuarios.Items.Refresh();
            //    dtgUsuarios.ItemsSource = lst;
            //    start();
            //}
        }

        private void btnActualizarContraseña_Click(object sender, RoutedEventArgs e)
        {
            //Usuario usuario = (Usuario)dtgUsuarios.SelectedItem;
            //usuario.Password = usuario.cifrar(txtPassword.Text);
            //usuario.modificarContraseña();
            //MessageBox.Show("Contraseña actualizada correctamente");
        }

        private void dtgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dtgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}