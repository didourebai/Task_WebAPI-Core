using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebAPI_Core.Models;

namespace Task_WebAPI_Core.Repository
{
    public interface ITasksRepository
    {
        void Add(TaskModel item);
        IEnumerable<TaskModel> GetAll();
        TaskModel Find(string key);
        void Remove(string Id);
        void Update(TaskModel item);
    }
}
