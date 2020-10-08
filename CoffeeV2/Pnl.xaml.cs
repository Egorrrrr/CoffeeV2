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
using CoffeeV2;
using static CoffeeV2.Americano;

namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для Pnl.xaml
    /// </summary>
    /// 
    [Serializable]
    public partial class Pnl : UserControl
    {
        bool page = true;
        public bool mtn = false;
        public void Maintenance()
        {
            foreach (var item in FindVisualChildren<Americano>(uc))
            {
                if((string)item.Tag == "t")
                {
                    item.Acitve = true;
                }
            }
            mtn = true;
            stop.Visibility = Visibility.Visible;
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
        public Pnl()
        {
            InitializeComponent();
            Amr.Name = "dsds";
            
        }

       

        private void rar_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle tmp = (Rectangle)sender;
            SolidColorBrush tmp2;
            if(tmp.Name == "rar")
            {
                tmp2 = scb;
                if (!page) return;

            }
            else
            {
                tmp2 = scb2;
                if (page) return;
            }
            ColorAnimation ca = new ColorAnimation();
            ca.From = Color.FromArgb(60,255,255,255);
            ca.To = Color.FromArgb(140, 255, 255, 255);
            ca.Duration = TimeSpan.FromMilliseconds(200);
            tmp2.BeginAnimation(SolidColorBrush.ColorProperty, ca);

        }

        private void rar_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle tmp = (Rectangle)sender;
            SolidColorBrush tmp2;
            if (tmp.Name == "rar")
            {
                tmp2 = scb;
                if (!page) return;
            }
            else
            {
                tmp2 = scb2;
                if (page) return;
            }
            ColorAnimation ca = new ColorAnimation();
            ca.From = Color.FromArgb(140, 255, 255, 255);
            ca.To = Color.FromArgb(60, 255, 255, 255); 
            ca.Duration = TimeSpan.FromMilliseconds(200);
            tmp2.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        private void rar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle tmpC = (Rectangle)sender;
           
            foreach (var item in FindVisualChildren<Americano>(uc))
            {
                Control tmp = (Control)item;
                if (page && tmpC.Name == "lar") return;
                if (!page && tmpC.Name == "rar") return;

                if (tmp.Visibility == Visibility.Collapsed)
                {
                    tmp.Visibility = Visibility.Visible;
                }
                else
                {
                    tmp.Visibility = Visibility.Collapsed;
                }
            }
            if (page)
            {
                scb.BeginAnimation(SolidColorBrush.ColorProperty, null);
                scb.Color = Color.FromArgb(60, 255, 255, 255);
                rg.Foreground = Brushes.White;
                page = false;
                lt.Foreground = Brushes.SpringGreen;
            }
            else
            {
                scb2.BeginAnimation(SolidColorBrush.ColorProperty, null);
                scb2.Color = Color.FromArgb(60, 255, 255, 255);
                lt.Foreground = Brushes.White;
                page = true;
                rg.Foreground = Brushes.SpringGreen;

            }
        }
        public void GoDisable()
        {
            foreach (var item in FindVisualChildren<Americano>(uc))
            {
                if ((string)item.Tag == "t")
                {
                    Americano a = (Americano)item;
                    a.Acitve = false;
                }
            }

        }

        private void Drink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Americano a = (Americano)sender;
            if (mtn)
            {
                Settigns form = new Settigns();
                form.price.Text = a.Price.ToString();
                form.name.Text = a.NameCoffee;
                form.pic.Source = a.Drink;
                form.type.Text = a.Type.ToString();
                form.cc.Color = a.ColorChoice;
                form.ShowDialog();
                a.Price = double.Parse(form.price.Text);
                a.NameCoffee = form.name.Text;
                a.Drink = form.pic.Source;
                a.Type = (TypeC)Enum.Parse(typeof(TypeC), form.type.Text);
                a.ColorChoice = form.cc.Color;


                return;
            }
            GoDisable();
            
            a.Acitve = !a.Acitve;
            if (DrinkChosen != null)
            {
                DrinkChosen(sender, EventArgs.Empty);
            }
        }
        public event EventHandler DrinkChosen;

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            mtn = false;
            foreach (var item in FindVisualChildren<Americano>(uc))
            {
                if ((string)item.Tag == "t")
                {
                    item.Acitve = false;
                }
            }
            stop.Visibility = Visibility.Collapsed;

        }
    }
}
