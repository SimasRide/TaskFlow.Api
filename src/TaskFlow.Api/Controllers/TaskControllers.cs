/*Controllers vai servir de comunicação
  com o frontend por ao receber pedidos http -> GET /api/tasks
  Isto permite obter todas as tarefas */
  // Responsável por HTTP(GET,POST,PUT,DELETE)
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Data;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Dtos;
using TaskFlow.Api.Models;


[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  private readonly DataBaseCtx _context;
  public TaskController(DataBaseCtx context)
  {
    _context = context;
  }
  [HttpGet] // Angular enviar , TaskController recebe GET /api/taks
  public async Task <IActionResult> GetTasks() //Consultar tasks 
  {
  
    var tasks = await _context.Tasks.ToListAsync();
    return Ok (tasks);
  }  
  [HttpPost]
  public async Task<IActionResult> CreateTask(CreateTaskDto dto){
var task = new TaskItem
{
Title = dto.Title,
Description = dto.Description,
Priority = dto.Priority,
DueDate = dto.DueDate,
CreatedAt = DateTime.UtcNow,
IsCompleted = false
};
_context.Tasks.Add(task); // Informa (EF) de add de nova task
await _context.SaveChangesAsync(); //executa a operação e grava os dados na BD
return Ok (task);
    }
} 
  
  

