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
        Random rnd = new Random();
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
                    mario = new Player("M", lives, potions);
                    rellenarGrid(mario);
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

        private void rellenarGrid(Player p)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Label label = new Label();
                    if(i == 0 && j == 0)
                    {
                        label.Content = p.getName();
                    }
                    else
                    {
                        int pieza = rnd.Next(0,3);

                        label.Content = pieza.ToString();
                    }
                    
                    label.HorizontalAlignment = HorizontalAlignment.Center;
                    label.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    tablero.Children.Add(label);
                }
            }
        }
    }
}