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
        public static void Calc(int a, int b, int c)
        {
            try
            {
                var maxApples = a / 3;
                var x = b / 2;
                var flourLeft =  c;
                var maxPies = Math.Min(Math.Min(maxApples, x), flourLeft);
                Console.WriteLine(maxPies + " apple pies!");

                var leftOverA = a - (maxPies * 3);
                var leftOverB = b - (maxPies * 2);
                var leftOverC = c - maxPies;
                Console.WriteLine(leftOverA + " apple(s) left over, " + leftOverB + " lbs sugar left over, " + leftOverC + " lbs flour left over.");
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
                Console.WriteLine($"Please enter value in numerical format. Press enter to calculate, 'q' to quit!");
                return 0;
            }
        }
    }

    
}
