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

                Console.WriteLine("You can make:");
                generateApplePie.Calc(apples, sugar, flour);
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public static class generateApplePie
    {
        public static void Calc(int apples, int bananas, int flour)
        {
            try
            {
                var maxPies = Math.Min(Math.Min((apples/3), (bananas/2)), flour);
                Console.WriteLine(maxPies + " apple pies!");

                var leftOverApples = apples - (maxPies * 3);
                var leftOverBananas = bananas - (maxPies * 2);
                var leftOverFlour = flour - maxPies;
                Console.WriteLine(leftOverApples + " apple(s) left over, " + leftOverBananas + " lbs sugar left over, " + leftOverFlour + " lbs flour left over.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    
}
