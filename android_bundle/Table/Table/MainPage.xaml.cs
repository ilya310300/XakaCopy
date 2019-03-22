using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Table;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xakaton
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
    {
		public MainPage ()
		{
			InitializeComponent ();
		}

	    private void MainPage_OnAppearing(object sender, EventArgs e)
	    {
	        Animation animation = new Animation(v => LVO = v, 0, 1);
	        animation.Commit(this, "Animation", 16, 800, Easing.CubicIn,
	            (v, c) => LVO = 1, () => false);
        }

        public void ItemsAdd()
        {
            Dishes.Clear();
            if (Filter != "")
            {
                foreach (Dish dish in DishesBuf)
                {
                    if (dish.category == Filter)
                    {
                        Dishes.Add(dish);
                    }
                }
            }
            else
            {
                foreach (Dish dish in DishesBuf)
                {
                    Dishes.Add(dish);
                }
            }
        }

        public string Filter = "";

        private void Soups_OnTapped(object sender, EventArgs e)
        {
            if (Filter != "soup")
            {
                Filter = "soup";
            }
            else
            {
                Filter = "";
            }
            ItemsAdd();
        }
        private void Garnish_OnTapped(object sender, EventArgs e)
        {
            if (Filter != "garnish")
            {
                Filter = "garnish";
            }
            else
            {
                Filter = "";
            }
            ItemsAdd();
        }
        private void Main_OnTapped(object sender, EventArgs e)
        {
            if (Filter != "main")
            {
                Filter = "main";
            }
            else
            {
                Filter = "";
            }
            ItemsAdd();
        }
        private void Salads_OnTapped(object sender, EventArgs e)
        {
            if (Filter != "salad")
            {
                Filter = "salad";
            }
            else
            {
                Filter = "";
            }
            ItemsAdd();
        }
        private void Drinks_OnTapped(object sender, EventArgs e)
        {
            if (Filter != "drink")
            {
                Filter = "drink";
            }
            else
            {
                Filter = "";
            }
            ItemsAdd();
        }

        public string ImageSource
        {
            set { MainImage.Source = value; }
        }

        public double LVO
        {
            set { ListViewMain.Opacity = value; }
        }

        public ObservableCollection<Dish> dishes;

	    public ObservableCollection<Dish> Dishes
	    {
	        get { return dishes; }
	        set
	        {
	            dishes = value;
	            this.BindingContext = this;
	        }
	    }

        public ObservableCollection<Dish> DishesBuf { get; set; }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        Dish item = (Dish)((ListView)sender).SelectedItem;
	        ((ListView)sender).SelectedItem = null;
	        App.Current.MainPage = App.dishPage;
            App.dishPage.DishView = item;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = App.tablePage;
            return true;
        }
    }
}