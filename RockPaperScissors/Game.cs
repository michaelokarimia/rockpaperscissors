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

        public GameResult Play()
        {
            var playerOneMove = p1.GetPlayerMove();

            var playerTwoMove = p2.GetPlayerMove();

            // same moves will always result in a draw
            if (playerOneMove == playerTwoMove)
                return GameResult.Draw;

            //rock beats scissors, p1 wins
            if (playerOneMove == Move.Rock && playerTwoMove == Move.Scissors)
                return GameResult.PlayerOneWins;

            //rock loses against paper
            if (playerOneMove == Move.Rock && playerTwoMove == Move.Paper)
                return GameResult.PlayerTwoWins;

            //scissors beats paper
            if (playerOneMove == Move.Scissors && playerTwoMove == Move.Paper)
                return GameResult.PlayerOneWins;

            //scissor lose agaist rock
            if (playerOneMove == Move.Scissors && playerTwoMove == Move.Rock)
                return GameResult.PlayerTwoWins;

            //paper loses against Scissors
            if (playerOneMove == Move.Paper && playerTwoMove == Move.Scissors)
                return GameResult.PlayerTwoWins;

            //paper beats rock
            if (playerOneMove == Move.Paper && playerTwoMove == Move.Rock)
                return GameResult.PlayerOneWins;

            return GameResult.Draw;
        }
    }
}