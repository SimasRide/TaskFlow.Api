/*Controllers vai servir de comunicação
  com o frontend por ao receber pedidos http -> GET /api/tasks
  Isto permite obter todas as tarefas */
// Responsável por HTTP(GET,POST,PUT,DELETE)
using Microsoft.AspNetCore.Mvc;

using TaskFlow.Api.Dtos;

using TaskFlow.Api.Services;



[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  private readonly ITaskService _taskService;
  public TaskController(ITaskService taskService)
  {
    _taskService = taskService;
  }
  [HttpGet]
  public async Task<IActionResult> GetTasks()
  {
    var tasks = await _taskService.GetTasksAsync();
    return Ok(tasks);
  }

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteTaskAsync(int id)
{
    var deleted = await _taskService.DeleteTaskAsync(id);

    if (deleted == false)
    {
        return NotFound();
    }

    return NoContent();
}



  [HttpGet("{id}")] // Angular enviar , TaskController recebe GET /api/tasks{id}
  public async Task<IActionResult> GetTasksById(int id) //Consultar tasks 
  {

    var tasks = await _taskService.GetTaskByIdAsync(id);
    if (tasks == null)
    {
      return NotFound();
    }
    return Ok(tasks);
  }




  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
  {
    var tasks = await _taskService.UpdateTaskAsync(id, dto);
    if (tasks == null)
    {
      return NotFound();
    }
    return NoContent();
  }

  [HttpPost]
  public async Task<IActionResult> CreateTask(CreateTaskDto dto)
  {
    var task = await _taskService.CreateTaskAsync(dto);
    return Ok(task);

  }
}




