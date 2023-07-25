using example_minimal_api.Domain.Models;

namespace example_minimal_api.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo> GetByIdAsync(int id);
    Task<Todo> AddAsync(Todo task);
    Task<Todo> UpdateAsync(Todo task);
    Task<bool> DeleteAsync(int id);
}
