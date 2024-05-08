﻿using MongoDB.Driver;
using TasksAPI.Models;
using TasksAPI.Settings;

namespace TasksAPI.Services
{
    public class TaskCollectionService : ITaskCollectionService
    {
        private readonly IMongoCollection<TaskModel> _tasks;

        public TaskCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tasks = database.GetCollection<TaskModel>(settings.TasksCollectionName);
        }
        public async Task<bool> Create(TaskModel taskModel)
        {
            if (taskModel.Id == Guid.Empty)
            {
                taskModel.Id = Guid.NewGuid();
            }

            await _tasks.InsertOneAsync(taskModel);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _tasks.DeleteOneAsync(taskModel => taskModel.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<TaskModel> Get(Guid id)
        {
            return (await _tasks.FindAsync(taskModel => taskModel.Id == id)).FirstOrDefault();
        }

        public async Task<List<TaskModel>> GetAll()
        {
            var result = await _tasks.FindAsync(task => true);
            return result.ToList();
        }

        public async Task<List<TaskModel>> GetTasksByStatus(string status)
        {
            return (await _tasks.FindAsync(taskModel => taskModel.Status == status)).ToList();
        }


        public async Task<bool> Update(Guid id, TaskModel taskModel)
        {
            taskModel.Id = id;
            var result = await _tasks.ReplaceOneAsync(taskModel => taskModel.Id == id, taskModel);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _tasks.InsertOneAsync(taskModel);
                return false;
            }

            return true;
        }
    }
}
