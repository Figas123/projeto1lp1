namespace Simplexity
{
    public class WinChecker
    {
        public State Check(Board board)
        {
            if (CheckForWin(board, State.p1Square)) return State.p1Square;
            if (CheckForWin(board, State.p1Cylinder)) return State.p1Cylinder;
            if (CheckForWin(board, State.p2Square)) return State.p2Square;
            if (CheckForWin(board, State.p2Cylinder)) return State.p2Cylinder;
            return State.Undecided;
        }

        private bool CheckForWin(Board board, State player)
        {
            for (int row = 0; row < 7; row++)
                if (AreAll(board, new Position[] {
                        new Position(row, 0),
                        new Position(row, 1),
                        new Position(row, 2),
                        new Position(row, 3),
                        new Position(row, 4),
                        new Position(row, 5),
                        new Position(row, 6) }, player))
                    return true;

            for (int column = 0; column < 7; column++)
                if (AreAll(board, new Position[] {
                        new Position(0, column),
                        new Position(1, column),
                        new Position(2, column),
                        new Position(3, column),
                        new Position(4, column),
                        new Position(5, column),
                        new Position(6, column) }, player))
                    return true;
            for (int row = 0; row < 7; row++)
            {
                for (int column = 0; column < 7; column++)
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
