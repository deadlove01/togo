using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Todo.Contracts.User;
using Xunit;

namespace Todo.Api.IntegrationTests
{
public class UserControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public UserControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        
        [Fact]
        public async Task GetAllUsers()
        {
            var httpResponse = await _client.GetAsync("/user");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserResponse>>(stringResponse);
            Assert.NotEmpty(users);
            Assert.Equal(2, users.Count());
       }
        
        [Fact]
        public async Task CreateUser()
        {
            var requestData = new CreateUserRequest
            {
                Username = "ravile115",
                FirstName = "rrrr",
                LastName = "llll",
                Password = "123456"
            };
            var httpResponse = await _client.PostAsJsonAsync("/user", requestData);
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var newUser = JsonConvert.DeserializeObject<UserResponse>(stringResponse);
            Assert.NotNull(newUser);
            Assert.Equal(requestData.Username, newUser.Username);
        }
    }
}