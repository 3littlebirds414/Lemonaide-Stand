using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaideStand
{
    class Wallet
    {
        public double moneyInWallet = 10.0;
        bool bankrupt;
        double completeTransaction;
        double costOfProduct;
        public void DisplayBalance()
        {
            Console.WriteLine(moneyInWallet);
        }

        public bool checkIfBankrupt(double CostOfProduct)
        {
            if (moneyInWallet < CostOfProduct)
            {
                bankrupt = true;
                Console.WriteLine("Sorry! You don't have enough money in your wallet.");
            }
            return bankrupt;
        }
        public double buyProduct(double costOfProduct)
        {
            completeTransaction = moneyInWallet - costOfProduct;
            Console.WriteLine("Transaction Approved!!");
            moneyInWallet = completeTransaction;
            return moneyInWallet;
        }
        public void thisWeeksEarnings()
        {
            double earnings;
            double startingFunds = 10;
            earnings = moneyInWallet - startingFunds;
            Console.WriteLine("You made {0} this week!!!", earnings);
        }
    }
}
