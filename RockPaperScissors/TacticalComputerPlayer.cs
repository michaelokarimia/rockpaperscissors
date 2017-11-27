using System;

namespace RockPaperScissors
{
    public class TacticalComputerPlayer : IPlayer
    {
        Random rand;
        private Move lastMove;
        bool hasMadeFirstMove;

        public Move LastMove { get { return lastMove; } }

        public TacticalComputerPlayer()
        {
            rand = new Random();
            hasMadeFirstMove = false;
        }

        public Move GetPlayerMove()
        {
            if(hasMadeFirstMove)
            {
                //tactical move, select whatever would have defeated the last move
                switch (lastMove)
                {
                    case Move.Rock:
                        lastMove = Move.Paper;
                        break;
                    case Move.Paper:
                        lastMove = Move.Scissors;
                        break;
                    case Move.Scissors:
                        lastMove = Move.Rock;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Only valid moves are Rock, Paper, Scissors");
                }
            }
            else
            {
                //it's the first move, so make it a random choice
                int choice = rand.Next(1, 4);

                lastMove = (Move)choice;

                hasMadeFirstMove = true;

                
            }

            return lastMove;
        }

        public void Play(Move move)
        {
            lastMove = move;

            hasMadeFirstMove = true;
        }
    }
}