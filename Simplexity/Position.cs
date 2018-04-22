namespace Simplexity
{
    public class Position
    {
        /// <summary>
        /// Gets a value of the Row.
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// Gets a value of the column.
        /// </summary>
        public int Column { get; }
       
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}