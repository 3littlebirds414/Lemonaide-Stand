using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaideStand
{
    public class Sugar : ICost
    {
        public double sugarCost = .35;

        public double GetCost()
        {
            return sugarCost;
        }
    }
}
