using Domain.Entity;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Fixtures;
using Xunit;

namespace Test.Scenarios
{
    public class PostLeft
    {
        private readonly TestContext _testContext;

        public PostLeft()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task PostLeftValueOk()
        {
            DiffLeft diffLeft = new DiffLeft("01010100 01100101 01110011 01110100 01100101 00100000 01101100 01100101 01100110 01110100");
            string json = JsonConvert.SerializeObject(diffLeft);

            var send = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/v1/diff/left", send);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostLeftValueBadRequest()
        {
            DiffLeft diffLeft = new DiffLeft(null);
            string json = JsonConvert.SerializeObject(diffLeft);

            var send = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/v1/diff/left", send);
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }
    }
}
