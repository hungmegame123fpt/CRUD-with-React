using System.Threading.Tasks;
using TodosBackEnd.Entities;

namespace TodosBackEnd.Service
{
    public interface ITodosService
    {
        Task<TodoItem> GetTask(int id);
        Task<List<TodoItem>> GetAllTask();
        Task AddTask(TodoItem entity);
        Task<bool> UpdateTask(TodoItem entity);
        Task<bool> DeleteTodoItemAsync(int id);
    }
}
