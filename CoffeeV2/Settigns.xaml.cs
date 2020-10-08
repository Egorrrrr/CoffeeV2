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
using System.Windows.Shapes;
using CoffeeV2;
using System.IO;

using Microsoft.Win32;
using static CoffeeV2.Americano;


namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для Settigns.xaml
    /// </summary>
    public partial class Settigns : Window
    {
        List<string> ls = new List<string>();
        int pos = 0;
        public Settigns()
        {
            
            
            InitializeComponent();
            //MessageBox.Show(type.Text);
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            if (ofp.ShowDialog() == null)
            {

                Uri uri = new Uri(ofp.FileName);
                BitmapImage bmi = new BitmapImage(uri);
                pic.Source = bmi;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Button temp = (Button)sender;
            if(temp.Name == "ri")
            {
                pos++;
                if (pos > ls.Count - 1)
                {
                    pos = 0;
                } 
                type.Text = ls[pos];
            }
            else
            {
                pos--;
                if (pos < 0)
                {
                    pos = ls.Count-1;
                }
                type.Text = ls[pos];
            }
            if (type.Text != "Other")
            {
                clr.Visibility = Visibility.Collapsed;
                clrpick.Visibility = Visibility.Collapsed;
            }
            else
            {
                clr.Visibility = Visibility.Visible;
                clrpick.Visibility = Visibility.Visible;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string i in Enum.GetNames(typeof(TypeC)))
            {
                ls.Add(i);
            }
            string tt = "";
            foreach (var item in ls)
            {
                tt += item + " ";
            }
            //MessageBox.Show(tt);
            string aaa = "";
            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i] == type.Text)
                {
                    string tmp = ls[0];
                    ls[0] = ls[i];
                    ls[i] = tmp;
                    
                    break;

                }
            }
            if(type.Text == "Other")
            {
                clr.Visibility = Visibility.Visible;
                clrpick.Visibility = Visibility.Visible;
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            set.Close();
        }

        private void clrpick_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog a = new System.Windows.Forms.ColorDialog();
            a.ShowDialog();
            cc.Color = Color.FromArgb(a.Color.A, a.Color.R, a.Color.G, a.Color.B) ;
            

        }
    }
}
