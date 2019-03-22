using System;
using Table;
using Xamarin.Forms;

namespace Xakaton.MyViews
{
    public class BasketDishView : ViewCell
    {
        public BasketDishView()
        {
            View = Grid;
        }

        public string text1
        {
            set { label1.Text = value; }
        }

        public string text2
        {
            set { label2.Text = value; }
        }

        public Dish bindingClass;
        public Dish BindingClass
        {
            get { return bindingClass; }
            set
            {
                text2 = value.price + "₽";
                text1 = value.title;
                bindingClass = value;
                grid.BindingContext = value;
            }
        }

        public Style LabelStyle
        {
            set
            {
                label1.Style = value;
                label2.Style = value;
            }
        }

        private Grid grid;
        private Grid Grid
        {
            get
            {
                grid = new Grid(){ BackgroundColor = Color.White, Padding = new Thickness(10, 20, 20, 20) };
                grid.RowDefinitions.Add(new RowDefinition(){ Height = 40 });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });

                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap;
                Frame frame1 = new Frame(){ CornerRadius = 20, BackgroundColor = Color.FromHex("#5466a6"), Margin = new Thickness(3), GestureRecognizers = { tap }};
                Grid gridInFrame1 = new Grid(){ HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center};
                gridInFrame1.RowDefinitions.Add(new RowDefinition() { Height = 4 });
                gridInFrame1.ColumnDefinitions.Add(new ColumnDefinition(){ Width = 12 });
                BoxView box = new BoxView(){ BackgroundColor = Color.White };
                gridInFrame1.Children.Add(box, 0, 0);
                frame1.Content = gridInFrame1;           
                grid.Children.Add(frame1, 0, 0);

                Frame frame2 = new Frame() { CornerRadius = 20, BorderColor = Color.FromHex("#cea271") };
                Grid gridInFrame2 = new Grid();
                gridInFrame2.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
                gridInFrame2.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                gridInFrame2.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                label1 = new Label(){ LineBreakMode = LineBreakMode.TailTruncation };
                Frame frameInFrame2 = new Frame() { CornerRadius = 20, BorderColor = Color.FromHex("#cea271") };
                label2 = new Label() { HorizontalTextAlignment = TextAlignment.Center };
                frameInFrame2.Content = label2;
                gridInFrame2.Children.Add(label1, 0, 0);
                gridInFrame2.Children.Add(frameInFrame2, 1, 0);
                frame2.Content = gridInFrame2;
                grid.Children.Add(frame2, 1, 0);

                return grid;
            }
        }

        private Label label1;
        private Label label2;

        private void Tap(object sender, EventArgs e)
        {
            this.View.IsVisible = false;
            App.basketPage.HaveTap = BindingClass;
        }
    }
}
