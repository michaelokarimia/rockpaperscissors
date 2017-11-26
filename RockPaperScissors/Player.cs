using System;

namespace Tests
{
    public class Player
    {
        public Move LastMove { get; private set; }

        public Player Play(Move move)
        {
            LastMove = move;
            return this;
        }

        
    }
}