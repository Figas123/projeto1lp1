namespace Simplexity
{
    public class WinChecker
    {
        public State Check(Board board)
        {
            // Checks if player 1 won
            if (CheckForWin(board, State.player1)) return State.player1;
            // Checks if player 2 won
            if (CheckForWin(board, State.player2)) return State.player2;
            return State.Undecided;
        }

        private bool CheckForWin(Board board, State player)
        {
            // Loops between all rows
            for (int row = 0; row < 4; row++)
            {
                // Loops between all columns
                for (int column = 0; column < 7; column++)
                {
                    // Checks if the shapes in the row are all equal
                    if (AreAll(board, new Position[] {
                        new Position(row, column),
                        new Position(row + 1, column),
                        new Position(row + 2, column),
                        new Position(row + 3, column) }, player))
                        return true;
                }
            }
            // Loops between all columns
            for (int column = 0; column < 4; column++)
            {
                // Loops between all rows
                for(int row = 0; row < 7; row++)
                {
                    // Checks if the shapes in the column are all equal
                    if (AreAll(board, new Position[] {
                        new Position(row, column),
                        new Position(row, column + 1),
                        new Position(row, column + 2),
                        new Position(row, column + 3) }, player))
                        return true;
                }
            }
            // Loops between all rows
            for (int row = 0; row < 4; row++)
            {
                // Loops between all columns
                for (int column = 0; column < 4; column++)
                {
                    // Checks if the shapes in the diagonal "/" are all equal
                    if (AreAll(board, new Position[] {
                            new Position (row, column),
                            new Position (row + 1, column + 1),
                            new Position (row + 2, column + 2),
                            new Position (row + 3, column + 3) }, player))
                        return true;
                    // Checks if the shapes in the diagonal "\" are all equal
                    if (AreAll(board, new Position[] {
                            new Position (row + 3, column),
                            new Position (row + 2, column + 1),
                            new Position (row + 1, column + 2),
                            new Position (row, column + 3) }, player))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compares if the positions are equal.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="positions"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private bool AreAll(Board board, Position[] positions, State state)
        {
            foreach (Position position in positions)
                // If the shapes aren't equal returns false
                if (board.GetState(position) != state) return false;

            return true;
        }
        /// <summary>
        /// Verifies if it´s a draw.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsDraw(Board board)
        {
            // Loops between all rows
            for (int row = 0; row < 7; row++)
                // Loops between all columns
                for (int column = 0; column < 7; column++)
                    // If the board is compleatly full returns false
                    if (board.GetState(new Position(row, column)) == State.Undecided) return false;

            return true;
        }
    }
}