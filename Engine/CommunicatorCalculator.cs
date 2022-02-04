using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class CommunicatorCalculator
    { 
        private readonly List<List<Node>> groups;

        public CommunicatorCalculator()
        {
            groups = new List<List<Node>>();
             
        }

        public List<List<Node>> ParseAndGroup(string text)
        {
            string[] lines = text
                .Replace(" ","")
                .Replace("\r", "")
                .Split("\n");

            foreach (string line in lines)
            {
                _ = AddGroup(ConvertToNodes(line));
            }

            return groups;
        }

        public int GetMaxComms()
        {
            int count = 0;
            foreach (List<Node> group in groups)
            {
                int x = CountNodes(group);
                count = count >= x ? count : x;
            } 
            return count;
        }

        public int CountNodes(List<Node> nodes)
        {
            IEnumerable<Node> filtered = nodes
                .GroupBy(x => x.Name)
                .Select(y => y.First())
                .Where(x => !x.Name.Contains("SAT"));

                return filtered.Count(); 
        }

        public List<Node> ConvertToNodes(string Line)
        {
            string[] n = Line.Split(",");
            List<Node> nodes = n.Select(x=> new Node(x)).ToList();
            return nodes;
        }

        public List<List<Node>> AddGroup(List<Node> nodes)
        { 
            if (!GroupsContainsAny(nodes))
            {
                groups.Add(nodes);
            } 
            return groups;

        }

        public bool GroupsContainsAny(List<Node> nodes)
        {
            foreach (List<Node> group in groups)
            {
                foreach (Node node in group)
                {
                    foreach (Node n in nodes)
                    {
                        if (node.Name == n.Name)
                        {
                            group.AddRange(nodes);
                                return true;
                         }
                    }
                }
            }
            return false;
        }
    }
}