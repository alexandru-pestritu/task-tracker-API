using TasksAPI.Models;

namespace TasksAPI.Services
{
    public interface ITaskCollectionService 
    {
        Task<List<TaskModel>> GetTasksByStatus(string status);
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> Get(Guid id);
        Task<bool> Create(TaskModel model);
        Task<bool> Update(Guid id, TaskModel model);
        Task<bool> Delete(Guid id);
    }
}
