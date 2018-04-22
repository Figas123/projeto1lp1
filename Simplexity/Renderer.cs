using System;

namespace Simplexity
{
    public class Renderer
    {
        char result;

        /// <summary>
        /// Renders the game grid in the command prompt.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="shape"></param>
        public void Render(Board board, int shape)
         
        {
            char[,] symbols = new char[7, 7];
            for (int row = 0; row < 7; row++)
                for (int column = 0; column < 7; column++)
                    symbols[row, column] = SymbolFor(board.GetState(new Position(row, column)), shape);

            Console.WriteLine($" {symbols[0, 0]}   {symbols[0, 1]}   {symbols[0, 2]}   {symbols[0, 3]}   {symbols[0, 4]}   {symbols[0, 5]}   {symbols[0, 6]}");
            Console.WriteLine($" {symbols[1, 0]}   {symbols[1, 1]}   {symbols[1, 2]}   {symbols[1, 3]}   {symbols[1, 4]}   {symbols[1, 5]}   {symbols[1, 6]}");
            Console.WriteLine($" {symbols[2, 0]}   {symbols[2, 1]}   {symbols[2, 2]}   {symbols[2, 3]}   {symbols[2, 4]}   {symbols[2, 5]}   {symbols[2, 6]}");
            Console.WriteLine($" {symbols[3, 0]}   {symbols[3, 1]}   {symbols[3, 2]}   {symbols[3, 3]}   {symbols[3, 4]}   {symbols[3, 5]}   {symbols[3, 6]}");
            Console.WriteLine($" {symbols[4, 0]}   {symbols[4, 1]}   {symbols[4, 2]}   {symbols[4, 3]}   {symbols[4, 4]}   {symbols[4, 5]}   {symbols[4, 6]}");
            Console.WriteLine($" {symbols[5, 0]}   {symbols[5, 1]}   {symbols[5, 2]}   {symbols[5, 3]}   {symbols[5, 4]}   {symbols[5, 5]}   {symbols[5, 6]}");
            Console.WriteLine($" {symbols[6, 0]}   {symbols[6, 1]}   {symbols[6, 2]}   {symbols[6, 3]}   {symbols[6, 4]}   {symbols[6, 5]}   {symbols[6, 6]}");
            
            Console.WriteLine("  -----------------------");
        }
        /// <summary>
        /// Chooses the symbols to place on the grid according to the user's inputs.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        private char SymbolFor(State state, int shape)
        {
            // If the grid space is emprty
            if (state == State.Undecided )
            {
                result = '|';
            }
            // If the shape was placed by player 1
            if (state == State.player1 )
            {
                // If the shape is a square
                if (shape == (int)Shape.square )
                {
                    result = 'R';
                }
                // If the shape is a cylinder
                else
                {
                    result = 'r';
                }
            }
            // If the shape was placed by player 2
            if (state == State.player2)
            {
                // If the shape is a square
                if (shape == (int)Shape.square)
                {
                    result = 'W';
                }
                // If the shape is a cylinder
                else
                {
                    result = 'w';
                }
            }
            return result;
        }
        /// <summary>
        /// Settles the winner and displays it on the command prompt.
        /// </summary>
        /// <param name="winner"></param>
        public void RenderResults(State winner)
        {
            switch (winner)
            {
                // If the player 1 won
                case State.player1:
                    Console.WriteLine("Player 1 Wins!");
                    break;
                // If the player 2 won
                case State.player2:
                    Console.WriteLine("Player 2 Wins!");
                    break;
                // If it's a draw
                case State.Undecided:
                    Console.WriteLine("Draw!");
                    break;
            }
        }
    }

}