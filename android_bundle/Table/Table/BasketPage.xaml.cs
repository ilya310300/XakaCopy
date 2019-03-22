using System;
using System.Collections.Generic;
using Table;
using Xakaton.MyViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xakaton
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasketPage : ContentPage
	{
		public BasketPage ()
		{
			InitializeComponent();
		    Add();
		}

	    private int summ = 0;
	    private int kal = 0;
        public void Summ()
	    {	        
	        foreach (Grid bdv in MainStackLayout.Children)
	        {
                Dish dish = (Dish)bdv.BindingContext;
                summ = summ + Convert.ToInt32(dish.price);
	            kal = kal + Convert.ToInt32(dish.calories);
            }
	        MainLabel.Text = "Итого: " + summ + "₽" + ", " + kal + "ккал";
	    }

	    public void Add()
	    {
	        foreach (Dish dish in Dishes)
	        {
	            BasketDishView bdv = new BasketDishView(){ BindingClass = dish, LabelStyle = (Style)Resources["LabelInfo"]};
                MainStackLayout.Children.Add(bdv.View);
            }
        }

	    public List<Dish> Dishes
	    {
	        get { return App.BasketDishes; }
	    }

	    protected override bool OnBackButtonPressed()
	    {
	        base.OnBackButtonPressed();
	        App.Current.MainPage = App.tablePage;
	        return true;
	    }

	    public Dish HaveTap
	    {
	        set
	        {
	            summ -= Convert.ToInt32(value.price);
	            kal -= Convert.ToInt32(value.calories);
                MainLabel.Text = "Итого: " + summ + "₽" + ", " + kal + "ккал";
	            App.BasketDishes.Remove(value);
	        }
	    }

	    private void BasketPage_OnAppearing(object sender, EventArgs e)
	    {
	        Summ();
        }
	}
}