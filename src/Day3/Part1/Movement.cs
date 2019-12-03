using System;
using System.Collections.Generic;

namespace Day3.Part1
{
    public class Movement
    {
        public Movement(char direction, int numberOfSteps)
        {
            Direction = DirectionParser.ParseDirection(direction);
            NumberOfSteps = numberOfSteps;
        }

        public Direction Direction { get; set; }
        public int NumberOfSteps { get; set; }

        public List<Position> GetPathFromPosition(Position position)
        {
            List<Position> path = new List<Position>(NumberOfSteps);
            Position lastPosition = position;

            for (int step = 1; step <= NumberOfSteps; step++)
            {
                lastPosition = lastPosition.GetNextPositionInDirection(Direction);
                path.Add(lastPosition);
            }

            return path;
        }
    }

    public static class DirectionParser
    {
        public static Direction ParseDirection(char direction)
        {
            switch (direction)
            {
                case 'U':
                    return Direction.Up;
                case 'D':
                    return Direction.Down;
                case 'L':
                    return Direction.Left;
                case 'R':
                    return Direction.Right;
            }

            throw new ArgumentException("Direction cannot be parsed");
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
