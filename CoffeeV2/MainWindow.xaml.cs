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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoffeeV2;
using System.Timers;
using Microsoft.Win32;



namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///
   
    public partial class MainWindow : Window
    {
        Brush std;
        Machine mainc;
        public Wallet wl;
        bool cuptaken = true;
        
        public MainWindow()
        {

            InitializeComponent();
            mainc = new Machine();
            wl = new Wallet();


        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }



        public void GoDisable()
        {
            
 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        

        private void mov_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Drink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GoDisable();
            UserControl tmp = (UserControl)sender;
           

            Upd();
            
            
        }

        private void Moc_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }
        

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sugar.Content = "Сахар: ";
            for (int i = 0; i < sld.Value; i++)
            {
                Sugar.Content += "▮";
            }

        }

        private void cavasmn_Loaded(object sender, RoutedEventArgs e)
        {
            Upd();
        }
        public void Upd()
        {
            Choice.Content = "Напиток:";
            blnce.Content = "Кредит: ";
            switch (mainc.Drink)
            {
                case Drinks.Americano:
                    {
                        Choice.Content += "\nАмерикано";
                        break;
                    }
                case Drinks.Capuccino:
                    {
                        Choice.Content += "\nКаппучино";
                        break;
                    }
                case Drinks.Mocca:
                    {
                        Choice.Content += "\nМоккачино";
                        break;
                    }
                case Drinks.Water:
                    {
                        Choice.Content += "\nВода";
                        break;
                    }
                case Drinks.Black:
                    {
                        Choice.Content += "\nЧерный кофе";
                        break;
                    }
                case Drinks.Latte:
                    {
                        Choice.Content += "\nЛатте";
                        break;
                    }
                case Drinks.Tea:
                    {
                        Choice.Content += "\nЧай";
                        break;
                    }
                case Drinks.Espresso:
                    {
                        Choice.Content += "\nЭсперессо";
                        break;
                    }
            }
            blnce.Content += mainc.Balance + "р.";
        }

        private void wallet_Click(object sender, RoutedEventArgs e)
        {
            wl.Show();
            
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            mainc.Balance += double.Parse(e.Data.GetData(DataFormats.Text).ToString());
            Upd();
        }

        private void Rectangle_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }


        }
        private  void Cup_Completed(object sender, EventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Completed += new EventHandler(LiquidDone); 
            da.From = 0;
            da.To = 50;
            da.Duration = TimeSpan.FromSeconds(2);
            da.AutoReverse = true;
            liquid.BeginAnimation(Rectangle.HeightProperty, da);
        } 
        private void LiquidDone(object sender, EventArgs e)
        {
            DoubleAnimation enlargew = new DoubleAnimation();
            DoubleAnimation enlargeh = new DoubleAnimation();
            enlargew.From = Coffee.Width;
            enlargeh.From = Coffee.Height;
            enlargew.To = Coffee.Width * 1.5;
            enlargeh.To = Coffee.Height* 1.5;
            Coffee.BeginAnimation(Path.HeightProperty, enlargeh);
            Coffee.BeginAnimation(Path.WidthProperty, enlargew);
            cook.Content = "Заберите напиток";

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.DefaultExt = ".png";
            dia.Filter = "Images (.Png)|*.Png";

            if (dia.ShowDialog() == true )
            {
                Uri ur = new Uri(dia.FileName);
                Amr.Drink = new BitmapImage(ur);

            }
            
            if (mainc.IsOk(out string a) && cuptaken)
            {
                cuptaken = false;
                cook.Content = "В процессе";
                ColorAnimation sd = new ColorAnimation();
                sd.Completed += new EventHandler(Cup_Completed);
                SolidColorBrush sc = clr;
                sd.From = null;
                sd.To = Color.FromArgb(255,251,165,100);
                sc.BeginAnimation(SolidColorBrush.ColorProperty, sd);
                Upd();
                

                //liquid.BeginAnimation(Rectangle.HeightProperty, null);
            }

        }

        private void Coffee_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Coffee.Height == 48)
            {
                DoubleAnimation enlargew = new DoubleAnimation();
                DoubleAnimation enlargeh = new DoubleAnimation();
                enlargeh.Duration = TimeSpan.FromSeconds(0);
                enlargew.Duration = TimeSpan.FromSeconds(0);
                enlargew.From = Coffee.Width;
                enlargeh.From = Coffee.Height;
                enlargew.To = Coffee.Width / 1.5;
                enlargeh.To = Coffee.Height / 1.5;
                Coffee.BeginAnimation(Path.HeightProperty, enlargeh);
                Coffee.BeginAnimation(Path.WidthProperty, enlargew);
                liquid.Height = 0;
                ColorAnimation ca = new ColorAnimation();
                ca.From = Color.FromArgb(255, 251, 165, 100);
                ca.To = null;
                ca.Duration = TimeSpan.FromSeconds(0);
                SolidColorBrush sb = clr;
                clr.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                cuptaken = true;
                cook.Content = "Приготовить";
            }

            
        }
    }
}
