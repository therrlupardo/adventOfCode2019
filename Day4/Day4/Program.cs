using System;
using System.Linq;

namespace Day4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var correct = 0;
            for (var i = 145852; i <= 616942; i++)
            {
                if (ValidatePassword(i)) correct++;
            }

            Console.WriteLine(correct);
        }

        private static bool ValidatePassword(int i)
        {
            return i.ToString().Length == 6 && IsExactlyTwoAdjacent(i.ToString()) && IsNotDecreasing(i.ToString());
        }

        private static bool IsTwoAdjacent(string text)
        {
            var adjacent = false;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    adjacent = true;
                }
            }
            return adjacent;
        }

        private static bool IsExactlyTwoAdjacent(string text)
        {
            if (text[0] == text[1] && text[1] != text[2]) return true;
            for (var i = 1; i < text.Length - 2; i++)
            {
                if (text[i] == text[i + 1] && text[i] != text[i - 1] && text[i] != text[i + 2]) return true;
            }

            var length = text.Length;
            if (text[length - 2] == text[length - 1] && text[length - 3] != text[length - 2]) return true;
            return false;
        }

        private static bool IsNotDecreasing(string text)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (int.Parse(text[i].ToString()) > int.Parse(text[i + 1].ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
