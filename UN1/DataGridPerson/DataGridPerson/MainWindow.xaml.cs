using DataGridPerson.Domain;
using DataGridPerson.Persistance;
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
            Person person = (Person)dataPerson.SelectedItem;
            person.Name = nameText.Text;
            person.SurName = surnameText.Text;
            person.Age = int.Parse(ageText.Text);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            listPerson.Remove((Person)dataPerson.SelectedItem);
            dataPerson.Items.Refresh();
        }
    }
}