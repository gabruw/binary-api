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
    public class PostRight
    {
        private readonly TestContext _testContext;

        public PostRight()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task PostRightValueOk()
        {
            DiffRight diffRight = new DiffRight("01010100 01100101 01110011 01110100 01100101 00100000 01110010 01101001 01100111 01101000 01110100");
            string json = JsonConvert.SerializeObject(diffRight);

            var send = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/v1/diff/right", send);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostRightValueBadRequest()
        {
            DiffRight diffRight = new DiffRight(null);
            string json = JsonConvert.SerializeObject(diffRight);

            var send = new StringContent(json);
            var response = await _testContext.Client.PostAsync("/v1/diff/right", send);
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }
    }
}
