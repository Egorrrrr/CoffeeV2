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
        Machine mainc;
        public Wallet wl;
        
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
            foreach (var item in FindVisualChildren<Americano>(cavasmn))
            {
                if((string)item.Tag == "t")
                {
                    Americano a = (Americano)item;
                    a.Acitve = false;
                }
            }
 
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
            Americano a = (Americano)sender;
            a.Acitve = !a.Acitve;
            Choice.Content = "Напиток:\n";
            Choice.Content += a.NameCoffee;
            mainc.Asked = a.Price;
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
            
            blnce.Content = "Кредит: ";
            
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
        private void DrinkDone(object sender, EventArgs e)
        {
            cook.Content = "Заберите напиток";
        }
        private void Taken(object sender, EventArgs e)
        {
            cook.Content = "Приготовить";
            GoDisable();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!chb.Commenced && mainc.Balance >= mainc.Asked)
            {
                chb.GoAtIt();
                chb.Prepared += new EventHandler(DrinkDone);
                chb.Taken += new EventHandler(Taken);
                cook.Content = "В процессе...";
            }
        }
    } 
}
