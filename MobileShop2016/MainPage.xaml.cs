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

namespace MobileShop2016
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        QLBHEntities qlbh = new QLBHEntities();
        public MainPage()
        {
            InitializeComponent();
            MainDB db = FindResource("db") as MainDB;
            db.NewestProducts = qlbh.Products.OrderByDescending(p => p.ImportDate).Take(10).ToList();
            db.BestSelling = qlbh.Products.OrderByDescending(p => p.Sold).Take(10).ToList();
            db.MostViewing = qlbh.Products.OrderByDescending(p => p.View).Take(10).ToList();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            Product p = lb.SelectedItem as Product;
            Page pd = new ProductDetail(p);
            NavigationService.Navigate(pd);
        }
    }
}
