using Api.Utils;
using Domain.DTO;
using Domain.Entity;
using Newtonsoft.Json;
using Xunit;

namespace TestUnit.Scenarios
{
    public class ValidateTest
    {
        [Fact]
        public void FormatError()
        {
            string expected = "{\"Errors\":[\"Teste erro 1.\"],\"Observations\":[]}";
            string error = "Teste erro 1.";

            Response result = Validate.FormatError(error);
            string compare = JsonConvert.SerializeObject(result);

            Assert.True(expected.Equals(compare));
        }

        [Fact]
        public void FormatObservationRemove()
        {
            string expected = "{\"Errors\":[],\"Observations\":[\"Valor Teste removido com sucesso.\"]}";

            DiffLeft diffLeft = new DiffLeft("Teste");
            diffLeft.Validate();

            Response result = Validate.FormatObservationRemove(diffLeft);
            string compare = JsonConvert.SerializeObject(result);

            Assert.True(expected.Equals(compare));
        }

        [Fact]
        public void FormatObservationInclude()
        {
            string expected = "{\"Errors\":[],\"Observations\":[\"Valor Teste adicionado com sucesso.\"]}";

            DiffLeft diffLeft = new DiffLeft("Teste");
            diffLeft.Validate();

            Response result = Validate.FormatObservationInclude(diffLeft);
            string compare = JsonConvert.SerializeObject(result);

            Assert.True(expected.Equals(compare));
        }

        [Fact]
        public void VerifyDiff()
        {
            string expected = "{\"Errors\":[],\"Observations\":[\"Tamanho do valor 'left' é idêntico ao tamanho do valor 'right'.\"]}";

            DiffLeft diffLeft = new DiffLeft("01010110 01100001 01101100 01110101 01100101 00100000 01001111 01101110 01100101");
            DiffRight diffRight = new DiffRight("01010110 01100001 01101100 01110101 01100101 00100000 01010100 01110111 01101111");

            Response result = Validate.VerifyDiff(diffLeft, diffRight);
            string compare = JsonConvert.SerializeObject(result);

            Assert.True(expected.Equals(compare));
        }

        [Fact]
        public void VerifyDiffReturnErrors()
        {
            string expected = "{\"Errors\":[\"Atributo 'value' é obrigatório.\",\"Atributo 'value' é obrigatório.\"],\"Observations\":[]}";

            DiffLeft diffLeft = new DiffLeft();
            diffLeft.Validate();

            DiffRight diffRight = new DiffRight();
            diffRight.Validate();

            Response result = Validate.VerifyDiff(diffLeft, diffRight);
            string compare = JsonConvert.SerializeObject(result);

            Assert.True(expected.Equals(compare));
        }
    }
}
