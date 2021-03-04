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
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Page
    {
        QLBHEntities qlbh = new QLBHEntities();
        public ProductDetail(Product p)
        {
            InitializeComponent();
            gridInfo.DataContext = p;
            Random r = new Random();
            Product product = qlbh.Products.Where(pro => pro.ProductID == p.ProductID).FirstOrDefault();
            product.View++;
            qlbh.SaveChanges();
            lstRelated.DataContext = qlbh.Products.Where(pro => pro.CategoryID == p.CategoryID && pro.ProductID != p.ProductID).OrderBy(item=>Guid.NewGuid()).Take(5).ToList();
            lstSimilar.DataContext = qlbh.Products.Where(pro => pro.SupplierID == p.SupplierID && pro.ProductID != p.ProductID).OrderBy(item => Guid.NewGuid()).Take(5).ToList();
        }

        private void lstRelated_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            Product p = lb.SelectedItem as Product;
            Page pd = new ProductDetail(p);
            NavigationService.Navigate(pd);
        }

        private void lstSimilar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            Product p = lb.SelectedItem as Product;
            Page pd = new ProductDetail(p);
            NavigationService.Navigate(pd);
        }
    }
}
