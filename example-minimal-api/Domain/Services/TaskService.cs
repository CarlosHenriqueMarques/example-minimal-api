using example_minimal_api.Domain.Interfaces;
using example_minimal_api.Domain.Models;

namespace example_minimal_api.Domain.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository) { 
        _taskRepository = taskRepository;
    }
    public Task<Todo> AddAsync(Todo task)
    {
        return _taskRepository.AddAsync(task);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _taskRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<Todo>> GetAllAsync()
    {
        return _taskRepository.GetAllAsync();
    }

    public Task<Todo> GetByIdAsync(int id)
    {
        return _taskRepository.GetByIdAsync(id);
    }

    public Task<Todo> UpdateAsync(Todo task)
    {
        return _taskRepository.UpdateAsync(task);
    }
}
