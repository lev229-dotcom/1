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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CookBook.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        KniggaShopEntities1 _context = KniggaShopEntities1.GetContext();
        Order order;

        public OrderWindow(Order order)
        {
            InitializeComponent();
            this.order = order;
            UpdateLabels();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            OrderBook bookTemp = (OrderBook)DgBooks.SelectedItem;
            OrderBook book = _context.OrderBook.Include(x => x.Book).Where(x => x.ID == bookTemp.ID).First();

            if (Convert.ToInt32(TbAmount.Text) <= 0)
            {
                _context.OrderBook.Remove(book);
                _context.SaveChanges();
            }
            else
            {
                book.Amount = Convert.ToInt32(TbAmount.Text);
                book.Price = book.Amount * book.Book.Price;
                book.SalePrice = book.Amount * book.Book.SalePrice;
                _context.SaveChanges();
            }

            UpdateLabels();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderBook bookTemp = (OrderBook)DgBooks.SelectedItem;
            OrderBook book = _context.OrderBook.Where(x => x.ID == bookTemp.ID).First();
            _context.OrderBook.Remove(book);
            _context.SaveChanges();
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            DgBooks.ItemsSource = _context.OrderBook.Include(x => x.Book).Where(x => x.OrderID == order.ID).ToList();

            LbCode.Content = order.Talon;
            LbDate.Content = order.Date.ToShortDateString();
            LbPrice.Content = order.OrderBook.Sum(x => x.Price);
            LbSalePrice.Content = order.OrderBook.Sum(x => x.SalePrice);
        }
    }
}
