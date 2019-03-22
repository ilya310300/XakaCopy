using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xakaton;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.Notification.MessagingStyle;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Table
{
    public partial class App : Application
    {
        public delegate void Message();
        public static Message tap;
        public static List<Dish> BasketDishes = new List<Dish>();
        public static TablePage tablePage = new TablePage();
        public static MainPage mainPage = new MainPage();
        public static DishPage dishPage = new DishPage();
        public static BasketPage basketPage = new BasketPage();
        public App()
        {
            InitializeComponent();
            MainPage = tablePage;
        }
        public App(Message Tap)
        {
            InitializeComponent();
            tap = Tap;
            MainPage = tablePage;
        }

        protected override void OnStart()
        {
            ExceptionInfo exceptionInfo = GetRequest.GET("restaurant/", new Restaurants() );
            if (exceptionInfo.exception == null)
            {
               tablePage.Restaurants = new ObservableCollection<Restaurant>(((Restaurants)exceptionInfo.info).restaurants);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
