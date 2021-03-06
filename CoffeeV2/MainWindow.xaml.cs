﻿using System;
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
using System.Windows.Threading;
using CoffeeV2;
using System.Timers;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Markup;
using static CoffeeV2.Americano;

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
        Americano chosen;
        bool changetaken = true;
        public MainWindow()
        {

            InitializeComponent();
            mainc = new Machine();
            wl = new Wallet();
            panelc.DrinkChosen += new EventHandler(ChoiceEvt);
            chb.Prepared += new EventHandler(DrinkDone);
            chb.Taken += new EventHandler(Taken);
            chb.UnableToCancel += new EventHandler(UnCacel);


        }
        private void ChoiceEvt(object sender, EventArgs e)
        {
            chosen = (Americano)sender;
            if (!chosen.Ready)
            {
                chosen.Acitve = false;
                return;
            }
            Choice.Content = "Напиток:\n" + chosen.NameCoffee;
            mainc.Asked = chosen.Price;
            mainc.Type = chosen.Type;
            if(mainc.Type == TypeC.Other)
            {
                SugarLock(true);
            }
            else if(sugarlocked)
            {
                SugarLock(false);
                Sugar.Content = "Сахар: ";
                
            }
            FullFill();
            
        }
        IDrink drkn; 
        void FullFill()
        {
            
            switch (chosen.Type)
            {
                case TypeC.Coffee:
                    Coffee cfe = new Coffee(chosen.NameCoffee, false, mainc.Sugar, Color.FromArgb(255, 92, 56, 4));
                    drkn = cfe;
                    break;
                case TypeC.MilkCoffee:
                    Coffee cfemikl = new Coffee(chosen.NameCoffee, true, mainc.Sugar, Color.FromArgb(255, 92, 56, 4));
                    drkn = cfemikl;
                    break;
                case TypeC.Tea:
                    Tea tea = new Tea(chosen.NameCoffee, mainc.Sugar, Color.FromArgb(255, 194, 137, 52));
                    drkn = tea;
                    break;
                case TypeC.Other:
                    Other other = new Other(chosen.NameCoffee, chosen, Color.FromArgb(255, 173, 171, 168));
                    drkn = other;
                    break;
                default:
                    break;
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
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



        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        

        private void mov_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
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
            mainc.Sugar = (int)sld.Value;

        }

        private void cavasmn_Loaded(object sender, RoutedEventArgs e)
        {
            Upd();
        }
        private void Upd()
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
            string a = e.Data.GetData(DataFormats.Text).ToString();
            if (a == "key" && !chb.Commenced)
            {
                panelc.Maintenance();
                return;
            }
            try
            {
                mainc.Balance += double.Parse(e.Data.GetData(DataFormats.Text).ToString());
                Upd();
            }
            catch (Exception)
            {
                return;
            }
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
            mainc.Balance -= mainc.Asked;
            cook.Content = "Заберите напиток";
        }
        private void Taken(object sender, EventArgs e)
        {
            if (mainc.Balance != 0)
            {
                cook.Content = "Заберите сдачу";
                changetaken = false;
                coins.Visibility = Visibility.Visible;
            }
            else
            {
                cook.Content = "Приготовить";
                Upd();
            }

        }
        bool sugarlocked = false;
        private void SugarLock(bool a)
        {
            sld.Value = 0;
            Sugar.Content = "Без сахара";
            sld.IsEnabled = !a;
            sugarlocked = a;
           
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (!chb.Commenced && (mainc.Balance >= mainc.Asked) && !chb.CoffeePrepared && !panelc.mtn && changetaken)
            {
                if(chosen == null)
                {
                    msg.Content = "Напиток не\nвыбран";
                    return;
                }
                msg.Content = "";
                
                drkn.Prepare(chb);
                
                cook.Content = "В процессе...";
                cancel.Visibility = Visibility.Visible;
            }
            else if(mainc.Balance < mainc.Asked && !chb.CoffeePrepared)
            {
                msg.Content = "Недостаточно\nсредств";
            }
        }

        
        private void UnCacel(object sender, EventArgs e)
        {
            cancel.Visibility = Visibility.Collapsed;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            cook.Content = "Приготовить";
            chb.Cancel();
            cancel.Visibility = Visibility.Collapsed;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void coins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            coins.Visibility = Visibility.Collapsed;
            changetaken = true;
            mainc.Balance = 0;
            cook.Content = "Приготовить";
            Upd();
        }
    } 
}
