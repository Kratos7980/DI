using DataGridPerson.Domain;
using DataGridPerson.Persistance;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DataGridPerson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> listPerson;
        public MainWindow()
        {
            InitializeComponent();
            listPerson = new List<Person>();
            dataPerson.ItemsSource = listPerson;
        }

        private void addPerson_Click(object sender, RoutedEventArgs e)
        {
            listPerson.Add(new Person(nameText.Text, surnameText.Text, int.Parse(ageText.Text)));
            dataPerson.Items.Refresh();
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {

            Agregar.Content = "Actualizar";
            Eliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;

            listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().ForEach(p =>
            {
                p.Name = nameText.Text;
                p.SurName = surnameText.Text;
                p.Age = int.Parse(ageText.Text);
            });
            dataPerson.Items.Refresh();
            nameText.Clear();
            surnameText.Clear();
            ageText.Clear();
            btnModificar.IsEnabled = true;
            Eliminar.IsEnabled = true;
            Agregar.Content = " Add Person";
            


            if (listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().Any() == false)
            {
                listPerson.Add(new Person(nameText.Text,surnameText.Text,int.Parse(ageText.Text)));
            }
            else
            {
                MessageBox.Show("La persona ya existe en la lista de persona. No se añade de nuevo.");
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            listPerson.Remove((Person)dataPerson.SelectedItem);
            dataPerson.Items.Refresh();
        }
    }
}