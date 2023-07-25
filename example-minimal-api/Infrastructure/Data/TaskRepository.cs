using example_minimal_api.Domain.Interfaces;
using example_minimal_api.Domain.Models;

namespace example_minimal_api.Infrastructure.Data;

public class TaskRepository : ITaskRepository
{
    private readonly List<Todo> _todos = new List<Todo>();
    private int _lastId = 0;

    public async Task<IEnumerable<Todo>> GetAllAsync() => await Task.FromResult(_todos);

    public async Task<Todo> GetByIdAsync(int id) => await Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));

    public async Task<Todo> AddAsync(Todo todo)
    {
        todo.Id = ++_lastId;
        _todos.Add(todo);
        return await Task.FromResult(todo);
    }

    public async Task<Todo> UpdateAsync(Todo todo)
    {
        var existingTodo = _todos.FirstOrDefault(t => t.Id == todo.Id);
        if (existingTodo != null)
        {
            existingTodo.Title = todo.Title;
            existingTodo.IsCompleted = todo.IsCompleted;
        }
        return await Task.FromResult(existingTodo);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo != null)
        {
            _todos.Remove(existingTodo);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}
