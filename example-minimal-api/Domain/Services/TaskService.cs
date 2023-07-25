using example_minimal_api.Domain.Interfaces;
using example_minimal_api.Domain.Models;

namespace example_minimal_api.Domain.Services;

public class TaskService : ITaskService
{
    public Task<Todo> AddAsync(Todo task)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Todo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Todo> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Todo> UpdateAsync(Todo task)
    {
        throw new NotImplementedException();
    }
}
