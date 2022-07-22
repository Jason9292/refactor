using System;
namespace Interview_Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar, 1 pound of flour, and 1 teaspoons of cinnamon to make 1 apple pie
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

                Console.WriteLine("How many teaspoons of cinnamon do you have?");
                int cinnamon;
                if (!int.TryParse(Console.ReadLine(), out cinnamon)){
                    Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                    continue;
                }

                generateApplePie.PieIngredients pieIngredients = generateApplePie.GeneratePieValues(apples, sugar, flour, cinnamon);
                Console.WriteLine("You can make: " + pieIngredients.maxCinnamonPies + " apple pies with cinnamon, and " + pieIngredients.maxRegularPies + " apple pies without!");
                Console.WriteLine(pieIngredients.leftOverApples + " apple(s) left over, " + pieIngredients.leftOverSugar + " lbs sugar left over, " + pieIngredients.leftOverFlour + " lbs flour left over, " + pieIngredients.leftOverCinnamon + " teaspoons cinnamon left over.");
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public static class generateApplePie
    {
        public static PieIngredients GeneratePieValues(int apples, int sugar, int flour, int cinnamon)
        {
            PieIngredients pieIngredients = new PieIngredients();

            pieIngredients.maxRegularPies = Math.Min(Math.Min((apples/3), (sugar/2)), flour);

            while (cinnamon > 0 && pieIngredients.maxRegularPies > 0){
                pieIngredients.maxCinnamonPies++;
                pieIngredients.maxRegularPies--;
                cinnamon--;
            }

            pieIngredients.totalPies = pieIngredients.maxCinnamonPies + pieIngredients.maxRegularPies;

            pieIngredients.leftOverCinnamon = cinnamon;
            pieIngredients.leftOverApples = apples - (pieIngredients.totalPies * 3);
            pieIngredients.leftOverSugar = sugar - (pieIngredients.totalPies * 2);
            pieIngredients.leftOverFlour = flour - pieIngredients.totalPies;

            return pieIngredients;
        }

        public class PieIngredients{
            public int maxRegularPies;
            public int maxCinnamonPies;
            public int totalPies;
            public int leftOverApples;
            public int leftOverSugar;
            public int leftOverFlour;
            public int leftOverCinnamon;
        }
    }

    
}
