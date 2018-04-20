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
            int shape = (int)Shape.empty;
            
            bool shapeChoosen, columnChoosen;
            int turn = 1;

            while (!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided)
            {
                renderer.Render(board, shape);

                Position nextMove;
                // PLAYER 1 <----------------------------------
                if (turn % 2 != 0)
                {
                    Console.WriteLine("Your turn, player 1");

                    shapeChoosen = false;
                    // CHOOSE SHAPE   <------
                    while (shapeChoosen != true)
                    {
                        Console.WriteLine("What shape do you want to play? (Square = 1 / Cylinder = 2)");
                        ConsoleKeyInfo choice = Console.ReadKey();
                        // SQUARE
                        if (choice.KeyChar == '1')
                        {
                            Console.WriteLine("\nYou choose Square.");
                            shape = (int)Shape.square;
                            shapeChoosen = true;
                            break;
                        }
                        // CYLINDER
                        else if (choice.KeyChar == '2')
                        {
                            Console.WriteLine("\nYou choose Cylinder.");
                            shape = (int)Shape.cylinder;
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
                    turn++;
                }
                // PLAYER 2 <--------------------------------
                else
                {
                    Console.WriteLine("Your turn, player 2");
                    shapeChoosen = false;
                    // CHOOSE SHAPE   <------
                    while (shapeChoosen != true)
                    {
                        Console.WriteLine("What shape do you want to play? (Square = 1 / Cylinder = 2)");
                        ConsoleKeyInfo choice = Console.ReadKey();
                        // SQUARE
                        if (choice.KeyChar == '1')
                        {
                            Console.WriteLine("\nYou choose Square.");
                            shape = (int)Shape.square;
                            shapeChoosen = true;
                            break;
                        }
                        // CYLINDER
                        else if (choice.KeyChar == '2')
                        {
                            Console.WriteLine("\nYou choose Cylinder.");
                            shape = (int)Shape.cylinder;
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

                        nextMove = player2.GetPosition(board);

                        columnChoosen = true;

                        if (!board.SetState(nextMove, board.NextTurn))
                        {
                            Console.WriteLine("That is not a legal move.");
                            columnChoosen = false;
                        }
                    }
                    turn++;
                }
            }

            renderer.Render(board, shape);
            renderer.RenderResults(winChecker.Check(board));

            Console.ReadKey();
        }
    }
}