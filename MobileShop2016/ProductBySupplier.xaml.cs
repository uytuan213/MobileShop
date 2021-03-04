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
    /// Interaction logic for ProductBySupplier.xaml
    /// </summary>
    public partial class ProductBySupplier : Page
    {
        QLBHEntities qlbh = new QLBHEntities();
        public ProductBySupplier(int SupID)
        {
            InitializeComponent();
            Supplier s = qlbh.Suppliers.Where(sp => sp.SupplierID == SupID).FirstOrDefault();
            txtTitle.Text = s.SupplierName;
            this.DataContext = qlbh.Products.Where(p => p.SupplierID == SupID).ToList();
        }
    }
}
