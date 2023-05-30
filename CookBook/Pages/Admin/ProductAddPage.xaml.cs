using CookBook.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ProductAddPage.xaml
    /// </summary>
    public partial class ProductAddPage : Page
    {
        KniggaShopEntities1 _context = KniggaShopEntities1.GetContext();
        Book book = new Book();

        public ProductAddPage()
        {
            InitializeComponent();
            DataContext = book;
        }

        private void BtnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using(FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    MemoryStream ms = new MemoryStream();
                    stream.CopyTo(ms);
                    book.Photo = ms.ToArray();
                }

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(book.Photo);
                image.EndInit();
                ImageBook.Source = image;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
            MainFrame.Frame.Navigate(new ProductsPage());
        }
    }
}
