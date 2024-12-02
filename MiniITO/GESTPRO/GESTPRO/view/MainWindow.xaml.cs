using GESTPRO.model;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            Proyecto proyecto = new Proyecto();
            proyecto.readP();
            dataProjecto.ItemsSource = proyecto.getListPeople();
            btnEliminar.IsEnabled = false;
            btnAñadir.IsEnabled = false;
            textCodigo.Text = "";
            textNombre.Text = "";
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            list.Where(p => p.name.Contains(textBuscar.Text)).ToList().ForEach(p =>
            {
                listProyects.Items.Add(p);
            });

        }

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

        private void start()
        {
            textCodigo.Text = "";
            textNombre.Text = "";

            btnEliminar.IsEnabled = false;
            btnAñadir.IsEnabled = false;
            dataProjecto.SelectedItems.Clear();
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            start();
            //if (!btnAñadir.Content.Equals("Actualizar")) 
            //{
            //    if (list.Where(p => p.id.Equals(textCodigo.Text) && p.name.Equals(textNombre.Text)).ToList().Any() == false)
            //    {

            //        list.Add(new Proyecto(Int32.Parse(textCodigo.Text)));
            //        dataProjecto.Items.Refresh();
            //        textCodigo.Clear();
            //        textNombre.Clear();
            //        textFechaI.Clear();
            //        textFechaF.Clear();
            //    }
            //    else
            //    {
            //        MessageBox.Show("La persona ya existe en la lista de persona. No se añade de nuevo.");
            //    }
            //}else if (btnAñadir.Content.Equals("Actualizar"))
            //{
            //    list.Where(p => p.id == Int32.Parse(textCodigo.Text)).ToList().ForEach(p =>
            //    {
            //        p.id = Int32.Parse(textCodigo.Text);
            //        p.name = textNombre.Text;
            //    });
            //    dataProjecto.Items.Refresh();
            //    textCodigo.Clear();
            //    textNombre.Clear();
            //    textFechaI.Clear();
            //    textFechaF.Clear();
            //    btnModificar.IsEnabled = true;
            //    btnEliminar.IsEnabled = true;
            //    btnAñadir.Content = " Añadir";
            //}
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
    }
}
