
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

namespace Data_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            colores.Items.Add("Rojo");
            colores.Items.Add("Verde");
            colores.Items.Add("Azul");
            colores.Items.Add("Amarillo");
        }

        private void Small_Click(object sender, RoutedEventArgs e)
        {
            MiSlide.Value = 10;
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            MiSlide.Value = 15;
        }

        private void Big_Click(object sender, RoutedEventArgs e)
        {
            MiSlide.Value = 20;
        }

        private void colores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(colores.SelectedIndex)
            {
                case 0:
                    {
                        textboxEjemplo.Foreground = Brushes.Red;
                        break;
                    }
                case 1:
                    {
                        textboxEjemplo.Foreground = Brushes.Green;
                        break;
                    }
                case 2:
                    {
                        textboxEjemplo.Foreground = Brushes.Blue;
                        break;
                    }
                case 3:
                    {
                        textboxEjemplo.Foreground = Brushes.Yellow;
                        break;
                    }
            }
        }
    }
}