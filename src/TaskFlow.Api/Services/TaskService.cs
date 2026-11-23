
using TaskFlow.Api.Models;
using TaskFlow.Api.Data;
using TaskFlow.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

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
    {
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
