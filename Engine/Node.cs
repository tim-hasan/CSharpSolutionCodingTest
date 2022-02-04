
using System.Text.RegularExpressions;

namespace Engine
{
    public class Node
    {
        string pattern = @"^SAT[0-9]*$";
        public Node(string x)
        {
            ValidateName(x);
            Name = x;
        }

        private void ValidateName(string x)
        {
            if (x.Length > 20)
                throw new NodeNameTooLongException("'"+x+" was too long ");
            if (x.StartsWith("SAT") && !Regex.Match(x, pattern).Success)
            {
                throw new SATNodeNameInvalidException("'"+x+"' is an invalid SAT name");
            }
        }

        public string Name { get; }

    }
}