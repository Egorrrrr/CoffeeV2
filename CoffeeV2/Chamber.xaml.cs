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


namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для Chamber.xaml
    /// </summary>
    public partial class Chamber : UserControl
    {
        private bool prepd = false;
        public bool CoffeePrepared { get { return prepd; } }
        private bool commenced= false;
        public bool Commenced { get { return commenced; } }
        public Chamber()
        {
            InitializeComponent();
        }
        public void GoAtIt()
        {
            if (!commenced && !prepd)
            {
                ColorAnimation sd = new ColorAnimation();
                sd.Completed += new EventHandler(Cup_Completed);
                SolidColorBrush sc = clr;
                sd.From = null;
                sd.To = Color.FromArgb(255, 251, 165, 100);
                sc.BeginAnimation(SolidColorBrush.ColorProperty, sd);
                commenced = true;
            }
        }
        private void Cup_Completed(object sender, EventArgs e)
        {

            DoubleAnimation da = new DoubleAnimation();
            da.Completed += new EventHandler(LiquidDone);
            da.From = 0;
            da.To = 50;
            da.Duration = TimeSpan.FromSeconds(2);
            da.AutoReverse = true;
            liquid.BeginAnimation(HeightProperty, da);
        }
        private void LiquidDone(object sender, EventArgs e)
        {
            DoubleAnimation enlargew = new DoubleAnimation();
            DoubleAnimation enlargeh = new DoubleAnimation();
            enlargew.From = Coffee.Width;
            enlargeh.From = Coffee.Height;
            enlargew.To = Coffee.Width * 1.5;
            enlargeh.To = Coffee.Height * 1.5;
            enlargeh.Completed += new EventHandler(Done);
            Coffee.BeginAnimation(Path.HeightProperty, enlargeh);
            Coffee.BeginAnimation(Path.WidthProperty, enlargew);
            if (Prepared != null)
            {
                Prepared(this, EventArgs.Empty);
            }
            commenced = false;
        }
        public event EventHandler Prepared;
        public event EventHandler Taken;

        private void Done(object sender, EventArgs e)
        {
           // MessageBox.Show("sds");
            prepd = true;
        }

        private void Coffee_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (prepd)
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
                if (Taken != null)
                {
                    Taken(this, EventArgs.Empty);
                }
                prepd = false;

            }
        }
    }
}
