using System;

namespace Task_WebAPI_Core.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public string State { get; set; }

        public TaskModel()
        {
            CreationTime = DateTime.UtcNow;
            State = "Open";
        }
    }
}