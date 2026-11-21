/*Controllers vai servir de comunicação
  com o frontend por ao receber pedidos http -> GET /api/tasks
  Isto permite obter todas as tarefas */
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Data;
using Microsoft.EntityFrameworkCore;
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
  } 
  

