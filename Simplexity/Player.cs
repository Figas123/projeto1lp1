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
            // Receives the value typed by the player and converts it into an int
            int position = Convert.ToInt32(Console.ReadLine());
            // Creates a variable to store the correct coordinates
            Position desiredCoordinate = PositionForNumber(position, board);
            // returns the correct coordinates
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
            // Loops between the grid spaces in the "j" column
            for (int i = 0; i <= 6; i++)
            {
                // Creates a position acoording to "i" and "j"
                Position pos = new Position(i, j);
                // If the grid space is empty returns the coordinate
                if (board.GetState(pos) == State.Undecided)
                {
                    posreturn = new Position(i, j);
                }
            }
            // Returns the coordinate
            return posreturn;
        }
    }


}