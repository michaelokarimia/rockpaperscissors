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
            var playerOneMove = p1.GetPlayerMove();

            var playerTwoMove = p2.GetPlayerMove();

            // same moves will always result in a draw
            if (playerOneMove == playerTwoMove)
                return Result.Draw;

            //rock beats scissors, p1 wins
            if (playerOneMove == Move.Rock && playerTwoMove == Move.Scissors)
                return Result.PlayerOneWins;

            //rock loses against paper
            if (playerOneMove == Move.Rock && playerTwoMove == Move.Paper)
                return Result.PlayerTwoWins;

            //scissors beats paper
            if (playerOneMove == Move.Scissors && playerTwoMove == Move.Paper)
                return Result.PlayerOneWins;

            //scissor lose agaist rock
            if (playerOneMove == Move.Scissors && playerTwoMove == Move.Rock)
                return Result.PlayerTwoWins;

            //paper loses against Scissors
            if (playerOneMove == Move.Paper && playerTwoMove == Move.Scissors)
                return Result.PlayerTwoWins;

            //paper beats rock
            if (playerOneMove == Move.Paper && playerTwoMove == Move.Rock)
                return Result.PlayerOneWins;

            return Result.Draw;
        }
    }
}