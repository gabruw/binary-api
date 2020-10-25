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
    public class DeleteRight
    {
        private readonly TestContext _testContext;

        public DeleteRight()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task DeleteRightValueOk()
        {
            var responseGetAll = await _testContext.Client.GetAsync("/v1/diff/db/left");
            string result = responseGetAll.Content.ReadAsStringAsync().Result;
            List<DiffRight> objResponse = JsonConvert.DeserializeObject<List<DiffRight>>(result);

            long id = objResponse.Last().Id;
            string url = string.Format("/v1/diff/db/right?id={0}", id);
            var response = await _testContext.Client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }
    }
}
