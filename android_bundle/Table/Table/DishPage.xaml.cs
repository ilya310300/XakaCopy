using System;
using Table;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xakaton
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DishPage : ContentPage
	{
		public DishPage ()
		{
			InitializeComponent ();
		}

	    private void DishPage_OnAppearing(object sender, EventArgs e)
	    {
	        Animation animation = new Animation(v => MGO = v, 0, 1);
	        animation.Commit(this, "Animation", 16, 800, Easing.CubicIn,
	            (v, c) => MGO = 1, () => false);
	    }

        public double MGO
	    {
	        set { MainGrid.Opacity = value; }
	    }

	    public Dish dish;
        public Dish DishView
        {
            set
            {
                dish = value;
                this.BindingContext = new DishViewModel
                {
                    title = value.title,
                    calories = value.calories + " ккал",
                    proteins = value.proteins + " г.",
                    fats = value.fats + " г.",
                    carbs = value.carbs + " г.",
                    weight = value.weight + "г",
                    price = value.price + " ₽",
                    image_1 = value.image_1
                };
            }
        }

	    protected override bool OnBackButtonPressed()
	    {
	        base.OnBackButtonPressed();
	        App.Current.MainPage = App.mainPage;
	        return true;
	    }

	    private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        App.BasketDishes.Add(dish);
	        App.tap();
	    }
	}
}