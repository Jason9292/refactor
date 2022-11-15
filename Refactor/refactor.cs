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
            Console.WriteLine("Welcome to Barry's Pie shop. Enter 'a' to calculate how many apple pies you can make, for blueberry pies enter 'b', for espresso enter 'e', for pour over coffee enter 'p'");
            string typeofCalculation = Console.ReadLine();

            if (typeofCalculation == "a"){
                calculateAppliePies();
            }
            else if (typeofCalculation == "b"){
                calculateBlueBerryPies();
            }
            else if (typeofCalculation == "e"){
                calculateEspresso();
            }
            else {
                calculatePourOvers();
            }
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

                List<RecipeIngredientCalculator.Ingredient> recipe = getApplePieRecipe();

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

                List<RecipeIngredientCalculator.Ingredient> recipe = getBlueberryPieRecipe();
                
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

                List<RecipeIngredientCalculator.Ingredient> recipe = getEspressoRecipe();
                
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

                List<RecipeIngredientCalculator.Ingredient> recipe = getPourOverRecipe();
                
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

        public static List<RecipeIngredientCalculator.Ingredient> getApplePieRecipe()
        {
            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 3, measurementUnit = "count", name = "apples"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 2, measurementUnit = "pounds", name = "sugar"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "pounds", name = "flour"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 6, measurementUnit = "tablespoons", name = "butter"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "teaspoons", name = "cinnamon"});

            return recipe;
        }

        public static List<RecipeIngredientCalculator.Ingredient> getBlueberryPieRecipe()
        {
            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 4, measurementUnit = "cups", name = "blueberries"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "zests", name = "lemon"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 5, measurementUnit = "tablespoons", name = "butter"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "cups", name = "flour"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "cups", name = "sugar"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "cups", name = "milk"});
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "teaspoons", name = "cinnamon"});

            return recipe;
        }

        public static List<RecipeIngredientCalculator.Ingredient> getEspressoRecipe()
        {
            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 8, measurementUnit = "grams", name = "coffee"});

            return recipe;
        }

        public static List<RecipeIngredientCalculator.Ingredient> getPourOverRecipe()
        {
            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 22, measurementUnit = "grams", name = "coffee"});

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
        }
    }

    
}
