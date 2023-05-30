using CookBook.Utility;
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

namespace CookBook.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        KniggaShopEntities1 _context = KniggaShopEntities1.GetContext();

        public ProductsPage()
        {
            InitializeComponent();
            DgBooks.ItemsSource = _context.Book.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Frame.Navigate(new ProductAddPage());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Book book = (Book)DgBooks.SelectedItem;
            MainFrame.Frame.Navigate(new ProductEditPage(book));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Book book = (Book)DgBooks.SelectedItem;
            _context.Book.Remove(book);
            _context.SaveChanges();
            DgBooks.ItemsSource = _context.Book.ToList();
        }
    }
}
