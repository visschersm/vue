using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

namespace HelloAuth0_AspNet2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var client = new RestClient("https://dev-eskpkoz3.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"p3psMlUO34mElGXLABnCUaR4d8JLVTjE\",\"client_secret\":\"Z5Z8PIot17k43FpIeEw1_ko3w45H1_9ZKRNMb23CTTI6mI8n2BA1ctsbk4iFDBHa\",\"audience\":\"https://localhost:5443/HelloApi\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var client2 = new RestClient("https://localhost:44391");
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik5rUkROREUyUlVGQ1F6RXdRemRHTVRkR09UWkVNVUl6TXpORFJrTXhNRGt6UlRJMk9URkRSUSJ9.eyJpc3MiOiJodHRwczovL2Rldi1lc2twa296My5ldS5hdXRoMC5jb20vIiwic3ViIjoicDNwc01sVU8zNG1FbEdYTEFCbkNVYVI0ZDhKTFZUakVAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjU0NDMvSGVsbG9BcGkiLCJpYXQiOjE1NzAwODQ3MDEsImV4cCI6MTU3MDE3MTEwMSwiYXpwIjoicDNwc01sVU8zNG1FbEdYTEFCbkNVYVI0ZDhKTFZUakUiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.WERvlZFu6dbn7X2Ub89LfdhnwzuLnIdD0NMYcW6GCKeq7mJRDdz4Ulw6C-TDvyJt0Qt02G90W_FhNoof8kktsTr6QY-V91WVnlJqNkhDHWyFp2cSk_W9LZkTE1MA8bwm3LYFKzcwuiRmnEANQGQS-nCYdMBCyykIJhxiLLV9IlzAvYBby4EIobZC4gSHFww8Kjc0wbJw2Q4kXILmKXeW108YYWqjSglmqz0N39ZnX9HB2mbCljKV3qeJgGvh_-q12SxrK_UWbrd98z_4hDh15Bw0neZuTWHsd4nGFNFuk7PsFfIv2zi9Y19UFgL0vFZnzj7KL1wbdIfo9M0gREB_tA");
            IRestResponse response2 = client.Execute(request2);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
