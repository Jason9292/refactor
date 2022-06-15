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
                var apples = Console.ReadLine();
                Console.WriteLine("How much sugar do you have?");
                var sugar = Console.ReadLine();
                Console.WriteLine("How many pounds of flour do you have?");
                var poundsOfflour = Console.ReadLine();
                Console.WriteLine("You can make:");
                utility.Calc(apples, sugar, poundsOfflour);
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            } while (!string.Equals(Console.ReadLine().ToUpper(), "Q"));
        }
    }
    public static class utility
    {
        public static void Calc(string a, string b, string c)
        {
            try
            {
                var maxApples = (int.Parse(a) / 3);
                var x = int.Parse(b) / 2;
                var flourLeft =  int.Parse(c);
                var maxPies = Math.Min(Math.Min(maxApples, x), flourLeft);
                Console.WriteLine(maxPies + " apple pies!");

                var leftOverA = int.Parse(a) - (maxPies * 3);
                var leftOverB = int.Parse(b) - (maxPies * 2);
                var leftOverC = int.Parse(c) - maxPies;
                Console.WriteLine(leftOverA + " apple(s) left over, " + leftOverB + " lbs sugar left over, " + leftOverC + " lbs flour left over.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    
}
