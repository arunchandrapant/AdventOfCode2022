namespace Day02
{
    internal class Program
    {
        static void Main()
        {
            const string inputPath = "./data/input";

            var input = File.ReadAllText(inputPath);

            var game = RockPaperScissors.GetGameFromInput(input);

            var gameScore = RockPaperScissors.GetGameScore(game);

            Console.WriteLine($"When played with your strategy, the score is {gameScore}.");

            var gameElfStrategy = RockPaperScissorsElfStrategy.GetGameFromInput(input);

            var gameScoreElfStrategy = RockPaperScissorsElfStrategy.GetGameScore(gameElfStrategy);

            Console.WriteLine($"When played with Elf's strategy, the score is {gameScoreElfStrategy}.");
        }
    }
}
