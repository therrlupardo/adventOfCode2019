using System;

namespace Day6
{
    public class Program
    {
        public static void Main()
        {
            var orbit = new Orbit("COM");
            Console.WriteLine(orbit.GetChecksum());
            Console.WriteLine(orbit.CalculateShortestPath());
        }
    }
}
