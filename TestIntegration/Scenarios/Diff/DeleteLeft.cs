using Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Test.Fixtures;
using Xunit;

namespace Test.Scenarios
{
    public class DeleteLeft
    {
        private readonly TestContext _testContext;

        public DeleteLeft()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task DeleteLeftValueOk()
        {
            var responseGetAll = await _testContext.Client.GetAsync("/v1/diff/db/left");
            string result = responseGetAll.Content.ReadAsStringAsync().Result;
            List<DiffLeft> objResponse = JsonConvert.DeserializeObject<List<DiffLeft>>(result);

            long id = objResponse.Last().Id;
            string url = string.Format("/v1/diff/db/left?id={0}", id);
            var response = await _testContext.Client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }
    }
}
