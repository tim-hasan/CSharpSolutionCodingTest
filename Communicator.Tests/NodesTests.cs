
using Xunit;
using Engine;

namespace Communicator.Tests
{
    public class NodesTests
    {
        [Theory]
        [InlineData("0123456789012345678901")]
        [InlineData("0123456789012345678901asdasdas")]
        [InlineData("0123456789012345678901asdaasdassdas")]  
        public void Should_Throw_Exception_When_Invalid_Text_Is_Set_Too_Long(string nodeName)
        {
             Assert.Throws<NodeNameTooLongException>(() => new Node(nodeName)); 
        }

        [Theory]
        [InlineData("SATxy1")]
        [InlineData("SAT12fff")] 
        public void Should_Throw_Exception_When_SATNAME_Text_Is_Set_Incorrecty(string nodeName)
        {
            Assert.Throws<SATNodeNameInvalidException>(() => new Node(nodeName));
        }

            [Theory]
        [InlineData("ALPHA")]
        [InlineData("0123456789012")]
        [InlineData("SAT1")]
        [InlineData("SAT112311")]
        public void Should_Not_Throw_Exception_When_Valid_Text_Is_set(string nodeName)
        {
            Node node = new Node(nodeName);
            Assert.Equal(nodeName, node.Name);
        }
    }
     
}
