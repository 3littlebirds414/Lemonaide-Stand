using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonaideStand
{
    public class Store
    {
        double checkOutLemons;
        double checkOutIceCubes;
        double checkOutSugar;
        public int lemonsNeeded;
        public int bagsOfSugarNeeded;
        public int bagsOfIceNeeded;


        public void Restock(Player player)
        {
            Console.WriteLine("What are you needing? Please type L for lemons, I for ice, or S for sugar.  Lets get you all set! \n\n");
            string stock = Console.ReadLine().ToLower();
            switch (stock)
            {
                case "l":
                    GetLemons(player);
                    break;
                case "i":
                    GetIce(player);
                    break;
                case "s":
                    GetSugar(player);
                    break;
            }
        }

 //LEMONS SECTION

        public int NumberOfLemonsNeeded(Player player)
        {
            Console.WriteLine("Lemons cost 50 cents each.\n\n");
            Console.WriteLine("How many lemons would you like?\n\n");
            try
            {
                int lemonsNeeded = int.Parse(Console.ReadLine());
                return lemonsNeeded;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops...type a number instead, ok?\n\n");
                Restock(player);
            }
        }

        public double NumberOfLemonsPurchased(int NumberOfLemonsToBuy)
        {
            Lemon lemon = new Lemon();
            checkOutLemons = lemon.GetCost() * NumberOfLemonsToBuy;
            return checkOutLemons;
        }

        public void PayForLemons (Player player)
        {
            if (player.wallet.checkIfBankrupt(checkOutLemons))
            {
                Restock(player);
            }
            else
            {
                player.wallet.buyProduct(checkOutLemons);
            }
        }
        //CALLING FOR LEMONS
        public void GetLemons(Player player)
        {
            int numberOfLemons = NumberOfLemonsNeeded(player);
            NumberOfLemonsPurchased(numberOfLemons);
            PayForLemons(player);
            player.inventory.AddLemons(numberOfLemons);
            Restock(player);
        }

//SUGAR SECTION
        public int BagsOfSugarNeeded(Player player)
        {
            Console.WriteLine("A bag of sugar is $2.50 for 4 lbs.\n\n");
            Console.WriteLine("How many bags would you like?\n\n");
            try
            {
                int bagsOfSugarNeeded = int.Parse(Console.ReadLine());
                return bagsOfSugarNeeded;
            }
            catch(Exception)
            {
                Console.WriteLine("Whoopsie...try to enter a number,ok?\n\n");
                Restock(player);
            }
        }

        public double BagsOfSugarPurchased(int bagsOfSugarNeeded)
        {
            Sugar sugar = new Sugar();
            checkOutSugar = sugar.GetCost() * bagsOfSugarNeeded;
            return checkOutSugar;
        }

        public void PayForSugar(Player player)
        {
            if(player.wallet.checkIfBankrupt(checkOutSugar))
            {
                Restock(player);
            }
            else
            {
                player.wallet.buyProduct(checkOutSugar);
            }
        }
//CALLING THE SUGAR
        public void GetSugar(Player player)
        {
            int bagsOfSugar = BagsOfSugarNeeded(player);
            BagsOfSugarPurchased(bagsOfSugar);
            PayForSugar(player);
            player.inventory.AddSugar(bagsOfSugar);
            Restock(player);
        }

//ICE SECTION
        public void BagsOfIceNeeded(Player player)
        {
            Console.WriteLine("A bag of ice is $2.00.\n\n");
            Console.WriteLine("How many bags of ice would you like?\n\n");

            try
            {
                int bagsOfIceNeeded = int.Parse(Console.ReadLine());
                if (player.wallet.checkIfBankrupt(2*bagsOfIceNeeded) == false)
                {
                    player.inventory.AddIce(bagsOfIceNeeded);
                    player.wallet.moneyInWallet -= bagsOfIceNeeded * 2;
                }
                else
                {
                    Console.WriteLine("No money!");
                }
               
                //return bagsOfIceNeeded;
            }
            catch(Exception)
            {
                Console.WriteLine("Whoops!  Enter a number next time,ok?\n\n");
                Restock(player);
            }

        } 

        public int BagsOfIcePurchased(int bagsOfIceNeeded)
        {
            Ice ice = new Ice();
            checkOutBagsOfIce = ice.GetCost() * bagsOfIceNeeded;
            return checkOutBagsOfIce;
        }
        
        public void PayForIce(Player player)
        {
            if(player.wallet.checkIfBankrupt(checkOutBagsOfIce))
            {
                Restock(player);
            }
            else
            {
                player.wallet.buyProduct(checkOutBagsOfIce);
            }
        }

        public void GetIce (Player player)
        {
            int bagsOfIce = BagsOfIceNeeded(player);
            BagsOfIceNeeded(bagsOfIce);
            PayForIce(player);
            player.inventory.AddIce(bagsOfIce);
        }

    }
    
}