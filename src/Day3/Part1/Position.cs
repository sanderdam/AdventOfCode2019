using System;
using System.Diagnostics.CodeAnalysis;

namespace Day3.Part1
{
    public class Position : IEquatable<Position>
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Position GetNextPositionInDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Position(X, Y + 1);
                case Direction.Down:
                    return new Position(X, Y - 1);
                case Direction.Left:
                    return new Position(X - 1, Y);
                case Direction.Right:
                    return new Position(X + 1, Y);
            }

            throw new ArgumentException("Unexpected direction");
        }

        public bool Equals([AllowNull] Position other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
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
}
