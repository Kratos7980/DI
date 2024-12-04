using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPV_Proyecto.Domain;
using TPV_Proyecto.Persistence;
using TPV_Proyecto.Persistence.Manage;

namespace TPV_Proyecto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Producto> listProducto;
        private Button button;
        public MainWindow()
        {
            InitializeComponent();
            DBBroker.obtenerAgente().conectar();
            ProductoManage pm = new ProductoManage();
            CategoriaManage cm = new CategoriaManage();
            List<Categoria> listCategoria = new List<Categoria>();
            List<Grid> listGrid = new List<Grid>();
            listGrid.Add(cervezaContenedor);
            listGrid.Add(vinosContenedor);
            listGrid.Add(refrescosContenedor);
            listGrid.Add(comboContenedor);
            listGrid.Add(licoresContenedor);
            listGrid.Add(cafesContenedor);
            listGrid.Add(menusContenedor);
            listGrid.Add(combinadosContenedor);
            listGrid.Add(postresContenedor);
            listCategoria = cm.readCategoria();
            int i = 1;
            while( i <= listCategoria.Count())
            {
                
                List<Producto> listProducto = new List<Producto>();
                listProducto = pm.readProducto(i);
                for (int j = 0; j < listProducto.Count(); j++)
                {
                    button = new Button();
                    button.Content = listProducto[j].nombre + "\n" + listProducto[j].precio +"€";
                    String name = listProducto[j].nombre.Split(' ')[0];
                    button.Name = name;
                    button.Click += btn_Click;
                    Grid.SetRow(button, 0);
                    Grid.SetColumn(button, j);
                    listGrid[i-1].Children.Add(button);
                }
                i++;
            }
        }


        // Control botones panel números.

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(button.Content.ToString());

            //Crear un metodo que me devuelva el contenido de un botón pasándole el botón.
            //Crear Ticket
            
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "9";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "6";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "3";
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "0";
        }

        private void btnComa_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + ",";
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
            textNumber.Text = textNumber.Text + "X";
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            textNumber.Text = "0.0";
        }

        
    }
}
