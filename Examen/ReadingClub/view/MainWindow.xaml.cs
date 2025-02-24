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
using ReadingClub.domain;
using ReadingClub.view;

namespace ReadingClub
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The list member
        /// </summary>
        List<Member> listMember = new List<Member>();
        /// <summary>
        /// The list genre
        /// </summary>
        List<Genre> listGenre = new List<Genre>();
        /// <summary>
        /// The list book
        /// </summary>
        List<Book> listBook = new List<Book>();
        /// <summary>
        /// The list loan
        /// </summary>
        List<Loan> listLoan = new List<Loan>();
        /// <summary>
        /// The empty member
        /// </summary>
        Member emptyMember = new Member();
        /// <summary>
        /// The empty genre
        /// </summary>
        Genre emptyGenre = new Genre();
        /// <summary>
        /// The empty book
        /// </summary>
        Book emptyBook = new Book();
        /// <summary>
        /// The empty loan
        /// </summary>
        Loan emptyLoan = new Loan();
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            listMember = emptyMember.getMembers();
            listGenre = emptyGenre.getGenres();
            listBook = emptyBook.getBooks();
            listLoan = emptyLoan.getLoans();
            dgMembers.ItemsSource = listMember;
            cbGenre.ItemsSource = listGenre;
            dgBooks.ItemsSource = listBook;
            cbMember.ItemsSource = listMember;
            cbBook.ItemsSource = listBook;
            dgMembers.ItemsSource = listMember;
            dgLoans.ItemsSource = listLoan;
        }

        #region Members
        /// <summary>
        /// Handles the Click event of the btnAddMember control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) || dpBirthDate.SelectedDate == null)
            {
                MessageBox.Show("Please, fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Member nMember = new Member(txtName.Text, (DateTime)dpBirthDate.SelectedDate, txtEmail.Text, Convert.ToInt32(txtPhone.Text));
            listMember.Add(nMember);
            
            nMember.insert();
            listMember = nMember.getMembers();
            dgMembers.ItemsSource = listMember;
            dgMembers.Items.Refresh();
            cbMember.ItemsSource = listMember;
            cbMember.Items.Refresh();

        }

        /// <summary>
        /// Handles the SelectionChanged event of the dgMembers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void dgMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMembers.SelectedItems.Count == 1)
            {
                Member member = (Member)dgMembers.SelectedItem;
                txtName.Text = member.Name;
                dpBirthDate.SelectedDate = member.BirthDate;
                txtEmail.Text = member.Email;
                txtPhone.Text = member.Phone.ToString();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnModifyMember control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnModifyMember_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to modify this member?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Member member = (Member)dgMembers.SelectedItem;
                int pos = listMember.IndexOf(member);
                member.Name = txtName.Text;
                member.BirthDate = (DateTime)dpBirthDate.SelectedDate;
                member.Email = txtEmail.Text;
                member.Phone = Convert.ToInt32(txtPhone.Text);
                member.modify();
                listMember[pos] = member;

                dgMembers.ItemsSource = listMember;
                dgMembers.Items.Refresh();
                cbMember.ItemsSource = listMember;
                cbMember.Items.Refresh();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteMember control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this member?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Member member = (Member)dgMembers.SelectedItem;
                listMember.Remove(member);
                dgMembers.ItemsSource = listMember;
                dgMembers.Items.Refresh();
                cbMember.ItemsSource = listMember;
                cbMember.Items.Refresh();
                member.delete();
                
            }
        }
        #endregion

        #region Books
        /// <summary>
        /// Handles the Click event of the btnAddBook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtAuthor.Text) ||
                cbGenre.SelectedItem == null || string.IsNullOrEmpty(txtYear.Text))
            {
                MessageBox.Show("Please, fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Book book = new Book(txtTitle.Text,txtAuthor.Text, ((Genre)cbGenre.SelectedItem).IdGenre, Convert.ToInt32(txtYear.Text));
            listBook.Add(book);

            book.insert();
            listBook = book.getBooks();
            dgBooks.ItemsSource = listBook;
            dgBooks.Items.Refresh();
            cbBook.ItemsSource = listBook;
            cbBook.Items.Refresh();
        }

        /// <summary>
        /// Handles the Click event of the btnModifyBook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnModifyBook_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to modify this book?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Book book = (Book)dgBooks.SelectedItem;
                int pos = listBook.IndexOf(book);
                book.Title = txtTitle.Text;
                book.Author= txtAuthor.Text;
                book.Genre = ((Genre)cbGenre.SelectedItem).IdGenre;
                book.PYear = Convert.ToInt32(txtYear.Text);
                listBook[pos] = book;
                book.modify();
                dgBooks.ItemsSource = listBook;
                dgBooks.Items.Refresh();
                cbBook.ItemsSource = listBook;
                cbBook.Items.Refresh();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteBook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this book?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Book book = (Book)dgBooks.SelectedItem;
                listBook.Remove(book);
                dgBooks.ItemsSource = listBook;
                dgBooks.Items.Refresh();
                cbBook.ItemsSource = listBook;
                cbBook.Items.Refresh();
                book.delete();
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dgBooks control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItems.Count == 1)
            {
                Book book = (Book)dgBooks.SelectedItem;
                txtTitle.Text = book.Title;
                cbGenre.SelectedItem = listGenre.FirstOrDefault(g=> g.IdGenre == book.Genre);
                txtAuthor.Text = book.Author;
                txtYear.Text = book.PYear.ToString();
            }
        }

        #endregion

        #region Loans
        /// <summary>
        /// Handles the Click event of the btnAddLoan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddLoan_Click(object sender, RoutedEventArgs e)
        {
            Member member = (Member)cbMember.SelectedItem;
            Book book = (Book)cbBook.SelectedItem;
            Loan loan = new Loan(member, book, (DateTime)dpDateLoan.SelectedDate,(DateTime)dpDateReturn.SelectedDate);
            listLoan.Add(loan);
            loan.insert();
            dgLoans.ItemsSource = listLoan;
            dgLoans.Items.Refresh();

        }

        /// <summary>
        /// Handles the Click event of the btnReturnBook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to return this book?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Loan loan = (Loan)dgLoans.SelectedItem;
                listLoan.Remove(loan);
                dgLoans.ItemsSource = listLoan;
                dgLoans.Items.Refresh();
                loan.delete();
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dgLoans control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void dgLoans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgLoans.SelectedItems.Count == 1)
            {
                Loan loan = (Loan)dgLoans.SelectedItem;
                cbMember.SelectedItem = loan.MemberL;
                cbGenre.SelectedItem = loan.BookL;
                dpDateLoan.SelectedDate = loan.LoanDate;
                dpDateReturn.SelectedDate = loan.ReturnDate;
            }
        }
        #endregion

        #region Reports
        /// <summary>
        /// Handles the Click event of the btnGenerateReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (cbReport.SelectedIndex == 0)
            {
                DataTable dataTableBooks = new DataTable("Books");
                dataTableBooks.Columns.Add("Genre");
                dataTableBooks.Columns.Add("Title");
                dataTableBooks.Columns.Add("Author");
                dataTableBooks.Columns.Add("Year");
                listBook = emptyBook.getBooks();
                List<Book> listBooksSorted = listBook.OrderBy(x => x.GenreString).ToList();
                foreach (Book book in listBooksSorted)
                {
                    DataRow row = dataTableBooks.NewRow();
                    row["Genre"] = book.GenreString;
                    row["Title"] = book.Title;
                    row["Author"] = book.Author;
                    row["Year"] = book.PYear;
                    dataTableBooks.Rows.Add(row);
                }
                BooksReport booksReport = new BooksReport();
                booksReport.Database.Tables["Books"].SetDataSource((DataTable)dataTableBooks);
                viewer.ViewerCore.ReportSource = booksReport;
            }
            else if (cbReport.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(txtMonth.Text))
                {
                    MessageBox.Show("Please, select a month.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(txtYearReport.Text))
                {
                    MessageBox.Show("Please, select a year.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    int month = 0;
                    int year = 0;
                    if (!Int32.TryParse(txtMonth.Text, out month) || (!Int32.TryParse(txtYearReport.Text, out year)))
                    {
                        MessageBox.Show("The date is not valid");
                    }
                    else
                    {
                        DataTable dataTableLoans = new DataTable("Loans");
                        dataTableLoans.Columns.Add("Member");
                        dataTableLoans.Columns.Add("Book");
                        dataTableLoans.Columns.Add("Loan date");
                        dataTableLoans.Columns.Add("Return date");
                        listLoan = emptyLoan.getLoans();
                        List<Loan> listLoansMonth = listLoan.Where(x => x.ReturnDate.Month == month && x.ReturnDate.Year == year).ToList();
                        foreach (Loan loan in listLoansMonth)
                        {
                            DataRow row = dataTableLoans.NewRow();
                            row["Member"] = loan.MemberL.Name;
                            row["Book"] = loan.BookL.Title;
                            row["Loan date"] = loan.LoanDate;
                            row["Return date"] = loan.ReturnDate;
                            dataTableLoans.Rows.Add(row);
                            
                        }
                        LoanReport loanReport = new LoanReport();
                        loanReport.Database.Tables["Loans"].SetDataSource((DataTable)dataTableLoans);
                        viewer.ViewerCore.ReportSource = loanReport;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please, select a report.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
           
        }


        #endregion

       
    }
}
