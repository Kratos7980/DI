using Plantilla.dominio;
using Plantilla.persistencia.manages;
using Plantilla.view.Informe;
using Plantilla.view.Paginas;
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

namespace Plantilla
{
    public partial class MainWindow : Window
    {


        private List<Persona> lstPersonas;
        private Persona persona;


        DataTable tabla1;
        PersonasManage pm = new PersonasManage();
        Persona personaInforme = new Persona();



        public MainWindow()
        {
            InitializeComponent();

            mainFrame.Navigate(new PageMain());

            lstPersonas = new List<Persona>();
            persona = new Persona();
            lstPersonas = persona.getPersonas();
            dgvPersonas.ItemsSource = lstPersonas;
            startPersonas();



            //ESTO SE PUEDE HACER EN UNA VENTANA NUEVA

            List<Persona> lista = personaInforme.getPersonas();
            //CREAR un datatable con el mismo nombre de la tabla del informe
            tabla1 = new DataTable("DataTable1");


            //Añadimos las columnos del dataset con el mismo nombre (PARA QUE SE CREE EN MEMORIA)
            tabla1.Columns.Add("nombre");
            tabla1.Columns.Add("apellidos");

            foreach (Persona p in lista)
            {

                //Crear una columna de datos en la tabla creada
                DataRow row = tabla1.NewRow();

                row["nombre"] = p.Nombre;
                row["apellidos"] = p.Apellidos;

                tabla1.Rows.Add(row);

            }

            //Crear una instancia de Crystal Report
            CrystalReport1 report = new CrystalReport1();

            //Incluimos el datasource al crystal report
            report.Database.Tables["DataTable1"].SetDataSource((DataTable)tabla1);

            //Asignar el informe
            visor.ViewerCore.ReportSource = report;












        }



        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellidos.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Persona persona = new Persona(txtNombre.Text, txtApellidos.Text);
                persona.insertar();
                List<Persona> list = (List<Persona>)dgvPersonas.ItemsSource;
                lstPersonas.Add(persona);
                dgvPersonas.Items.Refresh();
                dgvPersonas.ItemsSource = list;
                startPersonas();
            }
        }


        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Persona personaV = (Persona)dgvPersonas.SelectedItem;
            Persona personaN = new Persona(personaV.Id, txtNombre.Text, txtApellidos.Text);
            List<Persona> list = (List<Persona>)dgvPersonas.ItemsSource;
            int posicion = list.IndexOf(personaV);
            list.Remove(personaV);
            list.Insert(posicion, personaN);
            dgvPersonas.Items.Refresh();
            personaN.actualizar();
            dgvPersonas.ItemsSource = list;
            startPersonas();
        }



        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Quiere eliminar esta persona?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Persona persona = (Persona)dgvPersonas.SelectedItem;
                persona.eliminar();
                List<Persona> lst = (List<Persona>)dgvPersonas.ItemsSource;
                lst.Remove(persona);
                dgvPersonas.Items.Refresh();
                dgvPersonas.ItemsSource = lst;
                startPersonas();
            }
        }




        private void dgvPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPersonas.SelectedItems.Count > 0)
            {
                Persona persona = (Persona)dgvPersonas.SelectedItems[0];
                txtNombre.Text = persona.Nombre;
                txtApellidos.Text = persona.Apellidos;
            }
        }


        private void startPersonas()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            dgvPersonas.SelectedItems.Clear();
        }

        





        //INFORMES
        /*
         --PASOS A SEGUIR--
            Añadir elemento crystal report viewer
            
            Crear una clase de Crystal Report y crearlo en informe en blanco
            Crear una clase de Conjunto de datos
                Crear una DataTable y ponerle los campos (Control+l)
            
            Poner el origen de datos siguiendo la ruta correspondiente del dataSet y seleccionar todo.

            Después desde el crystal report en explorador de campos: Asistente de base de datos---datos del proyecto o Mis conexion y buscar el dataTable.

         */




    }
}
