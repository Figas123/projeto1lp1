namespace Simplexity
{
    public class WinChecker
    {
        public State Check(Board board)
        {
            if (CheckForWin(board, State.player1)) return State.player1;
            if (CheckForWin(board, State.player2)) return State.player2;
            return State.Undecided;
        }

        private bool CheckForWin(Board board, State player)
        {
            // CHECK ROWS <------
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 7; column++)
                {

                    if (AreAll(board, new Position[] {
                        new Position(row, column),
                        new Position(row + 1, column),
                        new Position(row + 2, column),
                        new Position(row + 3, column) }, player))
                        return true;
                }
            }
            // CHECK COLUMNS <------
            for (int column = 0; column < 4; column++)
            {
                for(int row = 0; row < 7; row++)
                {
                    if (AreAll(board, new Position[] {
                        new Position(row, column),
                        new Position(row, column + 1),
                        new Position(row, column + 2),
                        new Position(row, column + 3) }, player))
                        return true;
                }
            }
            // CHECK DIAGONALS <-----
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    if (AreAll(board, new Position[] {
                            new Position (row, column),
                            new Position (row + 1, column + 1),
                            new Position (row + 2, column + 2),
                            new Position (row + 3, column + 3) }, player))
                        return true;
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

        private bool AreAll(Board board, Position[] positions, State state)
        {
            foreach (Position position in positions)
                if (board.GetState(position) != state) return false;

            return true;
        }
        
        public bool IsDraw(Board board)
        {
            for (int row = 0; row < 7; row++)
                for (int column = 0; column < 7; column++)
                    if (board.GetState(new Position(row, column)) == State.Undecided) return false;

            return true;
        }
    }
}