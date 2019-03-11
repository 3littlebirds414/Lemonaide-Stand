using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonaideStand
{
    public class Customers
    {
        Random random;
        Double percent = 100;
        public double willPayMax;
        public int numberOfCupsToBuy;
        double chanceToBuy;
        double temperatureProbability;
        double conditionProbability;
        double costProbability;
        public double willingToPay;
       // public double justAReallyNicePerson;  CUTE IDEA
        public bool buy;

        public Customers(double WillPayMax, int NumberOfCupsToBuy)
        {
            willPayMax = WillPayMax;
            numberOfCupsToBuy = NumberOfCupsToBuy;
        }

        public void ChanceToBuyTemperature(Weather weather)
        {
            if (weather.temperature <= 70)
            {
                temperatureProbability = percent * 1.15;
            }
            else if (weather.temperature >= 80)
            {
                temperatureProbability = percent * 1.50;
            }
        }

        public void ChanceToBuyCondition (Weather weather)
        {
            if (weather.condition == "hot")
            {
                conditionProbability = percent * 1.85;
            }
            else if (weather.condition == "sunny")
            {
                conditionProbability = percent * 1.60;
            }
            else if (weather.condition == "partly cloudy" || weather.condition == "cloudy")
            {
                conditionProbability = percent * 1.45;
            }
        }
//NEED TO FIX willingToPay

        public void ChanceToBuyCost(Day day)
        {
            if (day.willingToPay == .25)
            {
                costProbability = percent * 1.10;
            }
            else if (day.willingToPay == .75)
            {
                costProbability = percent * 1.87;
            }
            else if (day.willingToPay == .90 || day.willingToPay == 1.00)
            {
                costProbability = percent * 1.70;
            }
            else if (day.willingToPay == 1.25)
            {
                costProbability = percent * .5;
            }
        }

        public double WillBuy()
        {
            List<double> actualChanceToBuy = new List<double>();
            actualChanceToBuy.Add(temperatureProbability);
            actualChanceToBuy.Add(conditionProbability);
            actualChanceToBuy.Add(costProbability);
            double chanceToBuy = actualChanceToBuy.Average();  //TO DO - ROUND THIS NUMBER
            this.chanceToBuy = chanceToBuy;
            return this.chanceToBuy;
        }


        public bool CustomerBuysLemonade(int RandomValue)
        {
            int value = 100;
            if (chanceToBuy <= value)
            {
                buy = false;
            }
            else
            {
                buy = true;
            }
            return this.buy;
        }

        public void DeterminsIfCustomerBuys(Weather weather, Day day, int randomValue)
        {
            ChanceToBuyTemperature(weather);
            ChanceToBuyTemperature(weather);
            ChanceToBuyCost(day);
            WillBuy();
            CustomerBuysLemonade(randomValue);
        }
    }
}