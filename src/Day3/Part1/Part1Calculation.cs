using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day3.Part1
{
    internal partial class Part1Calculation
    {
        public static void Part1(string[] wires)
        {
            //string wire1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            //string wire2 = "U62,R66,U55,R34,D71,R55,D58,R83";

            var movementsForWire1 = ParseMovements(wires[0]);
            var movementsForWire2 = ParseMovements(wires[1]);

            Console.WriteLine("Starting calculations for day 3 - part 1");
            Stopwatch sw = Stopwatch.StartNew();

            var pathWire1 = GetAllPositionsForWire(movementsForWire1);
            var pathWire2 = GetAllPositionsForWire(movementsForWire2);

            var intersections = FindIntersections(pathWire1, pathWire2);
            int leastDistanceIntersection = FindClosestIntersection(intersections);

            sw.Stop();
            Console.WriteLine($"Result: {leastDistanceIntersection}, found in {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("End of day 3 - part 1");
        }

        internal static List<Movement> ParseMovements(string input)
        {
            string[] movements = input.Split(',');
            return movements.Select(movement =>
            {
                return new Movement(movement[0], int.Parse(movement.Substring(1)));
            }).ToList();
        }

        internal static List<Position> GetAllPositionsForWire(List<Movement> movements)
        {
            List<Position> pathOfWire = new List<Position>();
            Position currentPositionOfWire = new Position(0, 0); // start position

            foreach (Movement movement in movements)
            {
                pathOfWire.AddRange(movement.GetPathFromPosition(currentPositionOfWire));
                currentPositionOfWire = pathOfWire.Last(); // set current position to last position
            }

            return pathOfWire;
        }

        internal static List<Position> FindIntersections(List<Position> positionsWire1, List<Position> positionsWire2)
        {
            var intersections = positionsWire1.Intersect(positionsWire2).ToList();

            return intersections;
        }

        internal static int FindClosestIntersection(List<Position> intersections)
        {
            int minDistance = intersections.Min(p => p.Distance);
            return minDistance;
        }
    }


}
