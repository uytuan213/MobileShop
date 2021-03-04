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
    /// Interaction logic for ProductByCat.xaml
    /// </summary>
    public partial class ProductByCat : Page
    {
        QLBHEntities qlbh = new QLBHEntities();
        public ProductByCat(int catid)
        {
            InitializeComponent();
            Category cat = qlbh.Categories.Where(c => c.CategoryID == catid).FirstOrDefault();
            txtTitle.Text = cat.CategoryName;
            this.DataContext = qlbh.Products.Where(p => p.CategoryID == catid).ToList();
        }
    }
}
