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
                var apples = utility.ConvertNumberToInt(Console.ReadLine());
                if (apples == 0){
                    continue;
                }

                Console.WriteLine("How much sugar do you have?");
                var sugar = utility.ConvertNumberToInt(Console.ReadLine());
                if (sugar == 0){
                    continue;
                }

                Console.WriteLine("How many pounds of flour do you have?");
                var poundsOfflour = utility.ConvertNumberToInt(Console.ReadLine());
                if (poundsOfflour == 0){
                    continue;
                }

                Console.WriteLine("You can make:");
                utility.Calc(apples, sugar, poundsOfflour);
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public static class utility
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

        public static int ConvertNumberToInt(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine($"Please enter value in numerical format. Press enter to start over, 'q' to quit!");
                return 0;
            }
        }
    }

    
}
