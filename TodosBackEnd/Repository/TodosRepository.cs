using Microsoft.EntityFrameworkCore;
using TodosBackEnd.Entities;

namespace TodosBackEnd.Repository
{
    public class TodosRepository : ITodosRepository
    {
        private readonly TodosContext _context;

        public TodosRepository(TodosContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoItem entity)
        {
           await _context.AddAsync(entity);

        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return false; // Item not found
            }

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            var list = _context.TodoItems.OrderByDescending(x => x.Id).ToListAsync();
            return await list;
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");
            }

            // Attempt to retrieve the Gold entity from the context
            var task = await _context.TodoItems.FirstOrDefaultAsync(g => g.Id.Equals(id));

            // Check if the retrieved gold is null
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} was not found.");
            }

            return task;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(TodoItem item)
        {
            var existingItem = await _context.TodoItems.FindAsync(item.Id);
            if (existingItem == null)
            {
                return false; // Item not found
            }

            existingItem.Name = item.Name;
            existingItem.IsComplete = item.IsComplete;
            // Update other fields as necessary

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
