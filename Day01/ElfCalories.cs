namespace Day01
{
    public class ElfCalories
    {

        public static long GetMaxCaloriesWithAnyElf(IEnumerable<IEnumerable<long>> elvesEatables)
        {
            var maxCalories = elvesEatables
                .Select(elfEatables =>
                    elfEatables.Sum())
                .Max();

            return maxCalories;
        }

        public static long GetTotalCaloriesWithTopThreeElves(IEnumerable<IEnumerable<long>> elvesEatables)
        {
            var total = elvesEatables
                .Select(elfEatables =>
                    elfEatables.Sum())
                .OrderByDescending(elfTotal => elfTotal)
                .Take(3)
                .Sum();

            return total;
        }

        public static IEnumerable<IEnumerable<long>> GetElvesEatablesFromInput(string inputPath)
        {
            var data = File.ReadAllText(inputPath);

            return data
                .Trim() // Remove trailing LF
                .Split("\n\n") // Separate items carried by different elves
                .Select(elfEatables =>
                    elfEatables
                    .Split("\n") // Separate each item carried by an elf
                    .Select(eatable =>
                        Convert.ToInt64(eatable)));
        }

        static void Main()
        {
            var inputPath = "./data/input";
            
            var elvesEatables = GetElvesEatablesFromInput(inputPath);

            var maxTotalCaloriesWithAnyElf = GetMaxCaloriesWithAnyElf(elvesEatables);

            var totalCaloriesWithTopThreeElves = GetTotalCaloriesWithTopThreeElves(elvesEatables);

            Console.WriteLine($"The maximum total calories with any Elf is {maxTotalCaloriesWithAnyElf}");
            Console.WriteLine($"The sum of calories with top 3 calorie containing Elves is {totalCaloriesWithTopThreeElves}");
        }
    }
}