using System.Collections.Generic;
using System.Threading.Tasks;
using  TaskFlow.Api.Models;
using TaskFlow.Api.Dtos;
namespace TaskFlow.Api.Services;  
public interface ITaskService
{
Task<IEnumerable<TaskItem>> GetTasksAsync(); //call - Assincrona
Task<TaskItem?> GetTaskByIdAsync(int id);

Task<TaskItem> CreateTaskAsync(CreateTaskDto dto);
}
