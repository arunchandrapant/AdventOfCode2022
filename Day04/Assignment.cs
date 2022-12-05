
namespace Day04
{
    /// <summary>
    /// Represents the sections assigned to an Elf for cleaning.
    /// The sections to be cleaned lie between 'Start' and 'End'.
    /// </summary>
    public class Assignment
    {
        public int Start { get; set; }

        public int End { get; set; }
    }
   
    /// <summary>
    /// Represents a pair of assignment, formed for the purpose of reconciliation.
    /// </summary>
    public class AssignmentPair
    {
        public Assignment FirstElf { get; set; } = new Assignment();

        public Assignment SecondElf { get; set; } = new Assignment();
    }
}
