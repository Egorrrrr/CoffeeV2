using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    /// 
    public partial class Cappuccino : UserControl
    {
        
        public Cappuccino()
        {
            InitializeComponent();
        }

        
        public new Brush Background
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Colr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(Cappuccino), new PropertyMetadata(Brushes.Gray));



    }


    


}
