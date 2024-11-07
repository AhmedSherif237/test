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

namespace library
{
    /// <summary>
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Page
    {
        libraryEntities db = new libraryEntities();
        public user()
        {
            InitializeComponent();
            Books_Table.ItemsSource = db.books.ToList();
        }

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;


            book selectedBook = (Books_Table.SelectedItem as book);

            if (selectedBook != null)
            {
                borrow borrow = new borrow
                {
                    CustomerName = custome_name.Text.ToString(),
                    BookId = selectedBook.BookId, 
                    BorrowDate = DateTime.Now,
                    ReturnDate = "2024-11-20" 
                };

                db.borrows.Add(borrow);
                db.SaveChanges();

                count++;
                borrow_table.ItemsSource = db.borrows.ToList();
                booksCount.Text = count.ToString();
            }
            else
            {
                MessageBox.Show("Please select a book.");
            }
        }
    }
    }
