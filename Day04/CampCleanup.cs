namespace Day04
{
    public static class CampCleanup
    {
        /// <summary>
        /// Parse input data and construct an enumerable of assignment pairs for further processing.
        /// </summary>
        /// <param name="input">String containing all section assignment pairs separated by new line.</param>
        /// <returns>An enumerable of assignment pair object.</returns>
        public static IEnumerable<AssignmentPair> GetSectionAssignmentPairsFromInput(string input)
        {
            return input
                .Trim()
                .Split('\n')
                .Select(assignmentPair =>
                    assignmentPair
                    .Split(',')
                    .Select(assignment =>
                        assignment
                        .Split('-')
                        .Select(section => Convert.ToInt32(section)))
                    .Select(assignment =>
                        new Assignment 
                        { 
                            Start = assignment.First(),
                            End = assignment.Last()
                        }))
                .Select(assignmentPair =>
                    new AssignmentPair
                    {
                        FirstElf = assignmentPair.First(),
                        SecondElf = assignmentPair.Last()
                    });
        }

        /// <summary>
        /// Get the count of fully containing assignment pairs.
        /// </summary>
        /// <param name="assignmentPairs">Enumerable of assignment pairs.</param>
        /// <returns>Count of fully containing assignment pairs.</returns>
        public static int GetCountOfFullyContainingAssignmentPairs(IEnumerable<AssignmentPair> assignmentPairs)
        {
            return assignmentPairs
                .Select(assignmentPair =>
                    IsAssignmentPairFullyContaining(assignmentPair))
                .Where(isOverlapping =>
                    isOverlapping == true)
                .Count();
        }

        /// <summary>
        /// Get count of overlapping assignment pairs.
        /// </summary>
        /// <param name="assignmentPairs">Enumerable of assignment pairs.</param>
        /// <returns>Count of overlapping assignment pairs.</returns>
        public static int GetCountOfOverlappingAssignmentPairs(IEnumerable<AssignmentPair> assignmentPairs)
        {
            return assignmentPairs
                .Select(assignmentPair =>
                    IsAssignmentPairOverlapping(assignmentPair))
                .Where(isOverlapping =>
                    isOverlapping == true)
                .Count();
        }

        /// <summary>
        /// Check whether an assignment pair is fully containing.
        /// </summary>
        /// <param name="assignmentPair">An assignment pair.</param>
        /// <returns>True if fully containing assignment pair. Else false.</returns>
        public static bool IsAssignmentPairFullyContaining(this AssignmentPair assignmentPair)
        {
            return
                (assignmentPair.FirstElf.Start <= assignmentPair.SecondElf.Start
                    && assignmentPair.FirstElf.End >= assignmentPair.SecondElf.End)
                ||
                (assignmentPair.FirstElf.Start >= assignmentPair.SecondElf.Start
                    && assignmentPair.FirstElf.End <= assignmentPair.SecondElf.End);
        }

        /// <summary>
        /// Check whether an assignment pair overlaps.
        /// </summary>
        /// <param name="assignment">An assignment pair.</param>
        /// <returns>True if overlapping assignment pair. Else false.</returns>
        public static bool IsAssignmentPairOverlapping(this AssignmentPair assignment)
        {
            return
                (assignment.FirstElf.Start < assignment.SecondElf.Start
                    && assignment.FirstElf.End >= assignment.SecondElf.Start)
                ||
                (assignment.FirstElf.Start >= assignment.SecondElf.Start
                    && assignment.FirstElf.Start <= assignment.SecondElf.End);
        }
    }
}
