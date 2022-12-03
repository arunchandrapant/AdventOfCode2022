namespace Day02
{
    public class RockPaperScissorsElfStrategy
    {
        private static Move GetMoveFromMoveCode(char moveCode) => moveCode switch
        {
            'A' => Move.Rock,
            'B' => Move.Paper,
            'C' => Move.Scissor,
            _   => throw new InvalidDataException("Provided move code is not valid.")
        };

        private static Outcome GetOutcomeFromOutcomeCode(char outcomeCode) => outcomeCode switch
        {
            'X' => Outcome.Loose,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Win,
            _   => throw new InvalidDataException("Provided outcome code is not valid.")
        };


        private static RoundElfStrategy GetRoundFromRoundCodes(string roundCodes)
        {
            var moveCodes = roundCodes.Split(' ');
            var opponentMoveCode = Convert.ToChar(moveCodes.First());
            var outcomeCode = Convert.ToChar(moveCodes.Last());

            return new RoundElfStrategy
            {
                OpponentMove = GetMoveFromMoveCode(opponentMoveCode),
                Outcome = GetOutcomeFromOutcomeCode(outcomeCode)
            };
        }

        public static IEnumerable<RoundElfStrategy> GetGameFromInput(string input)
        {
            return input
                .Trim()
                .Split('\n')
                .Select(roundCodes => GetRoundFromRoundCodes(roundCodes));
        }

        private static int GetRoundScore(RoundElfStrategy round)
        {
            var myMove = round.Outcome switch
            {
                Outcome.Draw  => (int)round.OpponentMove,
                Outcome.Win   => ((int)round.OpponentMove % 3) + 1,
                Outcome.Loose => ((int)round.OpponentMove - 1) == 0 ? 3 : ((int)round.OpponentMove - 1),
                _ => throw new InvalidDataException("Invalid data for moves.")
            } ;

            return myMove + (int)round.Outcome;
        }

        public static int GetGameScore(IEnumerable<RoundElfStrategy> game)
        {
            return game
                .Select(round => GetRoundScore(round))
                .Sum();
        }
    }
}