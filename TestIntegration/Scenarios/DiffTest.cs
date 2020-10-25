using Domain.DTO;
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
    public class DiffTest
    {
        private readonly TestContext _testContext;

        public DiffTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task PostLeftValueOkResponse()
        {
            string value = "01010100 01100101 01110011 01110100 01100101 00100000 01101100 01100101 01100110 01110100";

            DiffLeft diffLeft = new DiffLeft(value);
            string json = JsonConvert.SerializeObject(diffLeft);

            var send = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/v1/diff/left", send);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostLeftValueBadRequestResponse()
        {
            string value = null;

            DiffLeft diffLeft = new DiffLeft(value);
            string json = JsonConvert.SerializeObject(diffLeft);

            var send = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/v1/diff/left", send);
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task PostRightValueOkResponse()
        {
            string value = "01010100 01100101 01110011 01110100 01100101 00100000 01110010 01101001 01100111 01101000 01110100";

            DiffLeft diffLeft = new DiffLeft(value);
            string json = JsonConvert.SerializeObject(diffLeft);

            var send = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/v1/diff/right", send);
            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostRightValueBadRequestResponse()
        {
            string value = null;

            DiffLeft diffLeft = new DiffLeft(value);
            string json = JsonConvert.SerializeObject(diffLeft);

            var send = new StringContent(json);
            var response = await _testContext.Client.PostAsync("/v1/diff/right", send);
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetDBResultOkResponse()
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
        public async Task GetDBResultBadRequestResponse()
        {
            long leftId = 1;
            long rightId = 999999;
            string url = string.Format("/v1/diff/db?leftId={0}&rightId={1}", leftId, rightId);

            var response = await _testContext.Client.GetAsync(url);
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetStoreResultOkResponse()
        {
            await PostLeftValueOkResponse();
            await PostRightValueOkResponse();

            var response = await _testContext.Client.GetAsync("/v1/diff");
            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);

            string result = response.Content.ReadAsStringAsync().Result;
            Response objResponse = JsonConvert.DeserializeObject<Response>(result);
            Assert.True(objResponse != null);
        }

        [Fact]
        public async Task GetStoreResultBadRequestResponse()
        {
            await PostLeftValueBadRequestResponse();
            await PostRightValueBadRequestResponse();

            var response = await _testContext.Client.GetAsync("/v1/diff");
            response.StatusCode.CompareTo(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteLeftValueOkResponse()
        {
            await PostLeftValueOkResponse();

            string id = "1";
            string url = string.Format("/v1/diff/db/left?id={0}", id);
            var response = await _testContext.Client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteRightValueOkResponse()
        {
            await PostRightValueOkResponse();

            string id = "1";
            string url = string.Format("/v1/diff/db/right?id={0}", id);
            var response = await _testContext.Client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
            response.StatusCode.CompareTo(HttpStatusCode.OK);
        }
    }
}
