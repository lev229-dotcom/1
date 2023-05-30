using CookBook.Pages.Admin;
using CookBook.Pages.User;
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

namespace CookBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KniggaShopEntities1 _context = KniggaShopEntities1.GetContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            User user = _context.User.Where(x => x.Login == TbLogin.Text && x.Password == TbPassword.Text).FirstOrDefault();
            if(user != null)
            {
                if(user.Role == "User")
                {
                    ProductsWindow productsWindow = new ProductsWindow();
                    this.Close();
                    productsWindow.Show();
                }
                else if(user.Role == "Manager" || user.Role == "Admin")
                {
                    AdminMainWindow adminMainWindow = new AdminMainWindow(user.Role == "Admin");
                    this.Close();
                    adminMainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден!", "!!!!!!", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
        }

        private void BtnNoAuth_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            this.Close();
            productsWindow.Show();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            User user = new User() { Login = TbLogin.Text, Password = TbPassword.Text, Role = "User" };
            _context.User.Add(user);
            _context.SaveChanges();
            ProductsWindow productsWindow = new ProductsWindow();
            this.Close();
            productsWindow.Show();
        }
    }
}
