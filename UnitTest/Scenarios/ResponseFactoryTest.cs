using Api.Utils;
using Domain.Entity;
using System.Collections.Generic;
using Xunit;

namespace TestUnit.Scenarios
{
    public class ResponseFactoryTest
    {
        [Fact]
        public void GetResponseOverErrorList()
        {
            string expected = "{\"Errors\":[\"Teste erro 1.\",\"Teste erro 2.\"],\"Observations\":null}";
            List<string> errors = new List<string>();
            errors.Add("Teste erro 1.");
            errors.Add("Teste erro 2.");

            string result = ResponseFactory.GetResponse(errors);
            Assert.True(expected == result);
        }

        [Fact]
        public void GetResponseOverDiffReturnObservations()
        {
            string expected = "{\"Errors\":null,\"Observations\":[\"Tamanho do valor 'left' é idêntico ao tamanho do valor 'right'.\"]}";

            DiffLeft diffLeft = new DiffLeft("01010110 01100001 01101100 01110101 01100101 00100000 01001111 01101110 01100101");
            DiffRight diffRight = new DiffRight("01010110 01100001 01101100 01110101 01100101 00100000 01010100 01110111 01101111");

            string result = ResponseFactory.GetResponse(diffLeft, diffRight);
            Assert.True(expected == result);
        }

        [Fact]
        public void GetResponseOverDiffReturnErrors()
        {
            string expected = "{\"Errors\":[\"Atributo 'value' é obrigatório.\",\"Atributo 'value' é obrigatório.\"],\"Observations\":null}";

            DiffLeft diffLeft = new DiffLeft();
            diffLeft.Validate();

            DiffRight diffRight = new DiffRight();
            diffRight.Validate();

            string result = ResponseFactory.GetResponse(diffLeft, diffRight);
            Assert.True(expected == result);
        }
    }
}
