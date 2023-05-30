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
using System.Windows.Shapes;

namespace CookBook.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow(bool isAdmin)
        {
            InitializeComponent();
            MainFrame.Frame = Frame;
            MainFrame.Frame.Navigate(new ProductsPage());

            if (!isAdmin)
            {
                BtnOrder.Visibility = Visibility.Hidden;
            }
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Frame.Navigate(new ProductsPage());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Frame.Navigate(new OrderPage());
        }
    }
}
