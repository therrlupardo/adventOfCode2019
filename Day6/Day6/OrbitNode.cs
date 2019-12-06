using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class OrbitNode
    {
        public string Name { get; set; }
        public List<OrbitNode> Children { get; set; }
        public OrbitNode Parent { get; set; }
        public int CountChildren
        {
            get
            {
                var counter = Children.Count;
                Children.ForEach(x => counter += x.CountChildren);
                return counter;
            }
        }
        public int Checksum
        {
            get
            {
                var checksum = CountChildren;
                Children.ForEach(x => checksum += x.Checksum);
                return checksum;
            }
        }
        public List<OrbitNode> Ancestors
        {
            get
            {
                var ancestors = new List<OrbitNode>();
                if (Parent == null) return ancestors;
                ancestors.Add(Parent);
                ancestors = ancestors.Concat(Parent.Ancestors).ToList();
                return ancestors;
            }
        }

        public OrbitNode(string name, OrbitNode parent)
        {
            Name = name;
            Children = new List<OrbitNode>();
            Parent = parent;
        }

        public List<OrbitNode> GetAncestorsForChild(string name)
        {
            var ancestors = new List<OrbitNode>();
            if (Name == name) return Ancestors;
            Children.ForEach(x => ancestors = ancestors.Concat(x.GetAncestorsForChild(name)).ToList());
            return ancestors;
        }
    }
}