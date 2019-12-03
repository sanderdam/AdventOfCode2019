using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day3.Part2
{
    internal partial class Part2Calculation
    {
        public static void Part2(string[] wires)
        {
            //string wire1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            //string wire2 = "U62,R66,U55,R34,D71,R55,D58,R83";

            string wire1 = wires[0];
            string wire2 = wires[1];
                        
            var movementsForWire1 = ParseMovements(wire1);
            var movementsForWire2 = ParseMovements(wire2);

            Console.WriteLine("Starting calculations for day 3 - part 2");
            Stopwatch sw = Stopwatch.StartNew();
            
            var pathWire1 = GetAllPositionsForWire(movementsForWire1);
            var pathWire2 = GetAllPositionsForWire(movementsForWire2);

            var intersections = FindIntersections(pathWire1, pathWire2);
            int leastNumberOfStepsNeededToReachIntersection = FindLeastNeededStepsToReachIntersection(intersections, pathWire1, pathWire2);

            sw.Stop();
            Console.WriteLine($"Result: {leastNumberOfStepsNeededToReachIntersection}, found in {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("End of day 3 - part 2");
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
            Position currentPositionOfWire = new Position(0, 0, 0); // start position

            foreach (Movement movement in movements)
            {
                pathOfWire.AddRange(movement.GetPathFromPosition(currentPositionOfWire));
                currentPositionOfWire = pathOfWire.Last(); // set current position to last position
            }

            return pathOfWire;
        }

        internal static List<Position> FindIntersections(List<Position> pathWire1, List<Position> pathWire2)
        {
            var intersections = pathWire1.Intersect(pathWire2, new DoesPositionsIntersect()).ToList();
            return intersections;
        }

        internal static int FindLeastNeededStepsToReachIntersection(List<Position> intersections, List<Position> pathWire1, List<Position> pathWire2)
        {
            List<int> numberOfStepsTakenToReachIntersection = intersections.AsParallel().Select(intersection =>
                {
                    var firstPositionFromWire1 = pathWire1.First(pos => pos.X == intersection.X && pos.Y == intersection.Y);
                    var firstPositionFromWire2 = pathWire2.First(pos => pos.X == intersection.X && pos.Y == intersection.Y);

                    return firstPositionFromWire1.NumberOfStepsTaken + firstPositionFromWire2.NumberOfStepsTaken;
                }).ToList();

            return numberOfStepsTakenToReachIntersection.Min();
        }

        internal static int FindClosestIntersection(List<Position> intersections)
        {
            int minDistance = intersections.Min(p => p.Distance);
            return minDistance;
        }
    }


}
