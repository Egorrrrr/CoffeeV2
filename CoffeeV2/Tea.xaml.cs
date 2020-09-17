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
    /// Логика взаимодействия для UserControl6.xaml
    /// </summary>
    public partial class Tea : UserControl
    {
        public Tea()
        {
            InitializeComponent();
        }
        public new Brush Background
        {
            get { return (Brush)GetValue(BrushTProperty); }
            set { SetValue(BrushTProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Colr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushTProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(Tea), new PropertyMetadata(Brushes.Gray));
    }
}
