using System.Reflection;
using static MoreLinq.Extensions.BatchExtension;


namespace Day03
{
    public static class Rucksack
    {
        /// <summary>
        /// Gets rucksacks from the input data.
        /// </summary>
        /// <param name="input">Data of rucksacks in form of a string.</param>
        /// <returns>An enumerable of rucksacks, where each rucksack is represented as a string.</returns>
        public static IEnumerable<IEnumerable<char>> GetRucksacksFromInput(string input)
        {
            return input
                .Trim()
                .Split('\n');
        }

        /// <summary>
        /// Given a rucksack, return the item that is common in both the compartments of rucksack.
        /// </summary>
        /// <param name="rucksack">Rucksack in the form of string.</param>
        /// <returns>Common element in both compartments of rucksack as Char.</returns>
        public static char GetCommonItemInRucksackCompartments(this IEnumerable<char> rucksack)
        {
            var itemCount = rucksack.Count();

            var firstCompartment = rucksack
                .Take(itemCount / 2)
                .ToHashSet();

            var secondCompartment = rucksack
                .TakeLast(itemCount / 2)
                .ToHashSet();
            
            return firstCompartment
                .Intersect(secondCompartment)
                .First();
        }

        /// <summary>
        /// For an item in a rucksack, calculate it's priority score
        /// a-z have a score from 1 to 26
        /// A-Z have a score from 27 to 52
        /// </summary>
        /// <param name="item">Rucksack item represented as a char</param>
        /// <returns>Priority score of a rucksack item as an int.</returns>
        public static int GetItemPriorityScore(this char item)
        {
            if ((int)item <= (int)'Z')
            {
                return (int)item - (int)'A' + 27;
            }
            else
            {
                return (int)item - (int)'a' + 1;
            }
        }

        /// <summary>
        /// For a group of Elves, find the item representing badge of the group.
        /// </summary>
        /// <param name="groupRucksacks">Rucksack belonging to each member of the group.</param>
        /// <returns>The item representing badge of the group.</returns>
        public static char GetBadgeItemOfAGroup(this IEnumerable<IEnumerable<char>> groupRucksacks)
        {
            return groupRucksacks
                .Select(rucksack =>
                    rucksack.ToHashSet())
                .Aggregate((accumulator, next) => 
                    { 
                        accumulator.IntersectWith(next); 
                        return accumulator; 
                    })
                .First();
        }

        /// <summary>
        /// Get sum of prioprities for badge of each group of Elves.
        /// </summary>
        /// <param name="rucksacks">Rucksacks for each Elf.</param>
        /// <returns>Sum of priorities for badge each group of Elves.</returns>
        public static int GetBadgePrioritySumForGroups(IEnumerable<IEnumerable<char>> rucksacks)
        {
            return rucksacks
                .Batch(3)
                .Select(group =>
                    group
                    .GetBadgeItemOfAGroup()
                    .GetItemPriorityScore())
                .Sum();
        }

        /// <summary>
        /// Get sum of priority score for item not correctly placed in each rucksack.
        /// </summary>
        /// <param name="rucksacks"></param>
        /// <returns></returns>
        public static int GetSumOfPriorityScoresForRucksacks(IEnumerable<IEnumerable<char>> rucksacks)
        {
            return rucksacks
                .Select(rucksack =>
                    rucksack
                    .GetCommonItemInRucksackCompartments()
                    .GetItemPriorityScore())
                .Sum();
        }
    }
}
