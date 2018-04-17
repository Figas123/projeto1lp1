﻿using System;

namespace Simplexity
{
    public class Renderer
    {
        public void Render(Board board)
        {
            char[,] symbols = new char[7, 7];
            for (int row = 0; row < 7; row++)
                for (int column = 0; column < 7; column++)
                    symbols[row, column] = SymbolFor(board.GetState(new Position(row, column)));

            Console.WriteLine($" {symbols[0, 0]}   {symbols[0, 1]}   {symbols[0, 2]}   {symbols[0, 3]}   {symbols[0, 4]}   {symbols[0, 5]}   {symbols[0, 6]}");
            Console.WriteLine($" {symbols[1, 0]}   {symbols[1, 1]}   {symbols[1, 2]}   {symbols[1, 3]}   {symbols[1, 4]}   {symbols[1, 5]}   {symbols[1, 6]}");
            Console.WriteLine($" {symbols[2, 0]}   {symbols[2, 1]}   {symbols[2, 2]}   {symbols[2, 3]}   {symbols[2, 4]}   {symbols[2, 5]}   {symbols[2, 6]}");
            Console.WriteLine($" {symbols[3, 0]}   {symbols[3, 1]}   {symbols[3, 2]}   {symbols[3, 3]}   {symbols[3, 4]}   {symbols[3, 5]}   {symbols[3, 6]}");
            Console.WriteLine($" {symbols[4, 0]}   {symbols[4, 1]}   {symbols[4, 2]}   {symbols[4, 3]}   {symbols[4, 4]}   {symbols[4, 5]}   {symbols[4, 6]}");
            Console.WriteLine($" {symbols[5, 0]}   {symbols[5, 1]}   {symbols[5, 2]}   {symbols[5, 3]}   {symbols[5, 4]}   {symbols[5, 5]}   {symbols[5, 6]}");
            Console.WriteLine($" {symbols[6, 0]}   {symbols[6, 1]}   {symbols[6, 2]}   {symbols[6, 3]}   {symbols[6, 4]}   {symbols[6, 5]}   {symbols[6, 6]}");
            
            Console.WriteLine("-----------------------");
        }

        private char SymbolFor(State state)
        {
            switch (state)
            {
                case State.p1Square: return 'S';
                case State.p1Cylinder: return 'C';
                case State.p2Square: return 's';
                case State.p2Cylinder: return 'c';
                default: return '|';
            }
        }

        public void RenderResults(State winner)
        {
            switch (winner)
            {
                case State.p1:
                    Console.WriteLine("Player 1 Wins!");
                    break;
                case State.p2:
                    Console.WriteLine("Player 2 Wins!");
                    break;
                case State.Undecided:
                    Console.WriteLine("Draw!");
                    break;
            }
        }
    }

}