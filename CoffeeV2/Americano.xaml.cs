using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для UserControl4.xaml
    /// </summary>
    public partial class Americano : UserControl
    {
        public enum TypeC
        {
            Coffee,
            Tea,
            Other
        }

        public TypeC Type
        {
            get { return (TypeC)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Type", typeof(TypeC), typeof(Americano), new PropertyMetadata(TypeC.Coffee));


        public Americano()
        {
            InitializeComponent();
        }
        public new Color Background
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Colr.  This enables animation, styling, binding, etc...
        public static  readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Background", typeof(Color), typeof(Americano), new PropertyMetadata(Colors.Gray));

        public string GetPrice(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsDigit(a[i]))
                {
                    continue;
                }
                a.Remove(i, 0);
                i--;
            }
            return a;
        }
        bool act = false;

        public double Price
        {
            get 
            {
                return (double)GetValue(PriceProperty);
            }
            set 
            {
                string rubles = value + "р.";
                SetValue(PriceProperty, rubles); 
            }
        }
        public static double a = 25;
        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(double), typeof(Americano), new PropertyMetadata(a));


        public ImageSource Drink
        {
            get { return (ImageSource)GetValue(DrinkProperty); }
            set { SetValue(DrinkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Drink.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrinkProperty =
            DependencyProperty.Register("Drink", typeof(ImageSource), typeof(Americano), new PropertyMetadata(null));


        public string NameCoffee
        {
            get { return (string)GetValue(NameCoffeeProperty); }
            set { SetValue(NameCoffeeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameCoffee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameCoffeeProperty =
            DependencyProperty.Register("NameCoffee", typeof(string), typeof(Americano), new PropertyMetadata(""));

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!act)
            {
                ColorAnimation ca = new ColorAnimation();
                ca.From = scb.Color;
                ca.To = Colors.Green;
                ca.Duration = TimeSpan.FromMilliseconds(200);
                scb.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            }
            scb.Color = Colors.Pink;

        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!act)
            {
                ColorAnimation ca = new ColorAnimation();
                ca.From = scb.Color;
                ca.To = Colors.Gray;
                ca.Duration = TimeSpan.FromMilliseconds(200);
                scb.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                return;
            }
            scb.Color = Colors.Pink;
            
        }


        public bool Acitve
        {
            get
            {
                return (bool)GetValue(AcitveProperty);
            }
            set 
            {
                if (value)
                {
                    ColorAnimation ca = new ColorAnimation();
                    ca.From = scb.Color;
                    ca.To = Colors.Pink;
                    ca.Duration = TimeSpan.FromMilliseconds(200);
                    scb.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                    act = true;
                }
                else
                {

                    scb.Color = Colors.Gray;
                    ColorAnimation ca = new ColorAnimation();
                    ca.From = scb.Color;
                    ca.To = Colors.Gray;
                    ca.Duration = TimeSpan.FromMilliseconds(200);
                    scb.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                    act = false;
                }
                SetValue(AcitveProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for Acitve.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AcitveProperty =
            DependencyProperty.Register("Acitve", typeof(bool), typeof(Americano), new PropertyMetadata(false));


    }






    







}
