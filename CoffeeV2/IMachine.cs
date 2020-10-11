using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeV2;
using static CoffeeV2.Americano;

namespace CoffeeV2
{
    public interface ICoffeeNes
    {
        double Balance { get; set; }
        double Asked { get; set; }
        int Sugar { get; set; }
        TypeC Type { get; set; }


    }
    public interface IDrink
    {
        void Prepare(Chamber ch);
        
    }
}
