using System;
using System.Collections.Generic;
using System.Linq;
using Task_WebAPI_Core.Models;

namespace Task_WebAPI_Core.Repository
{
    public class TasksRepository : ITasksRepository
    {
        public static List<TaskModel> TasksList { get; } = new List<TaskModel>();

        public TasksRepository()
        {
            //we will add here some Tasks in static
            TaskModel task1 = new TaskModel
            {
                Id = "T1",
                CreationTime = DateTime.UtcNow,
                Description = "This is a description related to the task 1.",
                State = "Completed",
                Title = "Task 1"
            };

            TaskModel task2 = new TaskModel
            {
                Id = "T2",
                CreationTime = DateTime.UtcNow,
                Description = "This is a description related to the task 2.",
                State = "Open",
                Title = "Task 2"
            };

            TaskModel task3 = new TaskModel
            {
                Id = "T3",
                CreationTime = DateTime.UtcNow,
                Description = "This is a description related to the task 3.",
                State = "Open",
                Title = "Task 3"
            };

            TaskModel task4 = new TaskModel
            {
                Id = "T4",
                CreationTime = DateTime.UtcNow,
                Description = "This is a description related to the task 4.",
                State = "Completed",
                Title = "Task 4"
            };


            TasksList.Add(task1);
            TasksList.Add(task2);
            TasksList.Add(task3);
            TasksList.Add(task4);
        }

        public void Add(TaskModel item)
        {
            TasksList.Add(item);
        }

        public IEnumerable<TaskModel> GetAll()
        {
            return TasksList;
        }

        public TaskModel Find(string key)
        {
            return TasksList
               .SingleOrDefault(e => e.Id.Equals(key));
        }

        public void Remove(string id)
        {
            var itemToRemove = TasksList.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
                TasksList.Remove(itemToRemove);
        }

        public void Update(TaskModel item)
        {
            var itemToUpdate = TasksList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Title = item.Title;
                itemToUpdate.Description = item.Description;
                itemToUpdate.State = item.State;
            }
        }
    }
}
