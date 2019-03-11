using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaideStand
{
    public class Lemon : ICost
    {
        public double lemonCost = .10;

        public double GetCost()
        {
            return lemonCost;
        }
    }
}
