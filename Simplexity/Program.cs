using System;

namespace Simplexity
{
    public class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            WinChecker winChecker = new WinChecker();
            Renderer renderer = new Renderer();
            Player player1 = new Player();
            Player player2 = new Player();
            
            bool shapeChoosen, columnChoosen;
            int shape, column;

            while (!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided)
            {
                renderer.Render(board);

                Position nextMove;
                // PLAYER 1 <----------------------------------
                if (board.NextTurn == State.p1)
                {
                    Console.WriteLine("Your turn, player 1");

                    shapeChoosen = false;
                    // CHOOSE SHAPE   <------
                    while (shapeChoosen != true)
                    {
                        Console.WriteLine("What shape do you want to play? (S / C)");
                        ConsoleKeyInfo choice = Console.ReadKey();
                        // SQUARE
                        if (choice.KeyChar == 'S' || choice.KeyChar == 's')
                        {
                            Console.WriteLine("\nYou choose Square.");
                            shape = 1;
                            shapeChoosen = true;
                            break;
                        }
                        // CYLINDER
                        else if (choice.KeyChar == 'C' || choice.KeyChar == 'c')
                        {
                            Console.WriteLine("\nYou choose Cylinder.");
                            shape = 2;
                            shapeChoosen = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease choose a valid answer.");
                            continue;
                        }
                    }
                    columnChoosen = false;
                    // CHOOSE COLUMN   <-----
                    while (columnChoosen != true)
                    {
                        Console.WriteLine("On which column do you want to place your shape? (1 - 7)");

                        nextMove = player1.GetPosition(board);

                        columnChoosen = true;

                        if (!board.SetState(nextMove, board.NextTurn))
                        {
                            Console.WriteLine("That is not a legal move.");
                            columnChoosen = false;
                        }
                    }
                }
                // PLAYER 2 <--------------------------------
                else
                {
                    Console.WriteLine("Your turn, player 2");

                    shapeChoosen = false;
                    // CHOOSE SHAPE   <------
                    while (shapeChoosen != true)
                    {
                        Console.WriteLine("What shape do you want to play? (S / C)");
                        ConsoleKeyInfo choice = Console.ReadKey();
                        // SQUARE
                        if (choice.KeyChar == 'S' || choice.KeyChar == 's')
                        {
                            Console.WriteLine("\nYou choose Square.");
                            shape = 1;
                            shapeChoosen = true;
                            break;
                        }
                        // CYLINDER
                        else if (choice.KeyChar == 'C' || choice.KeyChar == 'c')
                        {
                            Console.WriteLine("\nYou choose Cylinder.");
                            shape = 2;
                            shapeChoosen = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease choose a valid answer.");
                            continue;
                        }
                    }
                    columnChoosen = false;
                    // CHOOSE COLUMN   <-----
                    while (columnChoosen != true)
                    {
                        Console.WriteLine("On which column do you want to place your shape? (1 - 7)");

                        nextMove = player1.GetPosition(board);

                        columnChoosen = true;

                        if (!board.SetState(nextMove, board.NextTurn))
                        {
                            Console.WriteLine("That is not a legal move.");
                            columnChoosen = false;
                        }
                    }
                }
            }

            renderer.Render(board);
            renderer.RenderResults(winChecker.Check(board));

            Console.ReadKey();
        }
    }
}