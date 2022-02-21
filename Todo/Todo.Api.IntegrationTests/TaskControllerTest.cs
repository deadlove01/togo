using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Todo.Contracts.Task;
using Todo.Domains.Exceptions;
using Xunit;

namespace Todo.Api.IntegrationTests
{
    public class TaskControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public TaskControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        
        [Fact]
        public async Task Task_GetAllTasks_ShouldBeSuccess()
        {
            var httpResponse = await _client.GetAsync("/task");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<IEnumerable<TaskResponse>>(stringResponse);
            Assert.NotEmpty(tasks);
            Assert.Equal(3, tasks.Count());
       }
        
        [Fact]
        public async Task Task_CreatingTaskWasReachingLimited_ShouldThrowException()
        {
            var userId = Guid.Parse("44f66382-ccfd-405e-bd85-0fab9c0036d5");
            var requestData = new CreateTaskRequest
            {
                Content = $"this is new task {new Random().Next(99999)}",
                UserId = userId
            };
            
            var httpResponse = await _client.PostAsJsonAsync("/task", requestData);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
        
        [Fact]
        public async Task Task_CreateNew_ShouldBeSuccess()
        {
            var userId = Guid.Parse("55f66382-ccfd-405e-bd85-0fab9c003633");
            var requestData = new CreateTaskRequest
            {
                Content = $"this is new task {new Random().Next(99999)}",
                UserId = userId
            };
            var httpResponse = await _client.PostAsJsonAsync("/task", requestData);
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var newTask = JsonConvert.DeserializeObject<TaskResponse>(stringResponse);
            Assert.NotNull(newTask);
            Assert.Equal(requestData.Content, newTask.Content);
            Assert.Equal((int)Todo.Domains.Entities.TaskStatus.Inactive, newTask.Status);
        }
    }
}