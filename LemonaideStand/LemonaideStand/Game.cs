using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaideStand
{
    public class Game
    {
        public Random random;
        public Weather weather;
        public Player player;
        public Store store;
        public Day day;
        public int randomValue;

        public Game()
        {
            random = new Random();
            weather = new Weather(random);
            player = new Player();
            store = new Store();
            day = new Day(random);
        }
        public void RunGame()
        {
            day.CreateCustomers();
            RandomNumber();
            DisplayWelcome();
            day.SellLemonade(player);
        }
        public void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the game Lemonade Stand.  Your goal is to make as much money as possible for seven days.\n\n");
            Console.WriteLine("You start this game with $10.00 and you should use this to buy supplies.");
            Console.WriteLine("Please hit [enter] to go to the main menu.");
            Console.ReadLine();
            Console.Clear();
            MakeWeather();
            MainMenu();
        }
        public void MakeWeather()
        {
            day.weather.CreateTodaysWeather();
        }
        public void MainMenu()
        {
            Console.WriteLine("Please type in the number of the menu item you would like to select.\n\n");
            Console.WriteLine("1: Rules\n\n2: Weather\n\n3: Check Wallet\n\n4: Run to the store\n\n5: Check inventory\n\n6: Check recipe and make Lemonade.\n\n7: Set price and play game");
            string value = Console.ReadLine();
            switch (value)
            {
                //Rules
                case "1":
                    Console.Clear();
                    DisplayRules();
                    break;

                //Weather
                case "2":
                    Console.Clear();
                    day.weather.DisplayTodaysWeather();
                    day.weather.CreateForecastWeather();
                    Console.WriteLine("please hit [enter] to go to the main meun.");
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu();
                    break;

                //Wallet
                case "3":
                    Console.Clear();
                    player.wallet.DisplayBalance();
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu();
                    break;

                //store
                case "4":
                    Console.Clear();
                    store.Restock(player);
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu();
                    break;

                //inventory
                case "5":
                    Console.Clear();
                    player.inventory.ShowAllProductInventory();
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu();
                    break;

                //pitchers
                case "6":
                    Console.Clear();
                    player.inventory.ShowAllProductInventory();
                    player.recipe.ChooseRecipe();
                    //fix
                   // player.inventory.RemoveItemAfterLemonadeWasMade(player);
                    //Console.WriteLine("You now have {0} cups of lemonade!!", (player.recipe.numberOfPitchers * player.recipe.cupsForRecipe));
                    //fix
                    //day.CalculatingWhenToStopSelling(player);
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu();
                    break;

                //Set price and Play Game
                case "7":
                    Console.Clear();
                    day.PriceOfCup();
                    for (int d = 1; d <= 7; d++)
                    {

                        for (int i = 0; i < day.stopSelling; i++)
                        {
                            day.customers[i].DeterminsIfCustomerBuys(day.weather, day, randomValue);
                        }
                        day.SellLemonade(player);
                        MainMenu();
                    }
                    player.wallet.thisWeeksEarnings();
                    Console.ReadLine();
                    RestartGame();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Sorry, that we don't have an option for that.\n\n");
                    MainMenu();
                    break;
            }
        }
        public void DisplayRules()
        {
            Console.WriteLine("Welcome to my game Lemonade Stand.\n\n");
            Console.WriteLine("Start each morning by checking the weather");
            Console.WriteLine("Then your check your inventory to see if you need run to the store to pick up more supplies.");
            Console.WriteLine("After that, you will determine the total number of cups of lemonade you want to make for the day. \n\n\n");
            Console.WriteLine("You only get to make one batch throughout the day. So if you make too little you risk selling out.");
            Console.WriteLine("Make too much and you will have leftovers which you CANNOT use the next day.\n\n\n");
            Console.WriteLine("Finally, you will set a the price per cup.");
            Console.WriteLine("please hit 'enter' to take you back to the menu.");
            Console.ReadLine();
            Console.Clear();
            MainMenu();
        }
        public void RestartGame()
        {
            Console.WriteLine("Would you like to replay the game? [Y] or [N]");
            string answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
                case "Y":
                    DisplayWelcome();
                    break;
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Sorry, that we don't have an option for that.\n\n");
                    break;

            }
        }
        public int RandomNumber()
        {
            return randomValue = random.Next(1, 100);
        }
    }
}