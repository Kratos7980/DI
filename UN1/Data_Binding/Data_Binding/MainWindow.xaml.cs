
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
        }

        private void Big_Click(object sender, RoutedEventArgs e)
        {
            MiSlide.Value = 20;
        }

        private void Samall_Click(object sender, RoutedEventArgs e)
        {
            MiSlide.Value = 10;
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            MiSlide.Value = 15;
        }
    }
}