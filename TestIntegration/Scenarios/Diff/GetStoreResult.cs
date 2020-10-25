using Domain.DTO;
using Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Fixtures;
using Xunit;

namespace Test.Scenarios
{
    public class GetStoreResult
    {
        private readonly TestContext _testContext;

        public GetStoreResult()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task GetStoreResultOk()
        {
            // PostLeft
            DiffLeft diffLeft = new DiffLeft("01010100 01100101 01110011 01110100 01100101 00100000 01101100 01100101 01100110 01110100");
            string jsonLeft = JsonConvert.SerializeObject(diffLeft);

            var sendLeft = new StringContent(jsonLeft, Encoding.UTF8, "application/json");
            var responseLeft = await _testContext.Client.PostAsync("/v1/diff/left", sendLeft);

            responseLeft.EnsureSuccessStatusCode();
            responseLeft.StatusCode.CompareTo(HttpStatusCode.OK);

            //PostRight
            DiffRight diffRight = new DiffRight("01010100 01100101 01110011 01110100 01100101 00100000 01110010 01101001 01100111 01101000 01110100");
            string jsonRight = JsonConvert.SerializeObject(diffRight);

            var sendRight = new StringContent(jsonRight, Encoding.UTF8, "application/json");
            var responseRight = await _testContext.Client.PostAsync("/v1/diff/right", sendRight);

            responseRight.EnsureSuccessStatusCode();
            responseRight.StatusCode.CompareTo(HttpStatusCode.OK);

            // GetStoreResult
            var response = await _testContext.Client.GetAsync("/v1/diff");
            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);

            string result = response.Content.ReadAsStringAsync().Result;
            Response objResponse = JsonConvert.DeserializeObject<Response>(result);
            Assert.True(objResponse != null);
        }

        [Fact]
        public async Task GetStoreResultBadRequest()
        {
            var response = await _testContext.Client.GetAsync("/v1/diff");
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }
    }
}
