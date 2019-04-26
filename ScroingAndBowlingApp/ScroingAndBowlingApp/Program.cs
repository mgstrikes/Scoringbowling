using System;

namespace ScroingAndBowlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bowling Game !");
            Console.WriteLine("Please enter your pin scores space seperated");
            var line = Console.ReadLine();
            string[] tokens = line.Split();
            int[] pins = Array.ConvertAll(tokens, int.Parse);

            var game = new Game();
            foreach(var pin in pins)
            {
                game.Roll(pin);
            }

            var finalScore = game.Score();

            Console.WriteLine($"Congratulations !! Your final score is {finalScore}");
            Console.ReadLine();
        }
    }
}
