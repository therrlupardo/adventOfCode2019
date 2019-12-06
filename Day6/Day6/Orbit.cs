using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Orbit
    {
        public OrbitNode Com { get; set; }
        public Orbit(string baseName)
        {
            Com = new OrbitNode("COM", null);
            Com.Children = FindChildren(ExtractBaseOrbits(), Com);
        }

        public int CalculateShortestPath()
        {
            var santaAncestors = Com.GetAncestorsForChild("SAN");
            var yourAncestors = Com.GetAncestorsForChild("YOU");
            return santaAncestors.Intersect(yourAncestors)
                .ToList()
                .Select(x => GetAncestorDistance(santaAncestors, x) + GetAncestorDistance(yourAncestors, x))
                .Min();
        }

        public int GetChecksum() => Com.Checksum;

        private protected List<BaseOrbitElement> ExtractBaseOrbits()
        {
            var file = File.ReadAllLines("../../../data.txt").ToList();
            return file.Select(x => new BaseOrbitElement()
            {
                Name = x.Split(')')[0],
                Child = x.Split(')')[1]
            }).ToList();
        }

        private protected int GetAncestorDistance(IList<OrbitNode> orbit, OrbitNode node) => orbit.IndexOf(node);

        private protected List<OrbitNode> FindChildren(List<BaseOrbitElement> orbits, OrbitNode root)
        {
            orbits.FindAll(x => x.Name == root.Name).ForEach(y => root.Children.Add(new OrbitNode(y.Child, root)));
            root.Children.ForEach(x => x.Children = FindChildren(orbits, x));
            return root.Children;
        }
    }
}
