using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Program
    {

        public static void Main()
        {
            var numbersBase = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            var copy = new int[numbersBase.Count];
            numbersBase.CopyTo(copy);
            for (var verb = 0; verb <= 99; verb++)
            {
                for (var noun = 0; noun <= 99; noun++)
                {
                    numbersBase.CopyTo(copy);
                    copy[1] = noun;
                    copy[2] = verb;
                    if (Calculate(copy) == 19690720)
                    {
                        Console.WriteLine(100 * noun + verb);
                        return;
                    }
                }
            }

        }

        private static int Calculate(IList<int> numbers)
        {
            for (var index = 0; index < numbers.Count; index += 4)
            {
                var opCode = numbers.ElementAt(index);
                if (opCode == 99) break;
                var a = numbers.ElementAt(index + 1);
                var b = numbers.ElementAt(index + 2);
                var dest = numbers.ElementAt(index + 3);
                switch (opCode)
                {
                    case 1:
                    {
                        var result = numbers.ElementAt(a) + numbers.ElementAt(b);
                        numbers[dest] = result;
                        break;
                    }
                    case 2:
                    {
                        var result = numbers.ElementAt(a) * numbers.ElementAt(b);
                        numbers[dest] = result;
                        break;
                    }
                }
            }

            return numbers.First();
        }
    }
}
