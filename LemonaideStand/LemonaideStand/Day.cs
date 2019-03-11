using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonaideStand
{
    public class Day
    {

        public Weather weather;
        public Customers customer;

        public int customersThroughoutDay = 50;
        public double stopSelling;
        Random random;
        int userInput;
        public double grossEarnings;
        public double netEarnings;
        public int customersTotal;
        public double sale; //To Do
        public double willingToPay;
        public int cupsToBeBought;
        public double pricePerCup;
        public double costPerCup;
        public List<int> cupsCustomerWillBuy;
        public double moneyEarned;
        public List<Customers> customers = new List<Customers>();
        List<double> costCustomersWillPay = new List<double> { .25, 1.00, .75, .90, 1.25 };
        List<int> costCustomersWillBuy = new List<int> { 1, 2, 1, 3, 1 };

        public Day(Random random)
        {
            weather = new Weather(random);
            this.random = random;
        }

        public double PriceOfCup()
        {
            Console.WriteLine("Please enter your price for one cup of lemonade: " );
            double pricePerCup = double.Parse(Console.ReadLine());
            this.pricePerCup = pricePerCup;
            return this.pricePerCup;
        }

        public double PayingCustomers()
        {
            int customersWillingToPay = random.Next(0, costCustomersWillPay.Count);
            willingToPay = costCustomersWillPay[customersWillingToPay];
            return willingToPay;
        }

        public int CustomersWillingnessToBuy()
        {
            int howManyCupsWillBeBought = random.Next(0, cupsCustomerWillBuy.Count);
            int cupsToBeBought = cupsCustomerWillBuy[howManyCupsWillBeBought];
            return cupsToBeBought;
        }


        public void CreateCustomers()
        {
            for (int i = 0; i < customersThroughoutDay; i++)
            {
                int numberOfCups = CustomersWillingnessToBuy();
                double amountToPay = PayingCustomers();
                Customers customer = new Customers(amountToPay, numberOfCups);
                customers.Add(customer);

            }
        }

        public SellLemonade(Player player)
        {
            for (int i = 0; i < stopSelling; i++)
            {

                if (customer[i].buy == true)
                {
                    sale = pricePerCup;
                    player.wallet.moneyInWallet += sale;
                    moneyEarned = sale * stopSelling;
                }

            Console.WriteLine("Here are your earnings:  {0}", moneyEarned);
            return player.wallet.moneyInWallet;
            }
        }
        /// Need to figure out how to remove number of pitchers
     
        public void calculatingWhenToStop (Player player)
        {
            stopSelling = player.recipe.cupsForRecipe * player.recipe.numberOfPitchers
        }
    }
}