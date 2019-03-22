using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Table;

namespace Xakaton
{
    class DishViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Dish dish;

        public DishViewModel()
        {
            dish = new Dish();
        }

        public string title
        {
            get { return dish.title; }
            set
            {
                if (dish.title != value)
                {
                    dish.title = value;
                    OnPropertyChanged("title");
                }
            }
        }
        public string calories
        {
            get { return dish.calories; }
            set
            {
                if (dish.calories != value)
                {
                    dish.calories = value;
                    OnPropertyChanged("calories");
                }
            }
        }
        public string proteins
        {
            get { return dish.proteins; }
            set
            {
                if (dish.proteins != value)
                {
                    dish.proteins = value;
                    OnPropertyChanged("proteins");
                }
            }
        }
        public string fats
        {
            get { return dish.fats; }
            set
            {
                if (dish.fats != value)
                {
                    dish.fats = value;
                    OnPropertyChanged("fats");
                }
            }
        }
        public string carbs
        {
            get { return dish.carbs; }
            set
            {
                if (dish.carbs != value)
                {
                    dish.carbs = value;
                    OnPropertyChanged("carbs");
                }
            }
        }
        public string weight
        {
            get { return dish.weight; }
            set
            {
                if (dish.weight != value)
                {
                    dish.weight = value;
                    OnPropertyChanged("weight");
                }
            }
        }
        public string price
        {
            get { return dish.price; }
            set
            {
                if (dish.price != value)
                {
                    dish.price = value;
                    OnPropertyChanged("price");
                }
            }
        }
        public string image_1
        {
            get { return dish.image_1; }
            set
            {
                if (dish.image_1 != value)
                {
                    dish.image_1 = value;
                    OnPropertyChanged("image_1");
                }
            }
        }
        public string TitleAndWeight
        {
            get { return dish.TitleAndWeight; }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }   
    }
}
