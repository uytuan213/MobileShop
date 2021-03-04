using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop2016
{
    class Database:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        List<Category> cats;
        public List<Category> Cats
        {
            get { return cats; }
            set
            {
                if (value == cats)
                    return;
                cats = value;
                OnPropertyChanged("Cats");
            }
        }
        public List<Supplier> suppliers;
        public List<Supplier> Suppliers
        {
            get { return suppliers; }
            set
            {
                if (value == suppliers)
                    return;
                suppliers = value;
                OnPropertyChanged("Suppliers");
            }
        }


        public List<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set
            {
                if (value == products)
                    return;
                products = value;
                OnPropertyChanged("Products");
            }
        }
    }
}
