using System;

namespace Simplexity
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
                    return new Position(position, 0);
                case 2:
                    return new Position(position, 1);
                case 3:
                    return new Position(position, 2);
                case 4:
                    return new Position(position, 3);
                case 5:
                    return new Position(position, 4);
                case 6:
                    return new Position(position, 5);
                case 7:
                    return new Position(position, 6);
                default: return null;
            }
        }
    }


}
