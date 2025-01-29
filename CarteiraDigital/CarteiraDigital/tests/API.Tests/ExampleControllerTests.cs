using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests
{
    public class ExampleControllerTests : IClassFixture<WebApplicationFactory<API.Program>>
    {
        private readonly HttpClient _client;

        public ExampleControllerTests(WebApplicationFactory<API.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var request = "/api/example"; // Adjust the endpoint as necessary

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_CreatesEntity_ReturnsCreatedResult()
        {
            // Arrange
            var request = "/api/example"; // Adjust the endpoint as necessary
            var content = new StringContent("{\"name\":\"Example\"}", System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(request, content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        // Additional tests for Put and Delete can be added here
    }
}