namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "./data/input";

            var input = File.ReadAllText(inputFile);

            var rucksacks = Rucksack.GetRucksacksFromInput(input);

            var sumOfPriorities = Rucksack.GetSumOfPriorityScoresForRucksacks(rucksacks);

            Console.WriteLine($"The sum of priorities of the improperly placed item in each rucksack is {sumOfPriorities}");

            var badgePrioritySumForGroups = Rucksack.GetBadgePrioritySumForGroups(rucksacks);

            Console.WriteLine($"The sum of priorities of badge of each group is {badgePrioritySumForGroups}");
        }
    }
}