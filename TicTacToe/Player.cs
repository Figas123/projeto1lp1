using System;

namespace TicTacToe
{
    public class Player
    {
        public Position GetPosition(Board board)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position);
            return desiredCoordinate;
        }

        private Position PositionForNumber(int position)
        {

            switch (position)
            {
                case 1:
                    position--;
                    return new Position(position, 0);
                case 2:
                    position--;
                    return new Position(position, 1);
                case 3:
                    position--;
                    return new Position(position, 2);
                case 4:
                    position--;
                    return new Position(position, 3);
                case 5:
                    position--;
                    return new Position(position, 4);
                case 6:
                    position--;
                    return new Position(position, 5);
                case 7:
                    position--;
                    return new Position(position, 6);
                default: return null;
            }
        }
    }


}
