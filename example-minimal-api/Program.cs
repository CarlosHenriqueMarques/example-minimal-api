using example_minimal_api.Domain.Interfaces;
using example_minimal_api.Domain.Models;
using example_minimal_api.Domain.Services;
using example_minimal_api.Infrastructure.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITaskService, TaskService>();

// Add this section to enable Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/todos", async (ITaskService service) =>
{
    var todos = await service.GetAllAsync();
    return Results.Ok(todos);
});

app.MapGet("/todos/{id}", async (int id, ITaskService service) =>
{
    var todo = await service.GetByIdAsync(id);
    if (todo == null)
        return Results.NotFound();

    return Results.Ok(todo);
});

app.MapPost("/todos", async (Todo todo, ITaskService service) =>
{
    if (string.IsNullOrEmpty(todo.Title))
        return Results.BadRequest("Title must not be empty");

    var addedTodo = await service.AddAsync(todo);
    return Results.Created($"/todos/{addedTodo.Id}", addedTodo);
});

app.MapPut("/todos/{id}", async (int id, Todo todo, ITaskService service) =>
{
    if (string.IsNullOrEmpty(todo.Title))
        return Results.BadRequest("Title must not be empty");

    var existingTodo = await service.GetByIdAsync(id);
    if (existingTodo == null)
        return Results.NotFound();

    todo.Id = id;
    await service.UpdateAsync(todo);
    return Results.Ok(todo);
});

app.MapDelete("/todos/{id}", async (int id, ITaskService service) =>
{
    var deleted = await service.DeleteAsync(id);
    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    c.RoutePrefix = string.Empty;
});
app.Run();
