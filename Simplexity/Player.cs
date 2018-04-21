using System;

namespace Simplexity
{
    public class Player
    {
        /// <summary>
        /// Determines the coordinates in a scrupulous manner.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Position GetPosition(Board board)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position, board);
            return desiredCoordinate;
        }
        /// <summary>
        /// Searches for an empty space on the choosen column and sets it as the defined position for the piece.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="board"></param>
        /// <returns></returns>
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