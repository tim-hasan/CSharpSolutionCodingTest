using System.Collections.Generic;
using System.Linq;
using Engine;
using Xunit;

namespace Communicator.Tests
{
    public class CommunicatorTests
    {  
        [Fact]
        public void Should_Return_3_for_Example_Input()
        {
            const string exampleInput = @"Alpha,Bravo 
Bravo,Alpha, SAT1
SAT1,Bravo , Charlie
Charlie, SAT1
Delta  ,Zulu
 Zulu,Delta, SAT2
SAT2,  Zulu";
            int expectedNodes = 3;
            CommunicatorCalculator comm = new CommunicatorCalculator();
            _ = comm.ParseAndGroup(exampleInput);
            int maxNodes = comm.GetMaxComms(); 

            Assert.Equal(expectedNodes, maxNodes);
        }

        [Theory]
        [InlineData(@"Alpha,Bravo 
Bravo,Alpha, SAT1
SAT1,Bravo , Charlie
Charlie, SAT1
Delta  ,Zulu
 Zulu,Delta, SAT2
SAT2,  Zulu", 3)]
        [InlineData(@"Alpha,Bravo 
Bravo,Alpha, SAT1
SAT1,Bravo , Charlie
Charlie, SAT1
Delta  ,Zulu
 Zulu,Delta, SAT2
SAT2,  Zulu
SAT3, Timur, Sabrina, Amira, Unknown
Timur, SAT3
Sabrina, SAT3
Amira, SAT3
Unknown, SAT3
", 4)] 
        public void Should_GetMaxComms_For_Other_Test_Cases(string text,int expectedNodes)
        { 
            CommunicatorCalculator comm = new CommunicatorCalculator();
            _ = comm.ParseAndGroup(text);
            int maxNodes = comm.GetMaxComms(); 
            Assert.Equal(expectedNodes, maxNodes);
        }
         
        [Theory]
        [InlineData("Alpha,Bravo",2)]
        [InlineData("Alpha,Bravo,Cappa",3)] 
        public void Should_Split_Into_Nodes(string input, int expectedNodes)
        { 
            CommunicatorCalculator comm = new CommunicatorCalculator();
            List<Node> nodes = comm.ConvertToNodes(input);
             
            Assert.Equal(expectedNodes, nodes.Count);

        }

           [Theory]
           [InlineData("Alpha,Bravo", 1)]
           [InlineData("Alpha,Bravo,Cappa", 1)] 
           public void Should_group_Inputs_Lines(string input, int expectedGroups)
           {
               CommunicatorCalculator comm = new CommunicatorCalculator();

               List<Node> nodes = comm.ConvertToNodes(input);
               List<List<Node>> groups = comm.AddGroup(nodes); 
               Assert.Equal(expectedGroups, groups.Count); 
           } 
          

        [Theory]
        [InlineData("Alpha,Bravo", 1)]
        [InlineData("Alpha,Bravo\nCappa", 2)]
        [InlineData("Alpha,Bravo\nCappa\nDelta\nGamma", 4)]
        [InlineData("Alpha,Bravo,SAT1\nCappa\nDelta\nGamma", 4)]
        public void Should_group_multiple_Lines_Separatly(string input, int expectedGroups)
        {
            CommunicatorCalculator comm = new CommunicatorCalculator();
            List<List<Node>> groups = comm.ParseAndGroup(input);
            Assert.Equal(expectedGroups, groups.Count);

        }

        [Theory] 
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa", 1)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa\nSAT2,delta", 2)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa\nSAT2,delta,\nSAT3,Gamma", 3)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa\nSAT2,delta,\nSAT1,Gamma", 2)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Bravo\nSAT2,delta", 2)]
        [InlineData(@"Alpha,Bravo,SAT1
SAT1,Bravo
SAT2,Ccappa", 2)]
        [InlineData("Alpha,Bravo\nBravo,Alpha, SAT1\nSAT1,Bravo , Charlie\nCharlie, SAT1\nDelta  ,Zulu\nZulu,Delta, SAT2\nSAT2,  Zulu", 2)]
        public void Should_group_multiple_Lines_together(string input, int expectedGroups)
        {
            CommunicatorCalculator comm = new CommunicatorCalculator();
            List<List<Node>> groups = comm.ParseAndGroup(input);
            Assert.Equal(expectedGroups, groups.Count);

        }

        [Theory]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa", 3)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa,Slapa", 4)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa,Slapa,SAT2", 4)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa,Slapa\nSAT2,Zeta\nSAT3,Omega", 4)]
        [InlineData("Alpha,Bravo,SAT1\nSAT1,Cappa,Slapa\nSAT2,Zeta\nSAT1,Giga", 5)]
        public void Should_Count_Unique_Nodes(string input, int expectedNodes)
        { 
            CommunicatorCalculator comm = new CommunicatorCalculator(); 
            List<List<Node>> groups = comm.ParseAndGroup(input);
            int actualNodes = comm.CountNodes(groups[0]);
            Assert.Equal(expectedNodes, actualNodes);
        }

    }
}
