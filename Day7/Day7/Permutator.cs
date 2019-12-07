using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day7
{
    public class Permutator
    {
        public static IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> list, int length)
        {
            if (length == 1) return list.Select(t => new int[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new int[] { t2 }));
        }
    }
}
