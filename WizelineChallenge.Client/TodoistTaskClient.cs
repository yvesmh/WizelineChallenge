using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizelineChallenge.Domain;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;

namespace WizelineChallenge.Client
{
    public class TodoistTaskClient : ITodoistTaskClient
    {
        private readonly string _apiToken;

        public TodoistTaskClient(string apiToken)
        {
            _apiToken = apiToken;
        }

        public ClientResult<TodoistTask> CreateTask(TodoistTask taskToCreate)
        {
            var client = GetRestClient();

            var request = new RestRequest("tasks", DataFormat.Json);
            request.AddJsonBody(taskToCreate);
            var response = client.Post<TodoistTask>(request);

            return ClientResult<TodoistTask>.CreateResultFromRestSharpResponse(response);

        }

        public ClientResult DeleteTask(long taskId)
        {
            var client = GetRestClient();
            var request = new RestRequest($"tasks/{taskId}");
            var response = client.Delete(request);

            return ClientResult.CreateResultFromRestSharpResponse(response);
        }

        public ClientResult<TodoistTask> GetActiveTask(long taskId)
        {
            var client = GetRestClient();
            var request = new RestRequest($"tasks/{taskId}", DataFormat.Json);
            var response = client.Get<TodoistTask>(request);

            return ClientResult<TodoistTask>.CreateResultFromRestSharpResponse(response);
        }

        public ClientResult<List<TodoistTask>> GetActiveTasks()
        {
            var client = GetRestClient();
            var request = new RestRequest("tasks", DataFormat.Json);

            var response = client.Get<List<TodoistTask>>(request);

            return ClientResult<List<TodoistTask>>.CreateResultFromRestSharpResponse(response);

        }

        public ClientResult UpdateTask(TodoistTask taskToUpdate)
        {
            var client = GetRestClient();
            var request = new RestRequest($"tasks/{taskToUpdate.Id}");
            request.AddJsonBody(taskToUpdate);
            var response = client.Post<TodoistTask>(request);

            return ClientResult.CreateResultFromRestSharpResponse(response);
        }

        private RestClient GetRestClient()
        {
            var client = new RestClient("https://api.todoist.com/rest/v1/");
            client.Authenticator = new JwtAuthenticator(_apiToken);
            return client;
        }
    }
}
