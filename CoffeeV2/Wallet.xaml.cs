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

namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для Wallet.xaml
    /// </summary>
    public partial class Wallet : Window
    {
       
        public Wallet()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sd.Hide();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image d = (Image)sender;
            DragDrop.DoDragDrop(d, (string)d.Tag, DragDropEffects.Copy);

        }
    }
}
