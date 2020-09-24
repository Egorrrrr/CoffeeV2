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
        string name;
    }
   
    public class Coffee : DrinkClass
    {
       
        
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
                if (value < 0) throw new ArgumentException("нельзя внести отрицательное количество денег");
                balance = +value;
            }
        } 
        public double Asked { get; set; }
       
       
        
       
        
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

        }
        public bool IsOk(out string a)
        {
            a = "";
            
            return true;
        }
        

    }
}
