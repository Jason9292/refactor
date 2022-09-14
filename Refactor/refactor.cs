using System;
using System.Collections.Generic;
using System.Linq;
namespace Interview_Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar, 1 pound of flour, 6 tbsp of butter, and 1 teaspoons of cinnamon to make 1 apple pie
            // this is intended to run on .NET Core
            Console.WriteLine("Welcome to Barry's Pie shop. Enter 'a' to calculate how many apple pies you can make, for blueberry pies enter 'b'");
            string typeOfPie = Console.ReadLine();

            if (typeOfPie == "a"){
                calculateAppliePies();
            }
            else{
                calculateBlueBerryPies();
            }
        }

        private static void calculateAppliePies(){
            do
            {
                List<PieGenerator.Ingredient> ingredients = new List<PieGenerator.Ingredient>();

                Console.WriteLine("How many apples do you have?");
                int apples;
                if (!int.TryParse(Console.ReadLine(), out apples)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = apples, measurementUnit = "count", name = "apples"});

                Console.WriteLine("How many pounds of sugar do you have?");
                int sugar;
                if (!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = sugar, measurementUnit = "pounds", name = "sugar"});

                Console.WriteLine("How many pounds of flour do you have?");
                int flour;
                if (!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = flour, measurementUnit = "pounds", name = "flour"});

                Console.WriteLine("How many teaspoons of cinnamon do you have?");
                int cinnamon;
                if (!int.TryParse(Console.ReadLine(), out cinnamon)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = cinnamon, measurementUnit = "teaspoons", name = "cinnamon"});

                Console.WriteLine("How many tablespoons of butter do you have?");
                int butter;
                if (!int.TryParse(Console.ReadLine(), out butter)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = butter, measurementUnit = "tablespoons", name = "butter"});

                var recipe = new Dictionary<string, int>()
                {
                    {"apples", 3}, 
                    {"sugar", 2}, 
                    {"flour", 1}, 
                    {"butter", 6}, 
                    {"cinnamon", 1}
                };

                PieGenerator.GeneratePieValues(ingredients, recipe, "apple");
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }

        private static void calculateBlueBerryPies(){
            do
            {
                List<PieGenerator.Ingredient> ingredients = new List<PieGenerator.Ingredient>();

                Console.WriteLine("How many cups of blueberries do you have?");
                int blueberries;
                if (!int.TryParse(Console.ReadLine(), out blueberries)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = blueberries, measurementUnit = "cups", name = "blueberries"});

                Console.WriteLine("How many zests of lemon do you have?");
                int lemonZest;
                if (!int.TryParse(Console.ReadLine(), out lemonZest)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = lemonZest, measurementUnit = "zests", name = "zests of lemon"});

                Console.WriteLine("How much sugar do you have?");
                int sugar;
                if (!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = sugar, measurementUnit = "cups", name = "sugar"});

                Console.WriteLine("How many cups of milk do you have?");
                int milk;
                if (!int.TryParse(Console.ReadLine(), out milk)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = milk, measurementUnit = "cups", name = "milk"});

                Console.WriteLine("How many cups of flour do you have?");
                int flour;
                if (!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = flour, measurementUnit = "cups", name = "flour"});

                Console.WriteLine("How many teaspoons of cinnamon do you have?");
                int cinnamon;
                if (!int.TryParse(Console.ReadLine(), out cinnamon)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = cinnamon, measurementUnit = "teaspoons", name = "cinnamon"});

                Console.WriteLine("How many tablespoons of butter do you have?");
                int butter;
                if (!int.TryParse(Console.ReadLine(), out butter)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new PieGenerator.Ingredient(){ quantity = butter, measurementUnit = "tablespoons", name = "butter"});

                var recipe = new Dictionary<string, int>()
                {
                    {"blueberries", 4}, 
                    {"zests of lemon", 1}, 
                    {"butter", 5}, 
                    {"flour", 1}, 
                    {"sugar", 1},
                    {"milk", 1},
                    {"cinnamon", 1}
                };

                PieGenerator.GeneratePieValues(ingredients, recipe, "blueberry");
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public class PieGenerator
    {
        public static void GeneratePieValues(List<Ingredient> ingredients, Dictionary<string, int> recipe, string typeOfPie)
        {
            List<int> findScarceIngredient = new List<int>();

            foreach(Ingredient ingrediant in ingredients){
                findScarceIngredient.Add(ingrediant.quantity / recipe.First(p => p.Key == ingrediant.name).Value);
            }

            int amountOfPies = findScarceIngredient.Min();

            Console.WriteLine("You can make: " + amountOfPies + " " + typeOfPie + " pies!");
            
            foreach (Ingredient ingrediant in ingredients){
                int leftoverValue = ingrediant.quantity - (amountOfPies * recipe.First(p => p.Key == ingrediant.name).Value);
                Console.WriteLine(leftoverValue + " " + ingrediant.measurementUnit + " " + ingrediant.name + " left over.");
            }
        }

        public class Ingredient{
            public int quantity;
            public string measurementUnit;
            public string name;
        }
    }

    
}
