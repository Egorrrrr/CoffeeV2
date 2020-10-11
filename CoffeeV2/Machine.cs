using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CoffeeV2;
using System.Timers;
using static CoffeeV2.Americano;
using static CoffeeV2.Chamber;
using System.Windows.Media;

namespace CoffeeV2
{
    public abstract class DrinkClass
    {
        public string name;
        public int sugar;
        public Color CupColor;

    }
   
    public class Coffee : DrinkClass , IDrink
    {
        public bool milk;
        public Coffee(string name, bool milk, int sugar, Color c)
        {
            this.name = name;
            this.milk = milk;
            this.sugar = sugar;
            this.CupColor = c;
        }
        public Coffee()
        {
            this.name = "Drink";
            this.milk = false;
            this.sugar = 0;
            this.CupColor = Colors.Yellow;
        }
        public void Prepare(Chamber ch)
        {
            ch.GoAtIt(this.milk, this.sugar, this.CupColor);
        }
    }
    public class Tea : DrinkClass, IDrink
    {
        public Tea(string name, int sugar, Color c)
        {
            this.name = name;
            this.sugar = sugar;
            this.CupColor = c;
        }
        public Tea()
        {
            this.name = "Drink";
            this.CupColor = Colors.Orange;
            this.sugar = 0;
        }
        public void Prepare(Chamber ch)
        {
            ch.GoAtIt(this.sugar, this.CupColor);
        }
    }
    public class Other : IDrink 
    {
        public Color CupColor;
        public Americano drk;
        public string name;
        public Other(string name, Americano c, Color col)
        {
            this.name = name;
            drk = c;
            this.CupColor = col;

        }
        public Other()
        {
            drk = null;
            this.CupColor = Colors.White;
        }
        public void Prepare(Chamber ch)
        {
            ch.GoAtIt(drk, this.CupColor);
        }
    }



    class Machine :ICoffeeNes
    {
        


        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = +value;
            }
        } 
        public double Asked { get; set; }
        public TypeC Type { get; set; }
        public int Sugar { get; set; }
    }
}
