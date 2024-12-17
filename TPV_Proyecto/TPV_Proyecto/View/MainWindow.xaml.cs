using Mysqlx.Cursor;
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
        private List<Ticket> listTickets;
        private TicketManage tm;
        private ProductoManage pm;
        private double precioTotal;
        
        public MainWindow()
        {
            InitializeComponent();
            
            DBBroker.obtenerAgente().conectar();
            pm = new ProductoManage();
            CategoriaManage cm = new CategoriaManage();
            tm = new TicketManage();
            listTickets = new List<Ticket>();
            dataTicket.ItemsSource = listTickets;
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

            rellenarProductosPorCategorias(listCategoria, listGrid);

            start();
            precioTotal = 0.0;
            textTotal.Text = "Total: " + precioTotal + " €";
        }

        private void rellenarProductosPorCategorias(List<Categoria> listCategoria, List<Grid> listGrid)
        {
            int i = 1;
            while (i <= listCategoria.Count())
            {

                List<Producto> listProducto = new List<Producto>();
                listProducto = pm.readProducto(i);
                for (int j = 0; j < listProducto.Count(); j++)
                {
                    Button button = new Button();
                    button.Content = listProducto[j].nombre + "\n" + listProducto[j].precio + " €";
                    String name = listProducto[j].nombre.Split(' ')[0];

                    button.Click += btn_Click;
                    Grid.SetRow(button, 0);
                    Grid.SetColumn(button, j);
                    listGrid[i - 1].Children.Add(button);
                }
                i++;
            }
        }

        private void start()
        {
            btnImprimir.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
        }

        private void dataTicket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }

        // Control botones panel números.
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            string[] list = button.Content.ToString().Split('\n');

            String name = list[0];
            double precio = Double.Parse(list[1].Split(' ')[0]);
            int cantidad = 1;
            double total = 0;
            if (textNumber.Text.Contains("X"))
            {
                int num = Int32.Parse(textNumber.Text.ToString().Split('X')[0]);
                cantidad = num;
                total = cantidad * precio;
            }
            else
            {
                total = precio;
            }
            listTickets.Add(new Ticket(cantidad, name, precio, total));
            dataTicket.Items.Refresh();
            btnImprimir.IsEnabled = true;
            textNumber.Text = "0.0";
            precioTotal += total;
            textTotal.Text = "Total: " + precioTotal + " €";

        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "9";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "6";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "3";
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "0";
        }

        private void btnComa_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + ",";
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            borrarTexto();
            textNumber.Text = textNumber.Text + "X";
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            textNumber.Text = "0.0";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            ProductoManage pm = new ProductoManage();
            List<Ticket> list = (List<Ticket>)dataTicket.ItemsSource;
            int cantidad = 0;
            if (textNumber.Text.Contains('X'))
            {
                cantidad = Int32.Parse(textNumber.Text.Split('X')[0]);
            }
            else
            {
                cantidad = Int32.Parse(textNumber.Text);
            }
            

            switch (cantidad)
            {
                case 0:
                    MessageBox.Show("Minimo uno");
                    break;
                case 1:
                    precioTotal -= Double.Parse(list[dataTicket.SelectedIndex].total.ToString());
                    list[dataTicket.SelectedIndex].cantidad = cantidad;
                    list[dataTicket.SelectedIndex].total = pm.readPrecio(list[dataTicket.SelectedIndex].descripcion);
                    precioTotal += Double.Parse(list[dataTicket.SelectedIndex].total.ToString());
                    dataTicket.Items.Refresh();
                    textTotal.Text = "Total: " + precioTotal + " €";
                    textNumber.Text = "0.0";
                    break;
                default:
                    precioTotal -= Double.Parse(list[dataTicket.SelectedIndex].total.ToString());
                    list[dataTicket.SelectedIndex].cantidad = cantidad;
                    list[dataTicket.SelectedIndex].total = pm.readPrecio(list[dataTicket.SelectedIndex].descripcion) * cantidad;
                    precioTotal += Double.Parse(list[dataTicket.SelectedIndex].total.ToString());
                    dataTicket.Items.Refresh();
                    textTotal.Text = "Total: " + precioTotal + " €";
                    textNumber.Text = "0.0";
                    break;
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = (Ticket)dataTicket.SelectedItem;
            List<Ticket> list = (List<Ticket>)dataTicket.ItemsSource;
            list.Remove(ticket);
            precioTotal -= ticket.total;
            dataTicket.Items.Refresh();
            textTotal.Text = "Total: " + precioTotal + " €";
            if(list.Count() < 1)
            {
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                btnImprimir.IsEnabled = false;
            } 
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            List<Ticket> list = (List<Ticket>)dataTicket.ItemsSource;
            
            string fecha_actual = DateTime.Now.ToString("yyyy-MM-dd");

            list.ForEach(t =>
            {
                
                int codigo_producto = pm.readCodigo(t.descripcion);
                
                string total = t.total.ToString();
                string total_formateado = total.Replace(",", ".");
                tm.insertTicket(fecha_actual, Double.Parse(total_formateado));
                int codigo_ticket = tm.readCodigo(Double.Parse(total_formateado), fecha_actual);
                tm.insertProductoTicket(codigo_ticket, codigo_producto, t.cantidad);
            });
            MessageBox.Show("Imprimiendo ticket...");
            reiniciarPrograma();
        }

        private void reiniciarPrograma()
        {
            List<Ticket> listTicket = (List<Ticket>)dataTicket.ItemsSource;
            int num = listTicket.Count() - 1;
            while (listTicket.Count() > 0)
            {
                listTicket.Remove(listTicket[num]);
                dataTicket.Items.Refresh();
                num--;
            }
            precioTotal = 0;
            textTotal.Text = "Total: " + precioTotal + " €";
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnImprimir.IsEnabled = false;
        }

        private void borrarTexto()
        {
            if (textNumber.Text.Contains("0.0"))
            {
                textNumber.Text = "";
            }
        }
    }
}
