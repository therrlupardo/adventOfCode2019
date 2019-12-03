using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../../data.txt").ToList();
            var intersections = GetDistinctPointsOnRoad(file[0], out var road1).Intersect(GetDistinctPointsOnRoad(file[1], out var road2)).ToList();
            Console.WriteLine(intersections.Select(x => CalculateManhattanDistance(new Point(0, 0), x)).ToList().Min());
            Console.WriteLine(intersections.Select(x => road1.FindIndex(a => a == x) + road2.FindIndex(a => a == x) + 2).Min());
        }

        private static IEnumerable<Point> GetDistinctPointsOnRoad(string road, out List<Point> roadPoints)
        {
            var current = new Point(0, 0);
            var points = new List<Point>();
            road.Split(',')
                .ToList()
                .ForEach(o => points = points.Concat(GetPoints(current, out current, o)).ToList()
                );
            roadPoints = points;
            return points.Distinct().ToList();
        }

        private static int CalculateManhattanDistance(Point start, Point end)
        {
            var horizontalDistance = Math.Abs(start.Y - end.Y);
            var verticalDistance = Math.Abs(start.X - end.X);
            return horizontalDistance + verticalDistance;
        }

        private static Direction GetDirection(string order)
        {
            var direction = order[0];
            switch (direction)
            {
                case 'R':
                    return Direction.Right;
                case 'L':
                    return Direction.Left;
                case 'U':
                    return Direction.Up;
                case 'D':
                    return Direction.Down;
                default:
                    return Direction.Up;
            }
        }

        private static List<Point> GetPoints(Point source, out Point destination, string order)
        {
            var points = new List<Point>();
            var distance = int.Parse(order.Substring(1));
            switch (GetDirection(order))
            {
                case Direction.Up:
                    for (var i = 1; i <= distance; i++)
                    {
                        points.Add(new Point(source.X, source.Y + i));
                    }
                    break;
                case Direction.Down:
                    for (var i = 1; i <= distance; i++)
                    {
                        points.Add(new Point(source.X, source.Y - i));
                    }
                    break;
                case Direction.Left:
                    for (var i = 1; i <= distance; i++)
                    {
                        points.Add(new Point(source.X - i, source.Y));
                    }
                    break;
                case Direction.Right:
                    for (var i = 1; i <= distance; i++)
                    {
                        points.Add(new Point(source.X + i, source.Y));
                    }
                    break;
            }

            destination = points.Last();
            return points;
        }
    }
}
