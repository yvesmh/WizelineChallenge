using System;
using System.Net;
using WizelineChallenge.Client;
using WizelineChallenge.Domain;
using Xunit;

namespace WizelineChallenge.Test
{
    public class TodoistTaskEndpointTests
    {
        private const string apiToken = "get your token from https://todoist.com/app/settings/integrations ";

        [Fact]
        public void CreateNewTask_WhenTaskIsValid_IsSuccessful()
        {
            // Arrange
            var guid = Guid.NewGuid();

            var taskToCreate = new TodoistTask
            {
                Content = $"xUnit Test {guid}",
                Description = "This is a test"
            };

            var projectClient = new TodoistTaskClient(apiToken);

            // Act
            var result = projectClient.CreateTask(taskToCreate);
            var createdTask = result.Data;

            // Assert
            Assert.NotEqual(0, createdTask.Id);
            Assert.Equal(taskToCreate.Content, createdTask.Content);
        }

        [Fact]
        public void CreateNewTask_WhenTaskHasNoContent_Fails()
        {
            // Arrange
            var taskToCreate = new TodoistTask
            {
                Description = "This is a test"
            };

            var projectClient = new TodoistTaskClient(apiToken);

            // Act
            var result = projectClient.CreateTask(taskToCreate);

            // Assert
            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.ErrorMessage);

        }

        [Fact]
        public void DeleteATask_WhenTaskExists_DeletesTheTask()
        {
            // Arrange
            var taskToCreate = new TodoistTask
            {
                Content = "Task to Delete"
            };

            var projectClient = new TodoistTaskClient(apiToken);

            var createResult = projectClient.CreateTask(taskToCreate);
            var createdTask = createResult.Data;

            // Act
            var deleteResult = projectClient.DeleteTask(createdTask.Id);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, deleteResult.StatusCode);
        }

        [Fact]
        public void DeleteATask_WhenTaskDoesntExist_Fails()
        {
            // TODO homework for Ilse
        }

        [Fact]
        public void UpdateTask_WhenTaskExists_UpdatesThetask()
        {
            // Arrange
            var taskToCreate = new TodoistTask
            {
                Content = "Task to Update"
            };

            var projectClient = new TodoistTaskClient(apiToken);

            var createResult = projectClient.CreateTask(taskToCreate);
            var createdTask = createResult.Data;

            createdTask.Content = "Task is now Updated";

            // Act
            var updatedResult = projectClient.UpdateTask(createdTask);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, updatedResult.StatusCode);
        }

        [Fact]
        public void UpdateTask_WhenTaskDoesntExist_Fails()
        {
            // TODO homework for Ilse
        }

        [Fact]
        public void GetActiveTask_WhenTaskExists_ReturnsTaskDetails()
        {
            // Arrange
            var taskToCreate = new TodoistTask
            {
                Content = "Get an Active task"
            };

            var projectClient = new TodoistTaskClient(apiToken);

            var createResult = projectClient.CreateTask(taskToCreate);
            var createdTask = createResult.Data;

            // Act
            var getActiveTaskResult = projectClient.GetActiveTask(createdTask.Id);

            // Assert
            var getActiveTaskData = getActiveTaskResult.Data;
            Assert.Equal(taskToCreate.Content, getActiveTaskData.Content);
        }

        [Fact]
        public void GetActiveTasks_WhenAtLeastOneTaskExists_ReturnsList()
        {
            // TODO homework for Ilse
        }

    }
}
