namespace Day02
{
    public class RockPaperScissors
    {
        private static Move GetMoveFromMoveCode(char moveCode) => moveCode switch
        {
            'X' => Move.Rock,
            'Y' => Move.Paper,
            'Z' => Move.Scissor,
            'A' => Move.Rock,
            'B' => Move.Paper,
            'C' => Move.Scissor,
            _ => throw new InvalidDataException("Provided move code is not valid.")
        };

        private static Round GetRoundFromRoundCodes(string roundCodes)
        {
            var moveCodes = roundCodes.Split(' ');
            var opponentMoveCode = Convert.ToChar(moveCodes.First());
            var yourMoveCode = Convert.ToChar(moveCodes.Last());

            return new Round
            {
                Opponent = GetMoveFromMoveCode(opponentMoveCode),
                You = GetMoveFromMoveCode(yourMoveCode)
            };
        }

        public static IEnumerable<Round> GetGameFromInput(string input)
        {
            return input 
                .Trim()
                .Split('\n')
                .Select(round => GetRoundFromRoundCodes(round));
        }

        private static int GetRoundScore(Round round)
        {
            var moveDiff = round.You - round.Opponent;

            var result = moveDiff switch
            {
                0  => Outcome.Draw,
                1  => Outcome.Win,
                -2 => Outcome.Win,
                -1 => Outcome.Loose,
                2  => Outcome.Loose,
                _  => throw new InvalidDataException("Invalid data for moves.")
            };

            return (int)result + (int)round.You;
        }

        public static int GetGameScore(IEnumerable<Round> game)
        {
            return game
                .Select(round => GetRoundScore(round))
                .Sum();
        }


    }
}