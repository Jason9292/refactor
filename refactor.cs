using System;
namespace Interview_Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core
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

                generateApplePie.PieIngredients pieIngredients = generateApplePie.GeneratePieValues(apples, sugar, flour);
                Console.WriteLine("You can make: " + pieIngredients.maxPies + " apple pies!");
                Console.WriteLine(pieIngredients.leftOverApples + " apple(s) left over, " + pieIngredients.leftOverBananas + " lbs sugar left over, " + pieIngredients.leftOverFlour + " lbs flour left over.");
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public static class generateApplePie
    {
        public static PieIngredients GeneratePieValues(int apples, int bananas, int flour)
        {
            PieIngredients pieIngredients = new PieIngredients();

            pieIngredients.maxPies = Math.Min(Math.Min((apples/3), (bananas/2)), flour);
            pieIngredients.leftOverApples = apples - (pieIngredients.maxPies * 3);
            pieIngredients.leftOverBananas = bananas - (pieIngredients.maxPies * 2);
            pieIngredients.leftOverFlour = flour - pieIngredients.maxPies;

            return pieIngredients;
        }

        public class PieIngredients{
            public int maxPies;
            public int leftOverApples;
            public int leftOverBananas;
            public int leftOverFlour;
        }
    }

    
}
