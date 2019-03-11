using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaideStand
{
    class Recipe
    {
        public int numberOfPitchers;
        public int removeLemonsFromInventory;
        public int removeSugarFromInventory;
        public int removeIceFromInventory;
        public int removeCupFromInventory;
        int lemonsForRecipe = 6;
        int sugarForRecipe = 7;
        int iceForRecipe = 25;
        public int cupsForRecipe = 10;
        public void ChooseRecipe()
        {
            Console.WriteLine("Lets follow the recipe my daughters used...they made a killing with it and you will too!");
            Console.WriteLine("It contains 6 lemons, 7 cups of sugar, 25 ice cubes making 10 cups of lemonade.\n\n");
            Console.WriteLine("Are you ready to mix?  Enter Y or N.\n\n");
            string userinput = Console.ReadLine().ToUpper();
            switch (userinput)
            {
                case "Y":
                    ChooseNumberOfPitchers();
                    break;
                case "N":
                   // ChooseNumberOfPitchers();
                    break;

                default:
                    Console.WriteLine("Sorry, that is not an option.");
                    break;
            }
        }
        public int ChooseNumberOfPitchers()
        {
            Console.WriteLine("Things to keep in mind:");
            Console.WriteLine("1. The weather (the hotter it is the more cups you may sell)");
            Console.WriteLine("2. You can not save unused lemonade you did not sell the previous day.\n\n");
            Console.WriteLine("How many pitchers would you like to make?\n\n");
            try
            {
                int numberOfPitchers = int.Parse(Console.ReadLine());
                this.numberOfPitchers = numberOfPitchers;
                return this.numberOfPitchers;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops! You have to make less pitchers or run back to the store.");
                ChooseNumberOfPitchers();
                throw;
            }
        }

      
        public int TakeLemonsOut()
        {
            try
            {
                removeLemonsFromInventory = numberOfPitchers * lemonsForRecipe;
                return removeLemonsFromInventory;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops! You don't have enough lemons. Let's start this recipe over.\n\n");
                ChooseRecipe();
                throw;
            }

        }
        public int TakeSugarOut()
        {
            try
            {
                removeSugarFromInventory = numberOfPitchers * sugarForRecipe;
                return removeSugarFromInventory;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops! You don't have enough sugar.Let's start this recipe over.\n\n");
                ChooseRecipe();
                throw;
            }

        }
        public int TakeIceOut()
        {
            try
            {
                removeIceFromInventory = numberOfPitchers * iceForRecipe;
                return removeIceFromInventory;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops! You don't have enough ice. Let's start this recipe over.\n\n");
                ChooseRecipe();
                throw;
            }

        }
        
    }
}
