using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonaideStand
{
    public class Weather
    {
        //public int Random;
        public int randomInteger;
        public int dailyTemperature;
        public int temperature;
        public int primeBuyingTemperature = 90;
        public string condition;
        double temperatureAffect;
        double conditionAffect;
        public int forecastTemperature;
        public string forecastCondition;

        private Random random;

        public int[] TemperatureOfWeather = new int[] { 60, 70, 80, 90, 100 };
        public string[] ConditionOfWeather = new string[] { "hot", "sunny", "cloudy", "partly cloudy", "rain" };

        public Weather(Random random)
        {
            this.random = random;
        }

         public void DailyTemperature()
        {
            int dailyTemperature = random.Next(0, TemperatureOfWeather.Length);
            temperature = TemperatureOfWeather[dailyTemperature];
        }
 /// WORK INPROGRESS PROBABILITY AFFECT OF TEMPERATURE ON PURCHASING
 
        public void TemperatureAffect()
        {

        }
    /// END


        public void DailyCondition()
        {
            int WeatherCondition = random.Next(0, ConditionOfWeather.Length);
            condition = ConditionOfWeather[WeatherCondition];
        }

/// WORK INPROGRESS PROBABILITY AFFECT OF CONDITION ON PURCHASING
        public void ConditionAffect()
        {
            if(condition == "hot" || condition == "sunny")
            {
                conditionAffect = 1;
            }

            else if (condition == "partly cloudy")
            {
                 conditionAffect = .6;
            }

            else if (condition == "cloudy")
            {
                 conditionAffect = .4;
            }
            
            else
            {
                conditionAffect = .1;
            }
        }
  //END

        public void CreateTodaysWeather()
        {
            List<string> weatherForCase = new List<string> { "Today is " };
            foreach (string day in weatherForCase)
            {
                DailyTemperature();
                DailyCondition();
            }
        }

        public void DisplayTodaysWeather()
        {
            Console.WriteLine("Todays weather is: {0} {1} \n\n", temperature, condition);
        }

        public void ForecastTemperature()
        {
            int DailyTemperature = random.Next(0, TemperatureOfWeather.Length);
            forecastTemperature = TemperatureOfWeather[DailyTemperature];
        }

        public void ForecastCondition()
        {
            int WeatherCondition = random.Next(0, ConditionOfWeather.Length);
            forecastCondition = ConditionOfWeather[WeatherCondition];
        }


        public void CreateForecastWeather()
        {
            List<string> weatherForecast = new List<string> { "Tommorow's ", "The next day's ", "And the day after that's " };
            foreach (string day in weatherForecast)
            {
                ForecastTemperature;
                ForecastCondition;
                Console.WriteLine(day + "forcast is {0} {1} \n\n", forecastTemperature, forecastCondition);
            }
        }
    }
}