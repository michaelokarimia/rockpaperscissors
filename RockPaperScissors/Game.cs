namespace RockPaperScissors
{
    public class Game
    {
        private IPlayer p1;
        private IPlayer p2;

        public Game(IPlayer p1, IPlayer p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Result Play()
        {
            // same moves will always result in a draw
            if (p1.LastMove() == p2.LastMove())
                return Result.Draw;

            //rock beats scissors, p1 wins
            if (p1.LastMove() == Move.Rock && p2.LastMove() == Move.Scissors)
                return Result.PlayerOneWins;

            //rock loses against paper
            if (p1.LastMove() == Move.Rock && p2.LastMove() == Move.Paper)
                return Result.PlayerTwoWins;

            //scissors beats paper
            if (p1.LastMove() == Move.Scissors && p2.LastMove() == Move.Paper)
                return Result.PlayerOneWins;

            //scissor lose agaist rock
            if (p1.LastMove() == Move.Scissors && p2.LastMove() == Move.Rock)
                return Result.PlayerTwoWins;

            //paper loses against Scissors
            if (p1.LastMove() == Move.Paper && p2.LastMove() == Move.Scissors)
                return Result.PlayerTwoWins;

            //paper beats rock
            if (p1.LastMove() == Move.Paper && p2.LastMove() == Move.Rock)
                return Result.PlayerOneWins;

            return Result.Draw;
        }
    }
}