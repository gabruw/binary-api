using Api.Utils;
using Domain.Entity;
using Xunit;

namespace TestUnit.Scenarios
{
    public class BinaryTest
    {
        [Fact]
        public void BinaryToString()
        {
            string expected = "Funcionou";
            DiffLeft diff = new DiffLeft("01000110 01110101 01101110 01100011 01101001 01101111 01101110 01101111 01110101");

            Diff result = Binary.BinaryToString(diff);

            Assert.True(expected == result.Value);
        }
    }
}
