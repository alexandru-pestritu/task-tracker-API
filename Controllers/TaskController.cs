using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TasksAPI.Models;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        static List<TaskModel> _tasks = new List<TaskModel> { new TaskModel { Id = Guid.NewGuid(), Name = "First TaskModel", Description = "First TaskModel Description" , AssignedTo = "Author_1", Status = "To do"},
        new TaskModel { Id = Guid.NewGuid(), Name = "Second TaskModel", Description = "Second TaskModel Description", AssignedTo = "Author_1", Status = "To do" },
        new TaskModel { Id = Guid.NewGuid(), Name = "Third TaskModel", Description = "Third TaskModel Description", AssignedTo = "Author_2", Status = "To do"  },
        new TaskModel { Id = Guid.NewGuid(), Name = "Fourth TaskModel", Description = "Fourth TaskModel Description", AssignedTo = "Author_3", Status = "To do"  },
        new TaskModel { Id = Guid.NewGuid(), Name = "Fifth TaskModel", Description = "Fifth TaskModel Description", AssignedTo = "Author_4", Status = "To do"  }
        };

        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>A list of all tasks.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tasks);
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="task">The task to add.</param>
        /// <returns>The created task.</returns>
        /// <response code="200">Returns the newly created task.</response>
        /// <response code="400">If the task is null.</response>
        [HttpPost]
        public IActionResult Post([FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }
            task.Id = Guid.NewGuid(); 
            _tasks.Add(task);
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
        public IActionResult Put(Guid id, [FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }

            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Name = task.Name;
            existingTask.Description = task.Description;
            existingTask.AssignedTo = task.AssignedTo;
            existingTask.Status = task.Status;

            return Ok(existingTask);
        }


        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>An ActionResult indicating the outcome of the operation.</returns>
        /// <response code="200">If the task is successfully deleted.</response>
        /// <response code="404">If a task with the specified ID is not found.</response>
        [HttpDelete("{id:guid}")] 
        public IActionResult Delete(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            _tasks.Remove(task);
            return Ok(); 
        }
    }
}
