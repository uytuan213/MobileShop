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
    /// Interaction logic for SearchProduct.xaml
    /// </summary>
    public partial class SearchProduct : Page
    {
        QLBHEntities qlbh = new QLBHEntities();
        public SearchProduct(string keyword)
        {
            InitializeComponent();
            txtTitle.Text = "Kết quả tìm kiếm cho từ khóa: " + keyword;
            this.DataContext = qlbh.Products.Where(p => p.ProductName.Contains(keyword)).ToList();
        }

        public SearchProduct(string keyword, int SupID, int CatID, decimal min = 0, decimal max = 50000000)
        {
            InitializeComponent();
            txtTitle.Text = "Kết quả tìm kiếm cho từ khóa: " + keyword;
            this.DataContext = qlbh.Products.Where(p => p.ProductName.Contains(keyword) && p.CategoryID == CatID && p.SupplierID == SupID && p.UnitPrice >= min && p.UnitPrice <= max).ToList();
        }
    }
}
