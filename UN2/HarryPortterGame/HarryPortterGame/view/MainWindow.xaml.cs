using HarryPortterGame.domain;
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


namespace HarryPortterGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Character harry = null;
        Character albus = null;
        Character ron = null;
        Ability a = null;
        List<Ability> listAbility = null;
        public MainWindow()
        {
            harry = new Character("Harry Potter", 100);
            albus = new Character("Albus Dumbeldor", 90);
            ron = new Character("Ron Wesley", 60);
            InitializeComponent();
            cboPlayer.Items.Add(harry.name);
            cboPlayer.Items.Add(albus.name);
            cboPlayer.Items.Add(ron.name);
            btnNew.IsEnabled = false;
            btnSave.IsEnabled = false;

            listAbility = new List<Ability>();
            dgvStore.ItemsSource = listAbility;
        }

        private void cboPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnNew.IsEnabled = true;
            switch (cboPlayer.SelectedIndex)
            {
                case 0:
                    lblAvaible.Content = "Avaible points: " + harry.points;
                    break;
                case 1:
                    lblAvaible.Content = "Avaible points: " + albus.points;
                    break;
                case 2:
                    lblAvaible.Content = "Avaible points: " + ron.points;
                    break;

            }
        }


        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            btnNew.IsEnabled = false;
            btnSave.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgvStore.Items.Refresh();
            btnNew.IsEnabled = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            a = (Ability) dgvStore.SelectedItem;
            listAbility.Remove(a);
            dgvStore.Items.Refresh();
        }

        private void wand_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled && btnSave.IsEnabled)
            {
                Ability a = new Ability("wand", 100);
                listAbility.Add(a);
            }
        }

        private void lightning_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled && btnSave.IsEnabled)
            {
                Ability a = new Ability("lightning", 50);
                listAbility.Add(a);
            }
        }

        private void brain_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled && btnSave.IsEnabled)
            {
                Ability a = new Ability("brain", 50);
                listAbility.Add(a);
            }
        }

    }
}