using System;
using System.Collections.ObjectModel;
using Xakaton;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Table
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        public TablePage()
        {
            InitializeComponent();
        }

        public ObservableCollection<Restaurant> restaurants;

        public ObservableCollection<Restaurant> Restaurants
        {
            get { return restaurants; }
            set
            {
                restaurants = value;
                this.BindingContext = this;
            }
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Restaurant item = (Restaurant)((ListView) sender).SelectedItem;
            ((ListView) sender).SelectedItem = null;
            ExceptionInfo exceptionInfo = GetRequest.GET("dish/" + item.id + "/", new Dishes());
            if (exceptionInfo.exception == null)
            {
                App.mainPage = new MainPage();
                App.Current.MainPage = App.mainPage;
                App.mainPage.ImageSource = item.image;
                App.mainPage.Dishes = new ObservableCollection<Dish>(((Dishes)exceptionInfo.info).dishes);
                App.mainPage.DishesBuf = new ObservableCollection<Dish>(((Dishes)exceptionInfo.info).dishes);
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            App.basketPage = new BasketPage();
            App.Current.MainPage = App.basketPage;
        }
    }
}