namespace Day04
{
    public class Program
    {
        static void Main()
        {
            var inputFile = "./data/input";

            var input = File.ReadAllText(inputFile);

            var assignmentPairs = CampCleanup.GetSectionAssignmentPairsFromInput(input);

            var fullyContainingAssignmentPairs = CampCleanup.GetCountOfFullyContainingAssignmentPairs(assignmentPairs);

            Console.WriteLine($"There are {fullyContainingAssignmentPairs} assignment pairs that are fully containing.");

            var overlappingAssignmentcount = CampCleanup.GetCountOfOverlappingAssignmentPairs(assignmentPairs);

            Console.WriteLine($"There are {overlappingAssignmentcount} pairs of overlapping assignment.");
        }
    }
}