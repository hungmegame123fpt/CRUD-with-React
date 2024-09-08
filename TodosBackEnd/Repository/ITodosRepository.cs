using TodosBackEnd.Entities;

namespace TodosBackEnd.Repository
{
    public interface ITodosRepository
    {
        Task<TodoItem> GetByIdAsync(int id);
        Task<List<TodoItem>> GetAllAsync();
        Task AddAsync(TodoItem entity);
        Task<bool> Update(TodoItem item);
        Task<bool> DeleteTodoItemAsync(int id);
        Task SaveChangesAsync();
    }
}
