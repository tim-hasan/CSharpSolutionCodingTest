using System;
using Engine;

namespace Communicator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please provide your Input:");
            string input = args[0];
            CommunicatorCalculator cc = new CommunicatorCalculator();
            cc.ParseAndGroup(input);
            Console.WriteLine(cc.GetMaxComms());
        }
    }
}
 