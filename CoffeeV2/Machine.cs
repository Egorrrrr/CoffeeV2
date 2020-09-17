using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CoffeeV2;
using System.Timers;


namespace CoffeeV2
{
    public abstract class DrinkClass
    {
        private const int beancons = 1;
        private int sugar = 0;
        public  int Bc
        {
            get
            {
                return beancons;
            }
        }
        public int Sugar
        {
            set
            {
                int a = value;
                if (a > 5) a = 5;
                if (a < 0) a = 0;
                sugar = a;
            }
            get
            {
                return sugar;
            }
        }
        
        
       
    }
   
    public class CappucinoClass : DrinkClass
    {
        private const int milkcons = 3;
        public int Mc
        {
            get
            {
                return milkcons;
            }
        }
    }
    public enum Drinks
    {
        Mocca, 
        Espresso,
        Black,
        Capuccino,
        Tea,
        Water,
        Latte,
        Americano,
        None
    }

    class Machine :ICoffeeNes
    {
        


        private Drinks drink;
        private int beans;
        private int milk;
        private int sugar;
        private int sugarstock;
        private int milkneeded;
        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value < 0) throw new ArgumentException("нельзя внести отрицательное количество денег");
                balance = +value;
            }
        } 
       
        public int Beans
        {
            set
            {
                int tmp = value;
                if (tmp < 0) throw new Exception("Количество зерен не может быть отрицательным");
                if (tmp > 10) tmp = 100;
                beans = tmp;
                
            }
            get
            {
                return beans;
            }
        }
        public int Milk
        {
            set
            {
                int tmp = value;
                if (tmp < 0) throw new Exception("Количество молока не может быть отрицательным");
                if (tmp > 10) tmp = 100;
                milk = tmp;
                
            }
            get
            {
                return milk;
            }
        }
        public int Sugar
        {
            set
            {
                int tmp = value;
                if (tmp < 0) throw new Exception("Количество молока не может быть отрицательным");
                if (tmp > 5) tmp = 5;
                sugar = tmp;
            }
            get
            {
                return sugar;
            }
        }
        public int SugarStock
        {
            set
            {
                int tmp = value;
                if (tmp < 0) throw new Exception("Количество сахара не может быть отрицательным");
                if (tmp > 10) tmp = 100;
                sugarstock = tmp;

            }
            get
            {
                return sugarstock;
            }
        }
        public Drinks Drink
        {
            get
            {
                return drink;
            }
            set
            {
                drink = value;
            }
        }
        public void Refil()
        {
            milk = 100;
            beans = 100;
        }
        public bool Ready = false;
        public bool Start(out string error)
        {
            error = "";
            if(IsOk(out error))
            {

               return true;
            }
            return true; 
        }

        public void Cancel()
        {

        }
        public Machine()
        {
            Drink = Drinks.None;
            Sugar = 0;
            Beans = 100;
            Milk = 100;
            SugarStock = 100;
        }
        public bool IsOk(out string a)
        {
            a = "";
            
            return true;
        }
        

    }
}
