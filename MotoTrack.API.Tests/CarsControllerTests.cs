using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Newtonsoft.Json;
using MotoTrack.API;

namespace MotoTrack.API.Tests
{
    public class CarsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CarsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCars_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/Cars");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostCar_ThenGetCar_ReturnsCreatedAndCar()
        {
            var car = new
            {
                make = "TestMake",
                model = "TestModel",
                plateNumber = "TEST123",
                imageUrl = ""
            };
            var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
            var postResponse = await _client.PostAsync("/api/Cars", content);
            Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

            var created = JsonConvert.DeserializeObject<dynamic>(await postResponse.Content.ReadAsStringAsync());
            int carId = created.id;

            var getResponse = await _client.GetAsync($"/api/Cars/{carId}");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            var getCar = JsonConvert.DeserializeObject<dynamic>(await getResponse.Content.ReadAsStringAsync());
            Assert.Equal("TestMake", (string)getCar.make);
            Assert.Equal("TestModel", (string)getCar.model);
        }
    }
} 