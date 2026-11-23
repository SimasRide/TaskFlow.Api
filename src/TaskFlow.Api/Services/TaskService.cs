
using TaskFlow.Api.Models;
using TaskFlow.Api.Data;
using TaskFlow.Api.Dtos;
using Microsoft.EntityFrameworkCore;

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
