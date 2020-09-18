using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeV2;

namespace CoffeeV2
{
    public interface ICoffeeNes
    {
        bool Start(out string error);

        void Cancel();
        double Balance { get; set; }
        Drinks Drink { get; set; }
        bool IsOk(out string a);
      


        

    }
}
