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

namespace HelloWorld
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

        private void Button_Click_Hellow(object sender, RoutedEventArgs e)
        {
            HellowLabel.Content = "Hellow World";
            HellowLabel.Foreground = Brushes.Green;
        }

        private void Button_Click_Bye(object sender, RoutedEventArgs e)
        {
            HellowLabel.Content = "Bye World";
            HellowLabel.Foreground = Brushes.Turquoise;
        }
    }
}