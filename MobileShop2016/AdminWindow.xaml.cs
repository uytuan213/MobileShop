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

namespace MobileShop2016
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        QLBHEntities qlbh = new QLBHEntities();
        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            dgResult.DataContext = qlbh.Suppliers.ToList();
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            dgResult.DataContext = qlbh.Categories.ToList();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            var q = qlbh.Products.Include("Category").Include("Supplier").ToList();
            //var q = from p in qlbh.Products.Include("CategoryName").ToList();
            dgResult.DataContext = q;
        }
    }
}
