using TodosBackEnd.Entities;
using TodosBackEnd.Repository;

namespace TodosBackEnd.Service
{
    public class TodosService : ITodosService
    {
        private readonly ITodosRepository _repository;

        public TodosService(ITodosRepository repository)
        {
            _repository = repository;
        }

        public async Task AddTask(TodoItem entity)
        {
           await _repository.AddAsync(entity);
           await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            return await _repository.DeleteTodoItemAsync(id);
        }

        public async Task<List<TodoItem>> GetAllTask()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TodoItem> GetTask(int id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateTask(TodoItem item)
        {
             await _repository.Update(item);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
