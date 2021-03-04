using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop2016
{
    class DetailDB:INotifyPropertyChanged
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
        Product product;
        public Product Product
        {
            get { return product; }
            set
            {
                if (value == product)
                    return;
                product = value;
                OnPropertyChanged("Product");
            }
        }
        public List<Product> relatedProducts;
        public List<Product> RelatedProducts
        {
            get { return relatedProducts; }
            set
            {
                if (value == relatedProducts)
                    return;
                relatedProducts = value;
                OnPropertyChanged("RelatedProducts");
            }
        }


        public List<Product> similarProducts;
        public List<Product> SimilarProducts
        {
            get { return similarProducts; }
            set
            {
                if (value == similarProducts)
                    return;
                similarProducts = value;
                OnPropertyChanged("SimilarProducts");
            }
        }
    }
}
