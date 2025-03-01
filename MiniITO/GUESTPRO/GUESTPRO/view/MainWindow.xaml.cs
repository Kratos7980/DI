using GUESTPRO.model;
using GUESTPRO.persistence;
using GUESTPRO.view;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
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
        private List<Rol> listRoles;
        private List<ProyectoEmpleado> listProyEmp;
        private int numFactura = 0;
        private DataTable dt;
        public MainWindow()
        {
            InitializeComponent();

            inicializarProyecto();
            inicializarRol();
            inicializarEmpleado();
            inicializarUsuario();
            inicializarGestion();
            inicializarEstadisticas();
        }

        // TABCONTROL BUTTONS
        private void btnProyecto_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void btnGestion_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 5;
        }

        // INICIALIZAR TABITEMS
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

            foreach(Empleado emple in listEmpleados)
            {
                int index = listRoles.FindIndex(r => r.idrol == emple.idrol);
                emple.nombrerolemple = listRoles[index].nombrerol;
            }

            dtgEmpleados.ItemsSource = listEmpleados;
            cbEmpleados.ItemsSource = listEmpleados;
            cbEmpleados.DisplayMemberPath = "nombreemp";
            lbUsuario.IsEnabled = false;
            txtUsuario.IsEnabled = false;
            txtPassword.IsEnabled = false;
            lbPassword.IsEnabled = false;
            btnRegistrarUsuario.IsEnabled = false;
        }

        private void inicializarRol()
        {
            Rol rol = new Rol();
            listRoles = rol.getAllRoles();
            cbRoles.ItemsSource = listRoles;
            cbRoles.DisplayMemberPath = "nombrerol";
        }

        private void inicializarUsuario()
        {
            Usuario usuario = new Usuario();
            listUsuarios = usuario.getAllUsuarios();
            dtgUsuarios.ItemsSource = listUsuarios;
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

        private void inicializarEstadisticas()
        {
            cbInformes.SelectedIndex = 0;
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
            Proyecto proyecto = (Proyecto)dataProyecto.SelectedItem;
            if (proyecto != null)
            {
                btnAñadir.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                txtCodigoProy.Text = proyecto.codigoproy;
                txtNombreProy.Text = proyecto.nombreproy;
                txtDescProy.Text = proyecto.descproy;
                txtPresupuestoProy.Text = proyecto.presupuesto.ToString();
            }
            else
            {
                startProyecto();
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
            txtCsr.Clear();
            txtRegUsuario.Clear();
            txtRegPassword.Clear();
            cbRoles.SelectedItem = null;
            cbUsuarios.SelectedItem = null;
            lbUsuario.IsEnabled = false;
            txtUsuario.IsEnabled = false;
            lbPassword.IsEnabled = false;
            txtPassword.IsEnabled = false;
            btnRegistrarUsuario.IsEnabled = false;
        }

        private void dtgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Empleado empleado = (Empleado) dtgEmpleados.SelectedItem;

            if(empleado != null)
            {
                Usuario usuario = listUsuarios.FirstOrDefault(u => u.idusuario == empleado.idusuario);
                Rol rol = listRoles.FirstOrDefault(r => r.idrol == empleado.idrol);

                txtNombreEmple.Text = empleado.nombreemp;
                txtApellidoEmple.Text = empleado.apellidos;
                txtCsr.Text = empleado.csr.ToString();
                cbUsuarios.SelectedItem = usuario;
                cbRoles.SelectedItem = rol;
            }
            else
            {
                startEmpleado();
            }
        }

        private void chkUser_Checked(object sender, RoutedEventArgs e)
        {
           
            lbUsuario.IsEnabled = true;
            txtUsuario.IsEnabled = true;
            lbPassword.IsEnabled = true;
            txtPassword.IsEnabled = true;
            btnRegistrarUsuario.IsEnabled = true;           
        }

        private void chkUser_Unchecked(object sender, RoutedEventArgs e)
        {
            lbUsuario.IsEnabled = false;
            txtUsuario.IsEnabled = false;
            lbPassword.IsEnabled = false;
            txtPassword.IsEnabled = false;
            btnRegistrarUsuario.IsEnabled = false;
        }

        private void btnAddEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario) cbUsuarios.SelectedItem;
            Rol rol = (Rol) cbRoles.SelectedItem;

            Empleado empleado = new Empleado(txtNombreEmple.Text, txtApellidoEmple.Text, float.Parse(txtCsr.Text), usuario.idusuario, rol.idrol);
            try
            {

                empleado.insertar();
                empleado.idempleado = empleado.last().idempleado;
                empleado.nombrerolemple = rol.nombrerol;
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
            Rol rol = (Rol)cbRoles.SelectedItem;

            empleado.nombreemp = txtNombreEmple.Text;
            empleado.apellidos = txtApellidoEmple.Text;
            empleado.csr = float.Parse(txtCsr.Text);
            empleado.idrol = rol.idrol;
            empleado.nombrerolemple = rol.nombrerol;

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
                MessageBox.Show("Registrado correctamente");
                usuario.idusuario = usuario.last().idusuario;
                ((List<Usuario>)dtgUsuarios.ItemsSource).Add(usuario);
                dtgUsuarios.Items.Refresh();
                cbUsuarios.Items.Refresh();
                startEmpleado();
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
            cbProyectos.SelectedItem = null;
            cbEmpleados.SelectedItem = null;
            txtFecha.Clear();
            txtHoras.Clear();
        }

        private void dtgGestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ProyectoEmpleado pe = (ProyectoEmpleado)dtgGestion.SelectedItem;
            if (pe != null)
            {
                Proyecto proy = listProyectos.FirstOrDefault(p => p.idproyecto == pe.idproyecto);
                Empleado emp = listEmpleados.FirstOrDefault(em => em.idempleado == pe.idempleado);
                cbProyectos.SelectedItem = proy;
                cbEmpleados.SelectedItem = emp;
                txtFecha.Text = pe.fecha.ToString();
                txtHoras.Text = pe.horas.ToString();
            }
            else
            {
                startGestion();
            }
            
        }

        private async void btnImputHoras_Click(object sender, RoutedEventArgs e)
        {
            ApiObject obj = new ApiObject();
            string textFecha = txtFecha.Text;
            DateTime fecha = DateTime.Parse(textFecha);

            List<DateTime> listFestivos = await obj.getFestivos();
            bool festivo = false;
            foreach (DateTime objeto in listFestivos)
            {
                if (fecha.ToString("yyyyMMdd") == objeto.ToString("yyyyMMdd"))
                {
                    festivo = true;
                }
            }

            if (festivo)
            {
                MessageBox.Show("Es festivo no puedes añadir horas de trabajo.");
            }
            else
            {
                Proyecto proyecto = (Proyecto)cbProyectos.SelectedItem;
                Empleado empleado = (Empleado)cbEmpleados.SelectedItem;

                ProyectoEmpleado pe = new ProyectoEmpleado();
                pe.idproyecto = proyecto.idproyecto;
                pe.nombreproygestion = proyecto.nombreproy;
                pe.idempleado = empleado.idempleado;
                pe.nombreempgestion = empleado.nombreemp;
                pe.fecha = fecha;
                pe.horas = Int32.Parse(txtHoras.Text);
                pe.costes = pe.horas * empleado.csr;
                try
                {
                    pe.insertar();

                    ((List<ProyectoEmpleado>)dtgGestion.ItemsSource).Add(pe);
                    dtgGestion.Items.Refresh();
                    startGestion();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Fecha ya registrada");
                }
            }
        }

        private async void btnModificarGestion_Click(object sender, RoutedEventArgs e)
        {
            ApiObject obj = new ApiObject();
            string textFecha = txtFecha.Text;
            DateTime fecha = DateTime.Parse(textFecha);

            List<DateTime> listFestivos = await obj.getFestivos();
            bool festivo = false;
            foreach (DateTime objeto in listFestivos)
            {
                if (fecha.ToString("yyyyMMdd") == objeto.ToString("yyyyMMdd"))
                {
                    festivo = true;
                }
            }

            if (festivo)
            {
                MessageBox.Show("Es festivo no puedes añadir horas de trabajo.");
            }
            else
            {
                Proyecto proyecto = (Proyecto)cbProyectos.SelectedItem;
                Empleado empleado = (Empleado)cbEmpleados.SelectedItem;

                ProyectoEmpleado pe = new ProyectoEmpleado();
                pe.idproyecto = proyecto.idproyecto;
                pe.nombreproygestion = proyecto.nombreproy;
                pe.idempleado = empleado.idempleado;
                pe.nombreempgestion = empleado.nombreemp;
                pe.fecha = fecha;
                pe.horas = Int32.Parse(txtHoras.Text);
                pe.costes = pe.horas * empleado.csr;

                pe.modificar();

                int index = ((List<ProyectoEmpleado>)dtgGestion.ItemsSource).FindIndex(proyemp => (proyemp.idproyecto == pe.idproyecto) && (proyemp.idempleado == pe.idempleado));
                ((List<ProyectoEmpleado>)dtgGestion.ItemsSource)[index] = pe;
                dtgGestion.Items.Refresh();
                startGestion();
            }
        }
        private void btnEliminarGestion_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to remove this gestion?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ProyectoEmpleado pe = (ProyectoEmpleado)dtgGestion.SelectedItem;
                pe.eliminar();

                ((List<ProyectoEmpleado>)dtgGestion.ItemsSource).Remove(pe);
                dtgGestion.Items.Refresh();
            }
            
        }


        //TABITEM ESTADÍSTICAS
        private void btnCargarInforme_Click(object sender, RoutedEventArgs e)
        {
            String valor = cbInformes.SelectedItem.ToString();
            if(valor.Contains("TOTAL POR MES"))
            {
                cargarTotalPorMes();
            }
            else if(valor.Contains("INFORMACION PROYECTO"))
            {
                cargarInfoProyectos();
            }
        }

        private void cargarTotalPorMes()
        {
            dt = new DataTable("TOTAL_COSTES_POR_MES");

            dt.Columns.Add("Nombre proyecto");
            dt.Columns.Add("Mes");
            dt.Columns.Add("Total");
            
            List<String> meses = getMeses();
            foreach(Proyecto proy in listProyectos)
            {

                int val = 0;
                String total = null;
                meses.ForEach(mes =>
                {
                    List<Object> filas;
                    List<Object> resultado;
                    filas = DBBroker.getInstancia().select("select sum(costes) from mydb.proyecto_has_empleado where idproyecto = " + proy.idproyecto + " and month(fecha) = " + (val + 1));
                    resultado = (List<Object>) filas[0];

                    total = (String)resultado[0];

                    DataRow row = dt.NewRow();
                    row["Nombre proyecto"] = proy.nombreproy;
                    row["Mes"] = mes;
                    row["Total"] = total;

                    dt.Rows.Add(row);
                    val++;
                }); 
            }

            TotalMeses cr = new TotalMeses();

            cr.Database.Tables["TOTAL_COSTES_POR_MES"].SetDataSource(dt);

            visor.ViewerCore.ReportSource = cr;
        }

        private void cargarInfoProyectos()
        {
            dt = new DataTable("DATOS_PROYECTOS");

            dt.Columns.Add("Proyecto");
            dt.Columns.Add("Rol");
            dt.Columns.Add("Numero empleados");

            foreach(Proyecto proy in listProyectos)
            {
                listRoles.ForEach(rol =>
                {
                    List<Object> filas;
                    filas = DBBroker.getInstancia().select(
                        "select count(e.idempleado) " +
                        "from mydb.proyecto_has_empleado pe " +
                        "inner join mydb.empleado e on e.idempleado = pe.idempleado " +
                        "inner join mydb.rol r on e.idrol = r.idrol " +
                        "where pe.idproyecto = " + proy.idproyecto + " and r.nombrerol = '" + rol.nombrerol + "' " + 
                        "group by pe.idproyecto, r.nombrerol");
                    if(filas.Count > 0)
                    {
                        List<Object> resultado = (List<Object>)filas[0];

                        DataRow row = dt.NewRow();
                        row["Proyecto"] = proy.nombreproy;
                        row["Rol"] = rol.nombrerol;
                        row["Numero empleados"] = resultado[0].ToString();

                        dt.Rows.Add(row);
                    }
                    
                });
            }

            InfoProyectos cr = new InfoProyectos();

            cr.Database.Tables["DATOS_PROYECTOS"].SetDataSource(dt);

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
            if(usuario != null)
            {
                txtUsuario.Text = usuario.nombreusuario;
            }
            else
            {
                startUsuario();
            }
            
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
            StringBuilder sb = new StringBuilder();
            numFactura++;
            sb.Append("FACT_").Append(numFactura);
            return sb.ToString();
        }

        private List<String> getMeses()
        {
            List<String> list = new List<String>();

            list.Add("Enero");
            list.Add("Febrero");
            list.Add("Marzo");
            list.Add("Abril");
            list.Add("Mayo");
            list.Add("Junio");
            list.Add("Julio");
            list.Add("Agosto");
            list.Add("Septiembre");
            list.Add("Octubre");
            list.Add("Noviembre");
            list.Add("Diciembre");

            return list;
        }

    }
}
