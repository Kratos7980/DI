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
        private Boolean interruptor;
        public MainWindow()
        {
            InitializeComponent();
            listPerson = new List<Person>();
            dataPerson.ItemsSource = listPerson;
            interruptor = false;
        }

        private void addPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!btnAgregar.Content.Equals("Update"))
            {
               
                if (listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().Any() == false)
                {

                    listPerson.Add(new Person(nameText.Text, surnameText.Text, Int32.Parse(ageText.Text)));
                    dataPerson.Items.Refresh();
                    nameText.Clear();
                    surnameText.Clear();
                    ageText.Clear();
                }
                else
                {
                    MessageBox.Show("La persona ya existe en la lista de persona. No se añade de nuevo.");
                } 
            }
            
            if(btnAgregar.Content.Equals("Update"))
            {
                listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().ForEach(p =>
                {
                    p.Name = nameText.Text;
                    p.SurName = surnameText.Text;
                    p.Age = Int32.Parse(ageText.Text);
                });
                dataPerson.Items.Refresh();
                nameText.Clear();
                surnameText.Clear();
                ageText.Clear();
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnAgregar.Content = " Add Person";
            }
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            btnAgregar.Content = "Update";
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;           
            
            Person person = (Person) dataPerson.SelectedItem;
            
            listPerson.Where(p => p.Name.Equals(person.Name) && p.SurName.Equals(person.SurName)).ToList().ForEach(p =>
            {
                nameText.Text = p.Name;
                surnameText.Text = p.SurName;
                ageText.Text = p.Age.ToString();
            });
            interruptor = true;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            listPerson.Remove((Person)dataPerson.SelectedItem);
            dataPerson.Items.Refresh();
        }
    }
}