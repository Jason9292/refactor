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

                ApplePieGenerator.PieValues pieValues = ApplePieGenerator.GeneratePieValues(apples, sugar, flour, cinnamon);
                Console.WriteLine("You can make: " + pieValues.maxCinnamonPies + " apple pies with cinnamon, and " + pieValues.maxRegularPies + " apple pies without!");
                Console.WriteLine(pieValues.leftOverApples + " apple(s) left over, " + pieValues.leftOverSugar + " lbs sugar left over, " + pieValues.leftOverFlour + " lbs flour left over, " + pieValues.leftOverCinnamon + " teaspoons cinnamon left over.");
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public class ApplePieGenerator
    {
        public static PieValues GeneratePieValues(int apples, int sugar, int flour, int cinnamon)
        {
            PieValues pieValues = new PieValues();

            pieValues.maxRegularPies = Math.Min(Math.Min((apples/3), (sugar/2)), flour);

            while (cinnamon > 0 && pieValues.maxRegularPies > 0){
                pieValues.maxCinnamonPies++;
                pieValues.maxRegularPies--;
                cinnamon--;
            }

            pieValues.totalPies = pieValues.maxCinnamonPies + pieValues.maxRegularPies;

            pieValues.leftOverCinnamon = cinnamon;
            pieValues.leftOverApples = apples - (pieValues.totalPies * 3);
            pieValues.leftOverSugar = sugar - (pieValues.totalPies * 2);
            pieValues.leftOverFlour = flour - pieValues.totalPies;

            return pieValues;
        }

        public class PieValues{
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
