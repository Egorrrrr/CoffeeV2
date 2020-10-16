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
using System.Runtime.Serialization;
using CoffeeV2;
using System.IO;
using Microsoft.Win32;
using static CoffeeV2.Americano;
using System.Runtime.Serialization.Formatters.Binary;

namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для Pnl.xaml
    /// </summary>
    /// 
    [Serializable]
    public class Sets
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public TypeC Type { get; set; }
        public string Img {get; set;}
        public byte ColorR { get; set; }
        public byte ColorG { get; set; }
        public byte ColorB { get; set; }
        public string Id { get; set; } 
        public bool Rdy { get; set; }
    }
    
    public partial class Pnl : UserControl
    {
        List<Sets> sets;
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
            load.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Visible;
            
        }
        public void Save()
        {
        
            foreach (var item in FindVisualChildren<Americano>(uc))
            {
                Sets set = new Sets();
                set.Id = item.Uid;
               
                set.Name = item.NameCoffee;
                set.ColorR = item.ColorChoice.R;
                set.ColorG = item.ColorChoice.G;
                set.ColorB = item.ColorChoice.B;
                set.Type = item.Type;
                set.Price = item.Price;
                set.Rdy = item.Ready;
                try
                {
                    if (item.drnk.Source.ToString() != null)
                        set.Img = item.drnk.Source.ToString();
                }
                catch (Exception)
                {
                    set.Img = "";
                }
                sets.Add(set);

            }
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ShowDialog();
                if (sfd.FileName == "") return;
                Stream st = File.Open(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, sets);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message);

            }
        }
        public void Load()
        {
            OpenFileDialog dial = new OpenFileDialog();
            dial.ShowDialog();
            if (dial.FileName == "") return;
            try
            {
                Stream st = File.OpenRead(dial.FileName);
                BinaryFormatter bf = new BinaryFormatter();
                List<Sets> tmp = bf.Deserialize(st) as List<Sets>;
                foreach (var item in tmp)
                {
                    foreach (var temp in FindVisualChildren<Americano>(uc))
                    {
                        if (temp.Uid == item.Id)
                        {
                            temp.NameCoffee = item.Name;
                            temp.Price = item.Price;
                            temp.ColorChoice = Color.FromRgb(item.ColorR, item.ColorG, item.ColorB);
                            if (item.Img != "")
                                temp.Drink = new BitmapImage(new Uri(item.Img));
                            temp.Type = item.Type;
                            temp.Ready = item.Rdy;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
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
            sets = new List<Sets>();
            
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
        public Americano GetById(string id)
        {
            foreach (var item in FindVisualChildren<Americano>(uc))
            {
                if(item.Uid == id)
                {
                    return item;
                }
            }
            return null;
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
                form.Avl.IsChecked = a.Ready;
                form.ShowDialog();
                a.Price = double.Parse(form.price.Text);
                a.NameCoffee = form.name.Text;
                a.Drink = form.pic.Source;
                a.Type = (TypeC)Enum.Parse(typeof(TypeC), form.type.Text);
                a.ColorChoice = form.cc.Color;
                a.Ready = (bool)form.Avl.IsChecked;


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
            save.Visibility = Visibility.Collapsed;
            load.Visibility = Visibility.Collapsed;

        }

     

        

        private void load_Click(object sender, RoutedEventArgs e)
        {
            Button s = (Button)sender;
            if (s.Name == "load") Load();
            else Save();
        }
    }
}
