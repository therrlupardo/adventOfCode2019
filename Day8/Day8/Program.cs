using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../../data.txt").ToList().First();
            var layers = Split(input,150);
            var minZerosInLayer = int.MaxValue;
            var minIndex = 0;
            layers.ForEach(layer =>
            {
                var zeroes = CountSigns(layer, '0');
                if (zeroes < minZerosInLayer)
                {
                    minZerosInLayer = zeroes;
                    minIndex = layers.IndexOf(layer);
                }
            });

            Console.WriteLine(CountSigns(layers[minIndex],'1') * CountSigns(layers[minIndex], '2'));
            var reverse = ReverseArray(layers);
            
            reverse = reverse.Select(layer => layer.Replace('2', ' ').Trim()).ToList();
            reverse.ForEach(x => Console.Write(x[0]));

        }

        private static List<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize)).ToList();
        }

        private static List<string> ReverseArray(List<string> str)
        {
            var array = str.ToArray();
            var list = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                var tmp = "";
                for (int j = 0; j < array[0].Length; j++)
                {
                    tmp += array[i][j];
                }
                list.Add(tmp);
            }
            return list;
        }

        private static int CountSigns(string str, char sign)
        {
            var counter = 0;
            foreach (var s in str)
            {
                if (s == sign) counter++;
            }
            return counter;
        }
    }
}
