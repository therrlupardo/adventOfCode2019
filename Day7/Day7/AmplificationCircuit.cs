using System.Collections.Generic;

namespace Day7
{
    public class AmplificationCircuit
    {
        public List<int> Settings { get; set; }
        public List<IntcodeComputer> Amplifiers { get; set; }

        public AmplificationCircuit(List<int> settings)
        {
            Settings = settings;
        }

        public int Run()
        {
            var amplifierA = new IntcodeComputer(Settings[0], null);
            var amplifierB = new IntcodeComputer(Settings[1], amplifierA.Run());
            var amplifierC = new IntcodeComputer(Settings[2], amplifierB.Run());
            var amplifierD = new IntcodeComputer(Settings[3], amplifierC.Run());
            var amplifierE = new IntcodeComputer(Settings[4], amplifierD.Run());
            return amplifierE.Run();
        }
    }
}
