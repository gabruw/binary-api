using Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Test.Fixtures;
using Xunit;

namespace Test.Scenarios
{
    public class GetAllRight
    {
        private readonly TestContext _testContext;

        public GetAllRight()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task GetAllRightValueOk()
        {
            var response = await _testContext.Client.GetAsync("/v1/diff/db/left");
            string result = response.Content.ReadAsStringAsync().Result;
            JsonConvert.DeserializeObject<List<DiffLeft>>(result);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }
    }
}
