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

namespace GRIDS_EXERCISES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    Label label = new Label();
                    label.Content = i+","+j;
                    label.HorizontalAlignment = HorizontalAlignment.Center;
                    label.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    contenedor.Children.Add(label);
                }
            }
        }
    }
}