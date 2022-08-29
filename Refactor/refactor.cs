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
                Console.WriteLine("How many apples do you have?");
                int apples;
                if (!int.TryParse(Console.ReadLine(), out apples)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How much sugar do you have?");
                int sugar;
                if (!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many pounds of flour do you have?");
                int flour;
                if (!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many teaspoons of cinnamon do you have?");
                int cinnamon;
                if (!int.TryParse(Console.ReadLine(), out cinnamon)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many sticks of butter do you have?");
                int sticksOfButter;
                if (!int.TryParse(Console.ReadLine(), out sticksOfButter)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                PieGenerator.PieValues pieValues = PieGenerator.GenerateApplePieValues(apples, sugar, flour, cinnamon, sticksOfButter * 8);
                Console.WriteLine("You can make: " + pieValues.maxCinnamonPies + " apple pies with cinnamon, and " + pieValues.maxRegularPies + " apple pies without!");
                Console.WriteLine(pieValues.leftOverApples + " apple(s) left over, " + pieValues.leftOverSugar + " lbs sugar left over, " + pieValues.leftOverFlour + " lbs flour left over, " + pieValues.leftOverCinnamon + " teaspoons cinnamon left over, " + pieValues.leftOverButter + " tablespoons butter left over.");
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }

        private static void calculateBlueBerryPies(){
            do
            {
                Console.WriteLine("How many cups of blueberries do you have?");
                int blueberries;
                if (!int.TryParse(Console.ReadLine(), out blueberries)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many zests of lemon do you have?");
                int lemonZest;
                if (!int.TryParse(Console.ReadLine(), out lemonZest)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How much sugar do you have?");
                int sugar;
                if (!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many cups of milk do you have?");
                int milk;
                if (!int.TryParse(Console.ReadLine(), out milk)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many pounds of flour do you have?");
                int flour;
                if (!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many teaspoons of cinnamon do you have?");
                int cinnamon;
                if (!int.TryParse(Console.ReadLine(), out cinnamon)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                Console.WriteLine("How many sticks of butter do you have?");
                int sticksOfButter;
                if (!int.TryParse(Console.ReadLine(), out sticksOfButter)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                PieGenerator.PieValues pieValues = PieGenerator.GenerateBlueBerryPieValues(blueberries, lemonZest, milk, sugar, flour, cinnamon, sticksOfButter * 8);
                Console.WriteLine("You can make: " + pieValues.maxRegularPies + " Blueberry pies!");
                Console.WriteLine(pieValues.leftOverBlueberries + " blueberrys left over, " + pieValues.leftOverLemonZest + " lemon zest left over, " + pieValues.leftOverMilk + " milk left over, " + pieValues.leftOverSugar + " lbs sugar left over, " + pieValues.leftOverFlour + " lbs flour left over, " + pieValues.leftOverCinnamon + " teaspoons cinnamon left over, " + pieValues.leftOverButter + " tablespoons butter left over.");
                Console.WriteLine("\n\nEnter to re-calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public class PieGenerator
    {
        public static PieValues GenerateApplePieValues(int apples, int sugar, int flour, int cinnamon, int tbspButter)
        {
            PieValues pieValues = new PieValues();

            pieValues.maxRegularPies = Math.Min(Math.Min((apples/3), (sugar/2)), Math.Min(flour, tbspButter/6));

            while (cinnamon > 0 && pieValues.maxRegularPies > 0){
                pieValues.maxCinnamonPies++;
                pieValues.maxRegularPies--;
                cinnamon--;
            }

            int totalPies = pieValues.maxCinnamonPies + pieValues.maxRegularPies;

            pieValues.leftOverCinnamon = cinnamon;
            pieValues.leftOverApples = apples - (totalPies * 3);
            pieValues.leftOverSugar = sugar - (totalPies * 2);
            pieValues.leftOverFlour = flour - totalPies;
            pieValues.leftOverButter = tbspButter - (totalPies * 6);

            return pieValues;
        }

        public static PieValues GenerateBlueBerryPieValues(int blueberries, int lemonZest, int milk, int sugar, int flour, int cinnamon, int tbspButter)
        {
            PieValues pieValues = new PieValues();

            List<int> findScarceIngredient = new List<int>() {blueberries/4, lemonZest, milk, sugar, flour, cinnamon, tbspButter/5};

            pieValues.maxRegularPies = findScarceIngredient.Min();

            pieValues.leftOverBlueberries = blueberries - (pieValues.maxRegularPies * 4);
            pieValues.leftOverLemonZest = lemonZest - pieValues.maxRegularPies;
            pieValues.leftOverMilk = milk - pieValues.maxRegularPies;
            pieValues.leftOverSugar = sugar - pieValues.maxRegularPies;
            pieValues.leftOverFlour = flour - pieValues.maxRegularPies;
            pieValues.leftOverCinnamon = cinnamon - pieValues.maxRegularPies;
            pieValues.leftOverButter = tbspButter - (pieValues.maxRegularPies * 5);

            return pieValues;
        }

        public class PieValues{
            public int maxRegularPies;
            public int maxCinnamonPies;
            public int leftOverApples;
            public int leftOverBlueberries;
            public int leftOverLemonZest;
            public int leftOverSugar;
            public int leftOverFlour;
            public int leftOverCinnamon;
            public int leftOverButter;
            public int leftOverMilk;
        }
    }

    
}
