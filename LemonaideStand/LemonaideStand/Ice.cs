using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaideStand
{
    public class Ice : ICost
    {
        public double iceCost = .05;

        public double GetCost()
        {
            return iceCost;
        }
    }
}
