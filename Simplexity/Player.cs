using System;

namespace Simplexity
{
    public class Player
    {
        public Position GetPosition(Board board)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position, board);
            return desiredCoordinate;
        }

        private Position PositionForNumber(int position, Board board)
        {
            int j = position - 1;
            Position posreturn = new Position(0,0);

            for (int i = 0; i <= 6; i++)
            {
                Position pos = new Position(i, j);
                if (board.GetState(pos) == State.Undecided)
                {
                    posreturn = new Position(i, j);
                }
            }
            return posreturn;
        }
    }


}