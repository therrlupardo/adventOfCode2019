using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var instructions = File.ReadAllLines("../../../data.txt")[0].Split(',').ToList().Select(int.Parse).ToList();
            var index = 0;
            while (index < instructions.Count)
            {
                var order = instructions[index].ToString();
                switch (order[^1])
                {
                    case '1':
                        instructions = AddNextValues(instructions, index);
                        index += 4;
                        break;
                    case '2':
                        instructions = MultiplyNextValues(instructions, index);
                        index += 4;
                        break;
                    case '3':
                        instructions = ReadValue(instructions, index);
                        index += 2;
                        break;
                    case '4':
                        WriteValue(instructions, index);
                        index += 2;
                        break;
                    case '5':
                        index = JumpIf(true, instructions, index);
                        break;
                    case '6':
                        index = JumpIf(false, instructions, index);
                        break;
                    case '7':
                        instructions = Compare(false, instructions, index);
                        index += 4;
                        break;
                    case '8':
                        instructions = Compare(true, instructions, index);
                        index += 4;
                        break;
                    case '9':
                        return;
                }
            }
        }

        private static List<int> AddNextValues(List<int> instructions, int index)
        {
            var s = instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            var param1 = instructions[index + 1];
            var param2 = instructions[index + 2];
            var param3 = instructions[index + 3];
            var value1 = CheckParam(order[2], instructions, param1);
            var value2 = CheckParam(order[1], instructions, param2);
            instructions[param3] = value1 + value2;
            return instructions;
        }

        private static List<int> MultiplyNextValues(List<int> instructions, int index)
        {
            var s = instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            var param1 = instructions[index + 1];
            var param2 = instructions[index + 2];
            var param3 = instructions[index + 3];
            var value1 = CheckParam(order[2], instructions, param1);
            var value2 = CheckParam(order[1], instructions, param2);
            instructions[param3] = value1 * value2;
            return instructions;
        }

        private static int CheckParam(char mode, IReadOnlyList<int> instructions, int param)
        {
            return mode == '1' ? param : instructions[param];
        }

        private static int JumpIf(bool condition, List<int> instructions, int index)
        {
            var s = instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            var param1 = instructions[index + 1];
            var param2 = instructions[index + 2];
            var value1 = CheckParam(order[2], instructions, param1);
            var value2 = CheckParam(order[1], instructions, param2);
            return (value1 != 0) == condition ? value2 : index + 3;
        }

        private static List<int> Compare(bool isEqual, List<int> instructions, int index)
        {
            var s = instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            var param1 = instructions[index + 1];
            var param2 = instructions[index + 2];
            var param3 = instructions[index + 3];
            var value1 = CheckParam(order[2], instructions, param1);
            var value2 = CheckParam(order[1], instructions, param2);
            if (isEqual)
            {
                instructions[param3] = value1 == value2 ? 1 : 0;
            }
            else
            {
                instructions[param3] = value1 < value2 ? 1 : 0;
            }
            return instructions;
        }


        private static List<int> ReadValue(List<int> instructions, int index)
        {
            Console.WriteLine("Write a number");
            instructions[instructions[index + 1]] = int.Parse(Console.ReadLine());
            return instructions;
        }

        private static void WriteValue(IReadOnlyList<int> instructions, int index)
        {
            var order = instructions[index];
            var value = instructions[index + 1];
            Console.WriteLine(order == 104 ? value : instructions[value]);
        }
    }

}
