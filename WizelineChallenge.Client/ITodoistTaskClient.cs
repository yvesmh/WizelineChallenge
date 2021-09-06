using System.Collections.Generic;
using WizelineChallenge.Domain;

namespace WizelineChallenge.Client
{
    public interface ITodoistTaskClient
    {
        public ClientResult<List<TodoistTask>> GetActiveTasks();

        public ClientResult<TodoistTask> CreateTask(TodoistTask taskToCreate);

        public ClientResult<TodoistTask> GetActiveTask(long taskId);

        public ClientResult UpdateTask(TodoistTask taskToUpdate);

        public ClientResult DeleteTask(long taskId);

    }
}
