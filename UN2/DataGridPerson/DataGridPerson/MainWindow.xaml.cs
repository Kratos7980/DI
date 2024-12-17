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
            People people = new People();
            people.readP();
            dataPerson.ItemsSource = people.getListPeople();
            btnDelete.IsEnabled = false;
            btnNew.IsEnabled = false;
            nameText.Text = "";
            ageText.Text = "";
        }

        private void dataPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataPerson.SelectedItems.Count > 0)
            {
                btnNew.IsEnabled = true;
                btnDelete.IsEnabled = true;
                People people = (People)dataPerson.SelectedItems[0];
                nameText.Text = people.name;
                ageText.Text = people.age.ToString();
            }
        }

        private void start()
        {
            nameText.Text = "";
            ageText.Text = "";

            btnDelete.IsEnabled = false;
            btnNew.IsEnabled = false;
            dataPerson.SelectedItems.Clear();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            start();
            //if (!btnAgregar.Content.Equals("Update"))
            //{
               
            //    if (listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().Any() == false)
            //    {

            //        listPerson.Add(new People(nameText.Text, surnameText.Text, Int32.Parse(ageText.Text)));
            //        dataPerson.Items.Refresh();
            //        nameText.Clear();
            //        surnameText.Clear();
            //        ageText.Clear();
            //    }
            //    else
            //    {
            //        MessageBox.Show("La persona ya existe en la lista de persona. No se añade de nuevo.");
            //    } 
            //}
            
            //if(btnAgregar.Content.Equals("Update"))
            //{
            //    listPerson.Where(p => p.Name.Equals(nameText.Text) && p.SurName.Equals(surnameText.Text)).ToList().ForEach(p =>
            //    {
            //        p.Name = nameText.Text;
            //        p.SurName = surnameText.Text;
            //        p.Age = Int32.Parse(ageText.Text);
            //    });
            //    dataPerson.Items.Refresh();
            //    nameText.Clear();
            //    surnameText.Clear();
            //    ageText.Clear();
            //    btnModificar.IsEnabled = true;
            //    btnEliminar.IsEnabled = true;
            //    btnAgregar.Content = " Add Person";
            //}
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            if(!btnNew.IsEnabled)
            {
                if (MessageBox.Show("Do you want to add this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    People p = new People(nameText.Text, Int32.Parse(ageText.Text));
                    p.insert();
                    p.last();
                    ((List<People>)dataPerson.ItemsSource).Add(p);
                    dataPerson.Items.Refresh();
                }
            }
            else
            {
                if(MessageBox.Show("Do you want to modify the person is selected?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    List<People> listPeople = (List<People>)dataPerson.ItemsSource;
                    listPeople[dataPerson.SelectedIndex].name = nameText.Text;
                    listPeople[dataPerson.SelectedIndex].age = Int32.Parse(ageText.Text);
                    dataPerson.Items.Refresh();
                }
            }
            start();
            //btnAgregar.Content = "Update";
            //btnEliminar.IsEnabled = false;
            //btnModificar.IsEnabled = false;           

            //People person = (People) dataPerson.SelectedItem;

            //listPerson.Where(p => p.Name.Equals(person.Name) && p.SurName.Equals(person.SurName)).ToList().ForEach(p =>
            //{
            //    nameText.Text = p.Name;
            //    surnameText.Text = p.SurName;
            //    ageText.Text = p.Age.ToString();
            //});
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to remove this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                People people = (People)dataPerson.SelectedItem;
                people.delete();
                List<People> lst = (List<People>) dataPerson.ItemsSource;
                lst.Remove(people);
                dataPerson.Items.Refresh();
                dataPerson.ItemsSource = lst;
                start();
            }
            //listPerson.Remove((People)dataPerson.SelectedItem);
            //dataPerson.Items.Refresh();
            
        }

        
    }
}