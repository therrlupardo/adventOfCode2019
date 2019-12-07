using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    // ReSharper disable once IdentifierTypo
    public class IntcodeComputer
    {
        private List<int> _instructions;
        private int _ioValue;
        private int _prevAmplifier;

        private bool _firstUsage = true;
        // ReSharper disable once IdentifierTypo
        public IntcodeComputer(int inputValue, int? prevAmplifier)
        {
            _instructions = File.ReadAllLines("../../../data.txt")[0].Split(',').ToList().Select(int.Parse).ToList();
            _ioValue = inputValue;
            if (prevAmplifier != null) _prevAmplifier = (int) prevAmplifier;
        }

        public int Run()
        {
            var index = 0;
            while (index < _instructions.Count)
            {
                var order = _instructions[index].ToString();
                switch (order[^1])
                {
                    case '1':
                        _instructions = AddNextValues(index);
                        index += 4;
                        break;
                    case '2':
                        _instructions = MultiplyNextValues(index);
                        index += 4;
                        break;
                    case '3':
                        _instructions = ReadValue(index);
                        index += 2;
                        break;
                    case '4':
                        _ioValue = WriteValue(index);
                        index += 2;
                        break;
                    case '5':
                        index = JumpIf(true, index);
                        break;
                    case '6':
                        index = JumpIf(false, index);
                        break;
                    case '7':
                        _instructions = Compare(false, index);
                        index += 4;
                        break;
                    case '8':
                        _instructions = Compare(true, index);
                        index += 4;
                        break;
                    case '9':
                        return _ioValue;
                }
            }

            return _ioValue;
        }
        private List<int> AddNextValues(int index)
        {
            var s = _instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            _instructions[_instructions[index + 3]] = GetValueForParam(order[2], _instructions[index + 1]) + GetValueForParam(order[1], _instructions[index + 2]);
            return _instructions;
        }

        private List<int> MultiplyNextValues(int index)
        {
            var s = _instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            _instructions[_instructions[index + 3]] = GetValueForParam(order[2], _instructions[index + 1]) * GetValueForParam(order[1], _instructions[index + 2]);
            return _instructions;
        }

        private int GetValueForParam(char mode, int param)
        {
            return mode == '1' ? param : _instructions[param];
        }

        private int JumpIf(bool condition, int index)
        {
            var s = _instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            return (CheckJumpCondition(order[2], index + 1, condition) ? GetValueForParam(order[1], _instructions[index + 2]) : index + 3);
        }

        private bool CheckJumpCondition(char mode, int index, bool condition)
        {
            return (GetValueForParam(mode, _instructions[index]) != 0) == condition;
        }

        private List<int> Compare(bool isEqual, int index)
        {
            var s = _instructions[index].ToString();
            var order = s.PadLeft(5, '0');
            var id = _instructions[index + 3];
            var value1 = GetValueForParam(order[2], _instructions[index + 1]);
            var value2 = GetValueForParam(order[1], _instructions[index + 2]);
            if (isEqual)
            {
                _instructions[id] = value1 == value2 ? 1 : 0;
            }
            else
            {
                _instructions[id] = value1 < value2 ? 1 : 0;
            }
            return _instructions;
        }


        private List<int> ReadValue(int index)
        {
            if (_firstUsage)
            {
                _instructions[_instructions[index + 1]] = _ioValue;
                _firstUsage = false;
            }
            else
            {
                _instructions[_instructions[index + 1]] = _prevAmplifier;
            }
            return _instructions;
        }

        private int WriteValue(int index)
        {
            var order = _instructions[index];
            var value = _instructions[index + 1];
            return order == 104 ? value : _instructions[value];
        }
    }
}
