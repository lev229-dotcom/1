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
using System.Windows.Shapes;

namespace CookBook.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        KniggaShopEntities1 _context = KniggaShopEntities1.GetContext();
        Order order = new Order();

        public ProductsWindow()
        {
            InitializeComponent();
            Random rand = new Random();

            order.Date = DateTime.Today;
            order.Talon = rand.Next(100, 999);
            order.Point = "Ул. Фабричного, 5";
            DgBooks.ItemsSource = _context.Book.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Book bookTemp = (Book)DgBooks.SelectedItem;
            if(_context.Entry(order).State == System.Data.Entity.EntityState.Detached)
            {
                _context.Order.Add(order);
                _context.SaveChanges();
            }

            Book book = _context.Book.Where(x => x.ID == bookTemp.ID).First();

            OrderBook orderBook = new OrderBook();
            orderBook.Book = book;
            orderBook.Order = order;
            orderBook.Amount = 1;
            orderBook.Price = book.Price;
            orderBook.SalePrice = book.SalePrice;

            _context.OrderBook.Add(orderBook);
            _context.SaveChanges();
            BtnWatch.Visibility = Visibility.Visible;
        }

        private void BtnWatch_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(order);
            orderWindow.ShowDialog();
        }
    }
}
