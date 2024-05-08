using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TasksAPI.Models;
using TasksAPI.Services;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskCollectionService _taskCollectionService;

        public TaskController(ITaskCollectionService taskCollectionService)
        {
            _taskCollectionService = taskCollectionService ?? throw new ArgumentNullException(nameof(taskCollectionService));
        }

        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>A list of all tasks.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TaskModel> tasks = await _taskCollectionService.GetAll();
            return Ok(tasks);
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="task">The task to add.</param>
        /// <returns>The created task.</returns>
        /// <response code="200">Returns the newly created task.</response>
        /// <response code="400">If the task is null.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }
            await _taskCollectionService.Create(task);
            return Ok(task);
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="id">The ID of the task to update.</param>
        /// <param name="task">The updated task information.</param>
        /// <returns>An ActionResult indicating the outcome of the operation.</returns>
        /// <response code="200">If the task is successfully updated.</response>
        /// <response code="400">If the task is null.</response>
        /// <response code="404">If the task with the specified ID is not found.</response>
        [HttpPut("{id:guid}")] 
        public async Task<IActionResult> Put(Guid id, [FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }

            var success = await _taskCollectionService.Update(id, task);
            if (!success)
            {
                return NotFound();
            }

            return Ok(task);
        }


        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>An ActionResult indicating the outcome of the operation.</returns>
        /// <response code="200">If the task is successfully deleted.</response>
        /// <response code="404">If a task with the specified ID is not found.</response>
        [HttpDelete("{id:guid}")] 
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _taskCollectionService.Delete(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
