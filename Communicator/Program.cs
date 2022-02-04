using System;
using Engine;

namespace Communicator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ReadFile(args);

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

        private static string ReadFile(string[] args)
        {
            string fileLocation = args[0];
            string input = null;
            try
            {
                input = System.IO.File.ReadAllText(fileLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue with reading from the file", ex);
            }

            return input;
        }
    }
}
 