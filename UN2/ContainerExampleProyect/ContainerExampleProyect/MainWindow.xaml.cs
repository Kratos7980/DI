﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContainerExampleProyect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Button button = new Button();
                    button.Content = "Botón" + i + "," + j;
                    button.Height = 50;
                    button.Width = 100;
                    button.HorizontalAlignment = HorizontalAlignment.Left;
                    button.VerticalAlignment = VerticalAlignment.Top;
                    button.Margin = new Thickness(20 + i * 110, 10 + j * 55, 0, 0);
                    contenedor.Children.Add(button);
                }
            }
        }
    }
}