using CrystalDecisions.ReportAppServer;
using ExamenJesusVelasco.domain;
using ExamenJesusVelasco.view;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ExamenJesusVelasco
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Socio> lstSocios;
        Socio socio;
        Libro libro;
        List<Genero> generos;
        List<Libro> lstLibros;
        List<Prestamo> prestamos;
        Prestamo prestamo;

        // Insert into examen.GENERO (Nombre) VALUES('FANTASIA');
        // Insert into examen.GENERO(Nombre) VALUES('POLICIACO');
        public MainWindow()
        {

            InitializeComponent();
            prestamo = new Prestamo();
            lstSocios = new List<Socio>();
            lstLibros = new List<Libro>();
            prestamos = new List<Prestamo>();
            prestamos = prestamo.selectAll();
            libro = new Libro();
            lstLibros = libro.leer();
            socio = new Socio();
            generos = new List<Genero>
            {
                new Genero(1, "FANTASIA"),
                new Genero(2, "POLICIACO")
            };
            lstSocios = socio.gLista();
            dataGridSocio.ItemsSource = lstSocios;
            dataGridSocio.Items.Refresh();
            dataGridLibro.ItemsSource = lstLibros;
            dataGridLibro.Items.Refresh();
            cbGenero.ItemsSource = generos;
            cbGenero.Items.Refresh();
            cbLibroP.ItemsSource = lstLibros;
            cbSocioP.ItemsSource = lstSocios;
            dataGridPrestamos.ItemsSource = prestamos;
            dataGridPrestamos.Items.Refresh();
            generarInformesCB();

        }

        /// <summary>Handles the SelectionChanged event of the dataGridPersonas control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void dataGridPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridSocio.SelectedItems.Count > 0)
            {
                Socio socio = (Socio)dataGridSocio.SelectedItems[0];
                txtNombre.Text = socio.Nombre;
                datePicker.SelectedDate = socio.FechaNacimiento;
                txtEmail.Text = socio.Email;
                txtTelf.Text = socio.Telefono.ToString();
            }
        }

        /// <summary>Handles the Click event of the btnAgregarSocio control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnAgregarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtTelf.Text) || datePicker.SelectedDate == null)
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Socio nuevoSocio = new Socio(txtNombre.Text, (DateTime)datePicker.SelectedDate, txtEmail.Text, Convert.ToInt32(txtTelf.Text));
            lstSocios.Add(nuevoSocio);
            nuevoSocio.insertar();
            lstSocios = socio.gLista();
            dataGridSocio.ItemsSource=lstSocios;
            cbSocioP.ItemsSource=lstSocios;
            cbSocioP.Items.Refresh();
            dataGridSocio.Items.Refresh();
            cbSocioP.Items.Refresh();
        }

        /// <summary>Handles the Click event of the btnModificarSocio control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnModificarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Quiere modificar este socio?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Socio socio = (Socio)dataGridSocio.SelectedItems[0];
                socio.Nombre = txtNombre.Text;
                socio.FechaNacimiento = (DateTime)datePicker.SelectedDate;
                socio.Email = txtEmail.Text;
                socio.Telefono = Convert.ToInt32(txtTelf.Text);
                socio.modificar();
                dataGridSocio.Items.Refresh();
            }
        }

        /// <summary>Handles the Click event of the btnEliminarSocio control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnEliminarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar este socio?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Socio socio = (Socio)dataGridSocio.SelectedItems[0];
                List<Socio> lst = (List<Socio>)dataGridSocio.ItemsSource;
                lst.Remove(socio);
                dataGridSocio.Items.Refresh();
                dataGridSocio.ItemsSource = lst;
                socio.borrar();
            }
        }

        /// <summary>Handles the Click event of the btnAgregarLibro control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnAgregarLibro_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreLibro.Text) || string.IsNullOrEmpty(txtAñoLibro.Text) ||
                string.IsNullOrEmpty(txtAutor.Text) || cbGenero.SelectedItem == null)
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Genero genero = cbGenero.SelectedItem as Genero;
            int idGenero = genero.Id;
            Libro nuevoLibro = new Libro(txtNombreLibro.Text, Convert.ToInt32(txtAñoLibro.Text), txtAutor.Text, idGenero)
            {
                GeneroString = genero.Nombre
            };
            lstLibros.Add(nuevoLibro);
            nuevoLibro.insertar();
            lstLibros = libro.leer();
            dataGridLibro.ItemsSource = lstLibros;
            cbLibroP.ItemsSource = lstLibros;
            cbLibroP.Items.Refresh();
            
            dataGridLibro.Items.Refresh();
        }

        /// <summary>Handles the Click event of the btnModificarLibro control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnModificarLibro_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridLibro.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un libro para modificar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("¿Quiere modificar este libro?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Libro libroSeleccionado = (Libro)dataGridLibro.SelectedItems[0];
                libroSeleccionado.Titulo = txtNombreLibro.Text;
                libroSeleccionado.Autor = txtAutor.Text;
                libroSeleccionado.Año = Convert.ToInt32(txtAñoLibro.Text);
                libroSeleccionado.Genero = ((Genero)cbGenero.SelectedItem).Id;
                libroSeleccionado.modificar();
                dataGridLibro.Items.Refresh();
            }
        }

        /// <summary>Handles the Click event of the btnEliminarLibro control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnEliminarLibro_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridLibro.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un libro para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("¿Quiere eliminar este libro?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Libro libroSeleccionado = (Libro)dataGridLibro.SelectedItems[0];
                lstLibros.Remove(libroSeleccionado);
                dataGridLibro.ItemsSource = lstLibros;
                dataGridLibro.Items.Refresh();
                libroSeleccionado.borrar();
            }
        }

        /// <summary>Handles the SelectionChanged event of the dataGridLibro control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void dataGridLibro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridLibro.SelectedItems.Count > 0)
            {
                Libro libroSeleccionado = (Libro)dataGridLibro.SelectedItems[0];
                txtAutor.Text = libroSeleccionado.Autor;
                txtAñoLibro.Text = libroSeleccionado.Año.ToString();
                cbGenero.SelectedItem = generos.FirstOrDefault(g => g.Id == libroSeleccionado.Genero);
                txtNombreLibro.Text = libroSeleccionado.Titulo;
            }
        }

        /// <summary>Handles the Click event of the btnAgregarPrestamo control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnAgregarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            if (cbLibroP.SelectedItem == null || cbSocioP.SelectedItem == null || dateFechaD.SelectedDate == null)
            {
                MessageBox.Show("Por favor, seleccione un libro, un socio y una fecha de préstamo.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Libro libroSeleccionado = (Libro)cbLibroP.SelectedItem;
            Socio socioSeleccionado = (Socio)cbSocioP.SelectedItem;
            DateTime fechaPrestamo = (DateTime)dateFechaP.SelectedDate;
            DateTime fechaDevolu = (DateTime)dateFechaD.SelectedDate;

            Prestamo nuevoPrestamo = new Prestamo
            {
                Libro = libroSeleccionado,
                Socio = socioSeleccionado,
                FechaPrestamo = fechaPrestamo,
                FechaDevolucion = fechaDevolu
            };
            prestamos.Add(nuevoPrestamo);
            nuevoPrestamo.insertar();
            dataGridPrestamos.Items.Refresh();
            MessageBox.Show("Préstamo agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>Handles the Click event of the btnModificarPrest control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnModificarPrest_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPrestamos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo para modificar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("¿Quiere modificar este préstamo?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Prestamo prestamoSeleccionado = (Prestamo)dataGridPrestamos.SelectedItems[0];
                prestamoSeleccionado.Libro = (Libro)cbLibroP.SelectedItem;
                prestamoSeleccionado.Socio = (Socio)cbSocioP.SelectedItem;
                prestamoSeleccionado.FechaPrestamo = (DateTime)dateFechaP.SelectedDate;
                prestamoSeleccionado.FechaDevolucion = (DateTime)dateFechaD.SelectedDate;
                prestamoSeleccionado.modificar();
                dataGridPrestamos.Items.Refresh();
                MessageBox.Show("Préstamo modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>Handles the Click event of the btnEliminarPrest control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnEliminarPrest_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPrestamos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("¿Quiere eliminar este préstamo?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Prestamo prestamoSeleccionado = (Prestamo)dataGridPrestamos.SelectedItems[0];
                prestamoSeleccionado.borrar();
                List<Prestamo> lstPrestamos = (List<Prestamo>)dataGridPrestamos.ItemsSource;
                lstPrestamos.Remove(prestamoSeleccionado);
                dataGridPrestamos.ItemsSource = lstPrestamos;
                dataGridPrestamos.Items.Refresh();
                MessageBox.Show("Préstamo eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>Handles the Click event of the btnGenerar control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            List<Libro> lista;
            lista = libro.leer();
            DataTable tabla1;
            tabla1 = new DataTable("DataTable1");
            tabla1.Columns.Add("Libro");
            tabla1.Columns.Add("Genero");
            foreach (Libro l in lista)
            {
                Genero generoLibro = generos.FirstOrDefault(g => g.Id == l.Genero);
                l.GeneroString = generoLibro.Nombre;
                Console.WriteLine("Añadido geneor: " + generoLibro.Nombre);
            }
            var listaOrdenada = lista.OrderBy(x => x.GeneroString); // Lista ordenada por nombre Genero
            foreach (Libro l in listaOrdenada)
            {
                string titulogenero = l.GeneroString;
                tabla1.Rows.Add(l.Titulo, titulogenero);
            }
            ListadoLibrosPorGenero report = new ListadoLibrosPorGenero();
            report.Database.Tables["DataTable1"].SetDataSource((DataTable)tabla1);
            crViewer.ViewerCore.ReportSource = report;
        }
        private void generarInformesCB()
        {


        }



        /// <summary>Handles the Click event of the btnGenerar2 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnGenerar2_Click(object sender, RoutedEventArgs e)
        {
            // informe 2
            List<Prestamo> prestamosL = new List<Prestamo>();
            DataTable tabla1;
            prestamosL = prestamo.selectAll();
            tabla1 = new DataTable("DataTable1");
            tabla1.Columns.Add("Socio");
            tabla1.Columns.Add("Libro");
            tabla1.Columns.Add("Fecha Prestamo");
            tabla1.Columns.Add("Fecha Devolucion");
            int mes = 0;
            int anio = 0;
            if (!Int32.TryParse(txtMes.Text, out mes) || (!Int32.TryParse(txtAnio.Text, out anio)))
            {
                MessageBox.Show("Fecha no valida");
            }
            else
            {
                var listaMes = prestamosL.Where(p => p.FechaDevolucion.Month == mes && p.FechaDevolucion.Year == anio).ToList();
                if (listaMes.Count > 0)
                {
                    foreach (Prestamo p in listaMes)
                    {
                        Socio socio = lstSocios.FirstOrDefault(s => s.Id == p.Socio.Id);
                        Libro libro = lstLibros.FirstOrDefault(s => s.Id == p.Libro.Id);
                        tabla1.Rows.Add(socio.Nombre, libro.Titulo, p.FechaPrestamo.ToString("dd/MM/yyyy"), p.FechaDevolucion.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Nombre:" + p.Socio.Nombre + " " + p.Libro.Titulo);
                    }
                    InformeMensual reportn = new InformeMensual();
                    reportn.Database.Tables["DataTable1"].SetDataSource((DataTable)tabla1);
                    crViewer.ViewerCore.ReportSource = reportn;
                }
                else
                {
                    MessageBox.Show("No hay prestamos en ese mes");
                }
            }
        }
    }
}
