using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using System.Linq;
using Xakaton;
using Xamarin.Forms;
using Android.Widget;

namespace Table.Droid
{
    [Activity(Label = "Еда МГТУ им.Баумана ", Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App(CreateToast));
        }

        public void CreateToast()
        {
            Toast.MakeText(this, "Товар перемещён в корзину", ToastLength.Long).Show();
        }
    }
}