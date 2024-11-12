using DataGridPerson.Domain;
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
using DataGridPerson.Persistence.Manage;


namespace DataGridPerson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<People> listPerson;
        public MainWindow()
        {
            InitializeComponent();
            
            listPerson = PeopleManage.readPeople();
            dataPerson.ItemsSource = listPerson;
        }

        private void addPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!btnAgregar.Content.Equals("Update"))
            {
               
                if (listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().Any() == false)
                {

                    listPerson.Add(new People(nameText.Text, surnameText.Text, Int32.Parse(ageText.Text)));
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
            
            People person = (People) dataPerson.SelectedItem;
            
            listPerson.Where(p => p.Name.Equals(person.Name) && p.SurName.Equals(person.SurName)).ToList().ForEach(p =>
            {
                nameText.Text = p.Name;
                surnameText.Text = p.SurName;
                ageText.Text = p.Age.ToString();
            });
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            listPerson.Remove((People)dataPerson.SelectedItem);
            dataPerson.Items.Refresh();
        }
    }
}