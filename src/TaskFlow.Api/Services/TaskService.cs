
using TaskFlow.Api.Models;
using TaskFlow.Api.Data;
using TaskFlow.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Api.Services;

public class TaskService : ITaskService
{
    private readonly DataBaseCtx _context;

    public TaskService(DataBaseCtx context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetTasksAsync()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {  //FindAsync(id) — procura a tarefa.
        var task = await _context.Tasks.FindAsync(id); 
    
        return task;
    }
    public async Task<TaskItem?> UpdateTaskAsync(int id, UpdateTaskDto dto)
{
    var task = await _context.Tasks.FindAsync(id);

    if (task == null)
    {
        return null;
    }
    task.Title = dto.Title;
    task.Description = dto.Description;
    task.Priority = dto.Priority;
    task.DueDate = dto.DueDate;
    task.IsCompleted = dto.IsCompleted;

    await _context.SaveChangesAsync(); //Guarda no Sql 
    return task;
} //else desnecessario visto q são apenas 2 condições e usamos o return.
    public async Task<TaskItem> CreateTaskAsync(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            DueDate = dto.DueDate,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        return task;
    }
}
