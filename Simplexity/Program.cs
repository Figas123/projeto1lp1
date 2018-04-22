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
            // While the game is still going it loop
            while (!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided)
            {
                // Reders the board
                renderer.Render(board, shape);
                // Creates a position
                Position nextMove;
                // If the turn is even
                if (turn % 2 != 0)
                {
                    Console.WriteLine("Your turn, player 1");

                    shapeChoosen = false;
                    // While the shape isnt choosen loop
                    while (shapeChoosen != true)
                    {
                        Console.WriteLine("What shape do you want to play? (Square = 1 / Cylinder = 2)");
                        // Saves what the player typed
                        ConsoleKeyInfo choice = Console.ReadKey();
                        // If the user types "1"
                        if (choice.KeyChar == '1')
                        {
                            Console.WriteLine("\nYou choose Square.");
                            shape = (int)Shape.square;
                            shapeChoosen = true;
                            break;
                        }
                        // If the user types "2"
                        else if (choice.KeyChar == '2')
                        {
                            Console.WriteLine("\nYou choose Cylinder.");
                            shape = (int)Shape.cylinder;
                            shapeChoosen = true;
                            break;
                        }
                        // If the user types anything but "1" or "2"
                        else
                        {
                            Console.WriteLine("\nPlease choose a valid answer.");
                            continue;
                        }
                    }
                    columnChoosen = false;
                    // While the player doesnt type anything loop
                    while (columnChoosen != true)
                    {
                        Console.WriteLine("On which column do you want to place your shape? (1 - 7)");

                        nextMove = player1.GetPosition(board);

                        columnChoosen = true;
                        // If the grid space is occupied already
                        if (!board.SetState(nextMove, board.NextTurn))
                        {
                            Console.WriteLine("That is not a legal move.");
                            columnChoosen = false;
                        }
                    }
                    turn++;
                }
                // If the turn is odd
                else
                {
                    Console.WriteLine("Your turn, player 2");
                    shapeChoosen = false;
                    // While the shape isnt choosen loop
                    while (shapeChoosen != true)
                    {
                        Console.WriteLine("What shape do you want to play? (Square = 1 / Cylinder = 2)");
                        // Saves what the player typed
                        ConsoleKeyInfo choice = Console.ReadKey();
                        // If the user types "1"
                        if (choice.KeyChar == '1')
                        {
                            Console.WriteLine("\nYou choose Square.");
                            shape = (int)Shape.square;
                            shapeChoosen = true;
                            break;
                        }
                        // If the user types "2"
                        else if (choice.KeyChar == '2')
                        {
                            Console.WriteLine("\nYou choose Cylinder.");
                            shape = (int)Shape.cylinder;
                            shapeChoosen = true;
                            break;
                        }
                        // If the user types anything but "1" or "2"
                        else
                        {
                            Console.WriteLine("\nPlease choose a valid answer.");
                            continue;
                        }
                    }
                    columnChoosen = false;
                    // While the player doesnt type anything loop
                    while (columnChoosen != true)
                    {
                        Console.WriteLine("On which column do you want to place your shape? (1 - 7)");

                        nextMove = player2.GetPosition(board);

                        columnChoosen = true;
                        // If the grid space is occupied already
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