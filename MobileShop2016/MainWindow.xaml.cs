using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBHEntities qlbh = new QLBHEntities();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();
            Database db = this.FindResource("db") as Database;
            db.Cats = qlbh.Categories.ToList();
            db.Suppliers = qlbh.Suppliers.ToList();
            List<decimal> price = new List<decimal>() { 5000000, 10000000, 15000000, 20000000, 25000000, 30000000, 35000000, 40000000, 45000000, 50000000 };
            //CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            for (int i = 0; i < price.Count; i++)
            {
                cbbMinPrice.Items.Add(price[i].ToString("#,###"));
                cbbMaxPrice.Items.Add(price[i].ToString("#,###"));
            } 
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text;
            MainFrame.Content = new SearchProduct(keyword);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.Visibility = System.Windows.Visibility.Collapsed;
            btnRegister.Visibility = System.Windows.Visibility.Collapsed;
            btnInfo.Visibility = System.Windows.Visibility.Visible;
            btnCart.Visibility = System.Windows.Visibility.Visible;
            //Window Login = new Login();
            //Login.Owner = Application.Current.MainWindow;
            //Login.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            //Login.ShowDialog();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Contact();
        }

        private void miCats_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            Category curItem = (Category)mi.Items.CurrentItem;
            foreach (Category item in mi.Items)
            {
                if (item.CategoryID == curItem.CategoryID)
                    MainFrame.Content = new ProductByCat(item.CategoryID);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
        }

        private void miSups_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            Supplier curItem = (Supplier)mi.Items.CurrentItem;
            foreach (Supplier item in mi.Items)
            {
                if (item.SupplierID == curItem.SupplierID)
                    MainFrame.Content = new ProductBySupplier(item.SupplierID);
            }
        }

        private void btnAdvSearch_Click(object sender, RoutedEventArgs e)
        {
            string key = txtAdvKey.Text;
            Supplier s = (Supplier)cbbSup.SelectedItem;
            Category c = null;
            if(s != null)
            {
                c = (Category)cbbCat.SelectedItem;
                if(c == null)
                {
                    MessageBox.Show("Vui lòng nhập loại sản phẩm cần tìm!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập nhà sản xuất cần tìm!");
                return;
            }

            if (cbbMinPrice.SelectedValue != null && cbbMaxPrice.SelectedValue != null)
            {
                decimal min = decimal.Parse(cbbMinPrice.SelectedValue.ToString());
                decimal max = decimal.Parse(cbbMaxPrice.SelectedValue.ToString());
                MainFrame.Content = new SearchProduct(key, s.SupplierID, c.CategoryID, min, max);
            }
            else if (cbbMinPrice.SelectedValue != null)
            {
                decimal min = decimal.Parse(cbbMinPrice.SelectedValue.ToString());
                MainFrame.Content = new SearchProduct(key, s.SupplierID, c.CategoryID, min);
            }
            else if (cbbMaxPrice.SelectedValue != null)
            {
                decimal max = decimal.Parse(cbbMaxPrice.SelectedValue.ToString());
                MainFrame.Content = new SearchProduct(key, s.SupplierID, c.CategoryID, 0, max);
            }
            else
                MainFrame.Content = new SearchProduct(key, s.SupplierID, c.CategoryID);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.NavigationService.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward)
                MainFrame.NavigationService.GoForward();
        }
    }
}
