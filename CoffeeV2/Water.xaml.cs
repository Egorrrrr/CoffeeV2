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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeV2
{
    /// <summary>
    /// Логика взаимодействия для UserControl7.xaml
    /// </summary>
    public partial class Water : UserControl
    {
        public Water()
        {
            InitializeComponent();
        }
        public new Brush Background
        {
            get { return (Brush)GetValue(BrushWProperty); }
            set { SetValue(BrushWProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Colr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushWProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(Water), new PropertyMetadata(Brushes.Gray));
    }
}
