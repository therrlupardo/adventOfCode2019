using System;
using System.IO;
using System.Linq;

namespace Day1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var sum = 0;
            var file = File.ReadAllLines("../../../data.txt").ToList();
            file.ForEach(line =>
            {
                var mass = int.Parse(line);
                var newFuel = CalculateFuel(mass);
                sum += newFuel;
                while (newFuel != 0)
                {
                    newFuel = CalculateFuel(newFuel);
                    sum += newFuel;
                }

            });
            Console.WriteLine(sum);
        }

        private static int CalculateFuel(int mass)
        {
            var fuel = (int)Math.Floor((double)mass / 3) - 2;
            return fuel >= 0 ? fuel : 0;
        }
    }
}
