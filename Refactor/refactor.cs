using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
namespace Interview_Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar, 1 pound of flour, 6 tbsp of butter, and 1 teaspoons of cinnamon to make 1 apple pie
            // this is intended to run on .NET Core
            string typeofCalculation = printOptions();

            foreach ()
            switch (typeofCalculation){
                case "ApplePie":
                    calculateAppliePies();
                    break;
                case "BlueBerryPie":
                    calculateBlueBerryPies();
                    break;
                case "Espresso":
                    calculateEspresso();
                    break;
                default:
                    calculatePourOvers();
                    break;
            }
        }

        public string GetTypeOfCalculation(){
            List<RecipeIngredientCalculator.Ingredient> recipes = getListOfRecipes();
            Console.WriteLine("Welcome to Barry's Pie shop.");

            int option = 1;

            foreach (RecipeIngredientCalculator.Ingredient recipe in recipes){
                recipe.selectValue = option;
                option++;
                Console.WriteLine($"Enter {recipe.selectValue} to calculate {recipe.name}");
            }
            string typeofCalculation = Console.ReadLine();

            foreach (RecipeIngredientCalculator.Ingredient recipe in recipes){
                if (recipe.selectValue == (int)typeofCalculation){
                    return recipe.name;
                }
            }
        }

        public static List<RecipeIngredientCalculator.Ingredient> getListOfRecipes()
        {
            List<RecipeIngredientCalculator.Ingredient> recipes = new List<RecipeIngredientCalculator.Ingredient>();

            using (StreamReader r = new StreamReader("recipes/"))
            {
                 string json = r.ReadToEnd();
                 recipe = JsonConvert.DeserializeObject<List<RecipeIngredientCalculator.Ingredient>>(json);
            }
            return recipes;
        }

        private static void calculateAppliePies(){
            do
            {
                List<RecipeIngredientCalculator.Ingredient> ingredients = getCommonPieIngredients();

                Console.WriteLine("How many apples do you have?");
                int apples;
                if (!int.TryParse(Console.ReadLine(), out apples)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = apples, measurementUnit = "count", name = "apples"});

                Console.WriteLine("How many pounds of sugar do you have?");
                int sugar;
                if (!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = sugar, measurementUnit = "pounds", name = "sugar"});

                Console.WriteLine("How many pounds of flour do you have?");
                int flour;
                if (!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = flour, measurementUnit = "pounds", name = "flour"});

                List<RecipeIngredientCalculator.Ingredient> recipe = getRecipe("ApplePie");

                int amountOfPies = RecipeIngredientCalculator.CalculateMaxAmount(ingredients, recipe);
                Console.WriteLine("You can make: " + amountOfPies + " apple pies!");
                printLeftovers(RecipeIngredientCalculator.CalculateLeftovers(ingredients, recipe, amountOfPies));
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }

        private static void printLeftovers(List<RecipeIngredientCalculator.Ingredient> leftovers){
            foreach (RecipeIngredientCalculator.Ingredient leftover in leftovers){
                Console.WriteLine(leftover.quantity + " " + leftover.measurementUnit + " " + leftover.name + " left over.");
            }
        }

        private static void calculateBlueBerryPies(){
            do
            {
                List<RecipeIngredientCalculator.Ingredient> ingredients = getCommonPieIngredients();

                Console.WriteLine("How many cups of blueberries do you have?");
                int blueberries;
                if (!int.TryParse(Console.ReadLine(), out blueberries)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = blueberries, measurementUnit = "cups", name = "blueberries"});

                Console.WriteLine("How many zests of lemon do you have?");
                int lemonZest;
                if (!int.TryParse(Console.ReadLine(), out lemonZest)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = lemonZest, measurementUnit = "zests", name = "lemon"});

                Console.WriteLine("How much sugar do you have?");
                int sugar;
                if (!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = sugar, measurementUnit = "cups", name = "sugar"});

                Console.WriteLine("How many cups of milk do you have?");
                int milk;
                if (!int.TryParse(Console.ReadLine(), out milk)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = milk, measurementUnit = "cups", name = "milk"});

                Console.WriteLine("How many cups of flour do you have?");
                int flour;
                if (!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }
                ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = flour, measurementUnit = "cups", name = "flour"});

                List<RecipeIngredientCalculator.Ingredient> recipe = getRecipe("BlueberryPie");
                
                int amountOfPies = RecipeIngredientCalculator.CalculateMaxAmount(ingredients, recipe);
                Console.WriteLine("You can make: " + amountOfPies + " blueberry pies!");
                printLeftovers(RecipeIngredientCalculator.CalculateLeftovers(ingredients, recipe, amountOfPies));
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }

        private static void calculateEspresso(){
            do
            {
                List<RecipeIngredientCalculator.Ingredient> ingredients = getCommonCoffeeIngredients();

                List<RecipeIngredientCalculator.Ingredient> recipe = getRecipe("Espresso");
                
                int amountOfEspressos = RecipeIngredientCalculator.CalculateMaxAmount(ingredients, recipe);
                Console.WriteLine("You can make: " + amountOfEspressos + " Espressos!");
                printLeftovers(RecipeIngredientCalculator.CalculateLeftovers(ingredients, recipe, amountOfEspressos));
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }

        private static void calculatePourOvers(){
            do
            {
                List<RecipeIngredientCalculator.Ingredient> ingredients = getCommonCoffeeIngredients();

                List<RecipeIngredientCalculator.Ingredient> recipe = getRecipe("PourOver");
                
                int amountOfCoffees = RecipeIngredientCalculator.CalculateMaxAmount(ingredients, recipe);
                Console.WriteLine("You can make: " + amountOfCoffees + " Pour Over Coffees!");
                printLeftovers(RecipeIngredientCalculator.CalculateLeftovers(ingredients, recipe, amountOfCoffees));
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }

        public static List<RecipeIngredientCalculator.Ingredient> getCommonPieIngredients()
        {
            List<RecipeIngredientCalculator.Ingredient> ingrediants = new List<RecipeIngredientCalculator.Ingredient>();
            
            Console.WriteLine("How many teaspoons of cinnamon do you have?");
            int cinnamon;
            if (!int.TryParse(Console.ReadLine(), out cinnamon)){
                Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
            }
            ingrediants.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = cinnamon, measurementUnit = "teaspoons", name = "cinnamon"});

            Console.WriteLine("How many tablespoons of butter do you have?");
            int butter;
            if (!int.TryParse(Console.ReadLine(), out butter)){
                Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
            }
            ingrediants.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = butter, measurementUnit = "tablespoons", name = "butter"});

            return ingrediants;
        }

        public static List<RecipeIngredientCalculator.Ingredient> getCommonCoffeeIngredients()
        {
            List<RecipeIngredientCalculator.Ingredient> ingrediants = new List<RecipeIngredientCalculator.Ingredient>();
            
            Console.WriteLine("How many pounds of coffee do you have?");
            int coffee;
            if (!int.TryParse(Console.ReadLine(), out coffee)){
                Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
            }
            ingrediants.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = coffee*453, measurementUnit = "grams", name = "coffee"});

            return ingrediants;
        }

        public static List<RecipeIngredientCalculator.Ingredient> getRecipe(string recipeType)
        {
            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();

            using (StreamReader r = new StreamReader("recipes/"+ recipeType + ".json"))
            {
                 string json = r.ReadToEnd();
                 recipe = JsonConvert.DeserializeObject<List<RecipeIngredientCalculator.Ingredient>>(json);
            }
            return recipe;
        }
    }
    public class RecipeIngredientCalculator
    {
        public static int CalculateMaxAmount(List<Ingredient> ingredients, List<Ingredient> recipe)
        {
            List<int> findScarceIngredient = new List<int>();

            foreach(Ingredient ingrediant in ingredients){
                List<Ingredient> recipeIngredient = recipe.Where(p => p.name == ingrediant.name).ToList();
                findScarceIngredient.Add(ingrediant.quantity / recipeIngredient[0].quantity);
            }

            return findScarceIngredient.Min();
        }

        public static List<Ingredient> CalculateLeftovers(List<Ingredient> ingredients, List<Ingredient> recipe, int amountOfPies)
        {
            List<Ingredient> leftovers = new List<RecipeIngredientCalculator.Ingredient>();
            foreach (Ingredient ingrediant in ingredients){
                List<Ingredient> recipeIngredient = recipe.Where(p => p.name == ingrediant.name).ToList();
                leftovers.Add(new Ingredient(){ quantity = ingrediant.quantity - (amountOfPies * recipeIngredient[0].quantity), measurementUnit = ingrediant.measurementUnit, name = ingrediant.name});
            }
            return leftovers;
        }

        public class Ingredient{
            public int quantity;
            public string measurementUnit;
            public string name;
            public int selectValue;
        }
    }

    
}
