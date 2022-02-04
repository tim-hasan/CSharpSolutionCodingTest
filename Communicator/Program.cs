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
            try 
            {
                cc.ParseAndGroup(input);
            }
            catch (NodeNameTooLongException ex)
            {
                Console.WriteLine($"There was an issue with reading the input, one of the names was too long please see : {ex}");
            }
            catch (SATNodeNameInvalidException ex)
            {
                Console.WriteLine($"There was an issue with reading the input, a SAT name didn't have valid structure : {ex}");
            }
            Console.WriteLine(cc.GetMaxComms());
        }
    }
}
 