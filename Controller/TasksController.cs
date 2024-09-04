using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Model;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<UserTask>>> GetTasksByUserId(int userId)
    {
        var tasks = await _taskService.GetTasksByUserIdAsync(userId);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<UserTask>> CreateTask(UserTask task)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdTask = await _taskService.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetTasksByUserId), new { userId = createdTask.AssignedToUserId }, createdTask);
    }

    [HttpPut("{taskId}")]
    public async Task<ActionResult<UserTask>> UpdateTask(int taskId, UserTask task)
    {
        if (taskId != task.TaskId)
        {
            return BadRequest("Task ID mismatch");
        }

        var updatedTask = await _taskService.UpdateTaskAsync(task);
        if (updatedTask == null)
        {
            return NotFound();
        }

        return Ok(updatedTask);
    }

    [HttpDelete("{taskId}")]
    public async Task<ActionResult> DeleteTask(int taskId)
    {
        var result = await _taskService.DeleteTaskAsync(taskId);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("manager/{managerId}")]
    public async Task<ActionResult<IEnumerable<UserTask>>> GetTasksByManagerId(int managerId)
    {
        var tasks = await _taskService.GetTasksByManagerIdAsync(managerId);
        return Ok(tasks);
    }
}
