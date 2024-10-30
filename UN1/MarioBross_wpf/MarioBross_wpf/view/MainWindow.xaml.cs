using MarioBross_wpf.domain;
using System.Configuration;
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

namespace MarioBross_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player mario = null;
        private int topPotions = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if(!textLives.Text.Equals("") && !textPotions.Text.Equals(""))
            {               
                if (Int32.TryParse(textLives.Text, out Int32 lives) && Int32.TryParse(textPotions.Text, out Int32 potions))
                {
                    btnStart.IsEnabled = false;
                    mario = new Player("M", lives);
                    topPotions = potions;
                }
                else
                {
                    MessageBox.Show("Sólo se adminten números");

                }
            }
            else
            {
                MessageBox.Show("Ambos campos deben rellenarse");
            }
        }
    }
}