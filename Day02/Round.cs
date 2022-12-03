namespace Day02
{
    public enum Move 
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3
    }

    public enum Outcome
    {
        Win = 6,
        Draw = 3,
        Loose = 0
    }

    public class Round
    {
        public Move Opponent;

        public Move You;
    }
}
