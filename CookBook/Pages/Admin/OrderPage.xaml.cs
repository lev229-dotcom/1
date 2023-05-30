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
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CookBook.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        KniggaShopEntities1 _context = KniggaShopEntities1.GetContext();
        Order orderSelected = new Order();

        public OrderPage()
        {
            InitializeComponent();
            _context.Order.Load();
            ReloadOrders();
            //DgOrders.ItemsSource = _context.Order.AsNoTracking().ToList();
            CbProduct.ItemsSource = _context.Book.ToList();
        }

        private void ReloadOrders()
        {
            var list = _context.Order.ToList();
            //DgOrders.ItemsSource = _context.Order.AsNoTracking().ToList();
            foreach(Order order in list)
            {
                order.Sum = order.OrderBook.Sum(x => x.Price);
                order.SaleSum = order.OrderBook.Sum(x => x.SalePrice);
            }
            DgOrders.ItemsSource = list;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Order order = _context.Order.Where(x => x.ID == orderSelected.ID).First();
            _context.Order.Remove(order);
            _context.SaveChanges();
            ReloadOrders();
        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            OrderBook bookTemp = (OrderBook)DgOrderProducts.SelectedItem;
            OrderBook book = _context.OrderBook.Where(x => x.ID == bookTemp.ID).First();
            _context.OrderBook.Remove(book);
            _context.SaveChanges();
            ReloadOrders();
        }

        private void DgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgOrders.SelectedItem != null)
            {
                orderSelected = (Order)DgOrders.SelectedItem;
            }

            DgOrderProducts.ItemsSource = _context.OrderBook.Include(x => x.Book).Where(x => x.OrderID == orderSelected.ID).AsNoTracking().ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Book bookTemp = (Book)CbProduct.SelectedItem;
            Book book = _context.Book.Where(x => x.ID == bookTemp.ID).First();

            Order order = _context.Order.Where(x => x.ID == orderSelected.ID).First();

            OrderBook orderBook = new OrderBook();
            orderBook.Amount = Convert.ToInt32(TbAmount.Text);
            orderBook.Book = book;
            orderBook.Order = order;
            orderBook.Price = book.Price * orderBook.Amount;
            orderBook.SalePrice = book.SalePrice * orderBook.Amount;

            _context.OrderBook.Add(orderBook);
            _context.SaveChanges();

            ReloadOrders();
            DgOrderProducts.ItemsSource = _context.OrderBook.Include(x => x.Book).Where(x => x.OrderID == orderSelected.ID).AsNoTracking().ToList();
        }
    }
}
