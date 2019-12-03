using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Day3.Part2
{
    public class Position
    {
        public Position(int x, int y, int totalNumberOfSteps)
        {
            X = x;
            Y = y;
            NumberOfStepsTaken = totalNumberOfSteps;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int NumberOfStepsTaken { get; set; }

        public Position GetNextPositionInDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Position(X, Y + 1, NumberOfStepsTaken + 1);
                case Direction.Down:
                    return new Position(X, Y - 1, NumberOfStepsTaken + 1);
                case Direction.Left:
                    return new Position(X - 1, Y, NumberOfStepsTaken + 1);
                case Direction.Right:
                    return new Position(X + 1, Y, NumberOfStepsTaken + 1);
            }

            throw new ArgumentException("Unexpected direction");
        }

        public int Distance
        {
            get
            {
                var x = X;
                if (x < 0)
                {
                    x = Math.Abs(x);
                }

                var y = Y;
                if (y < 0)
                {
                    y = Math.Abs(y);
                }

                return x + y;
            }
        }
    }

    public class DoesPositionsIntersect : IEqualityComparer<Position>
    {
        public bool Equals([AllowNull] Position x, [AllowNull] Position y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
                return false;

            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode([DisallowNull] Position obj)
        {
            return obj.X.GetHashCode() ^ obj.Y.GetHashCode();
        }
    }
}
