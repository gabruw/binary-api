using Domain.DTO;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Test.Fixtures;
using Xunit;

namespace Test.Scenarios
{
    public class GetDbResult
    {
        private readonly TestContext _testContext;

        public GetDbResult()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task GetDbResultOk()
        {
            long leftId = 1;
            long rightId = 1;
            string url = string.Format("/v1/diff/db?leftId={0}&rightId={1}", leftId, rightId);

            var response = await _testContext.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);

            string result = response.Content.ReadAsStringAsync().Result;
            Response objResponse = JsonConvert.DeserializeObject<Response>(result);
            Assert.True(objResponse != null);
        }

        [Fact]
        public async Task GetDbResultBadRequest()
        {
            long leftId = 1;
            long rightId = 999999;
            string url = string.Format("/v1/diff/db?leftId={0}&rightId={1}", leftId, rightId);

            var response = await _testContext.Client.GetAsync(url);
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }
    }
}
