using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop2016
{
    class MainDB:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        List<Product> bestSelling;
        public List<Product> BestSelling
        {
            get { return bestSelling; }
            set
            {
                if (value == bestSelling)
                    return;
                bestSelling = value;
                OnPropertyChanged("BestSelling");
            }
        }
        public List<Product> newestProducts;
        public List<Product> NewestProducts
        {
            get { return newestProducts; }
            set
            {
                if (value == newestProducts)
                    return;
                newestProducts = value;
                OnPropertyChanged("NewestProducts");
            }
        }


        public List<Product> mostViewing;
        public List<Product> MostViewing
        {
            get { return mostViewing; }
            set
            {
                if (value == mostViewing)
                    return;
                mostViewing = value;
                OnPropertyChanged("MostViewing");
            }
        }
    }
}
