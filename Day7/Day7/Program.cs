using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Permutator.GetPermutations(new List<int>() { 0, 1, 2, 3, 4 }, 5)
                .ToList()
                .Select(x => new AmplificationCircuit(x.ToList()).Run())
                .ToList()
                .Max());
        }
    }
}
