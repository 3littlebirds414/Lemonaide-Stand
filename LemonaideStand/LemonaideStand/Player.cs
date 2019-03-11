using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonaideStand
{
    public class Player
    {
        public Wallet wallet = new Wallet();
        public Inventory inventory = new Inventory();
        public Recipe recipe = new Recipe();
    }
}