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

namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для UserControl4.xaml
    /// </summary>
    public partial class Americano : UserControl
    {
        public Americano()
        {
            InitializeComponent();
        }
        public new Brush Background
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Colr.  This enables animation, styling, binding, etc...
        public static  readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(Americano), new PropertyMetadata(Brushes.Gray));

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


     








    }






    







}
