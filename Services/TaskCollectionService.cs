using TasksAPI.Models;

namespace TasksAPI.Services
{
    public class TaskCollectionService : ITaskCollectionService
    {
        private List<TaskModel> _tasks;

        public TaskCollectionService()
        {
            _tasks = new List<TaskModel>
            {
                new TaskModel { Id = Guid.NewGuid(), Name = "First TaskModel", Description = "First TaskModel Description", AssignedTo = "Author_1", Status = "To do"},
                new TaskModel { Id = Guid.NewGuid(), Name = "Second TaskModel", Description = "Second TaskModel Description", AssignedTo = "Author_1", Status = "To do"},
                new TaskModel { Id = Guid.NewGuid(), Name = "Third TaskModel", Description = "Third TaskModel Description", AssignedTo = "Author_2", Status = "To do"},
                new TaskModel { Id = Guid.NewGuid(), Name = "Fourth TaskModel", Description = "Fourth TaskModel Description", AssignedTo = "Author_3", Status = "To do"},
                new TaskModel { Id = Guid.NewGuid(), Name = "Fifth TaskModel", Description = "Fifth TaskModel Description", AssignedTo = "Author_4", Status = "To do"}
            };
        }

        public bool Create(TaskModel model)
        {
            model.Id = Guid.NewGuid();
            _tasks.Add(model);
            return true;
        }

        public bool Delete(Guid id)
        {
            var taskToRemove = _tasks.FirstOrDefault(task => task.Id == id);
            if (taskToRemove == null)
                return false;

            _tasks.Remove(taskToRemove);
            return true;
        }

        public TaskModel Get(Guid id)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }

        public List<TaskModel> GetAll()
        {
            return _tasks;
        }

        public List<TaskModel> GetTasksByStatus(string status)
        {
            return _tasks.Where(task => task.Status == status).ToList();
        }

        public bool Update(Guid id, TaskModel model)
        {
            var existingTask = _tasks.FirstOrDefault(task => task.Id == id);
            if (existingTask == null)
                return false;

            existingTask.Name = model.Name;
            existingTask.Description = model.Description;
            existingTask.AssignedTo = model.AssignedTo;
            existingTask.Status = model.Status;
            return true;
        }
    }
}
