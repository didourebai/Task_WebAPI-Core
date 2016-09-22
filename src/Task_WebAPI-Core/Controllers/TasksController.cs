using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Task_WebAPI_Core.Models;
using Task_WebAPI_Core.Repository;


namespace Task_WebAPI_Core.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
     private readonly ITasksRepository _tasksRepository;
        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        // GET: api/tasks
        [HttpGet]
        public IEnumerable<TaskModel> Get()
        {
            return _tasksRepository.GetAll();
        }

        // GET api/tasks/T1
        [HttpGet("{id}", Name = "GetTasks")]
        public IActionResult Get(string id)
        {
            var item = _tasksRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/tasks
        [HttpPost]
        public IActionResult Post([FromBody]TaskModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _tasksRepository.Add(item);
            return CreatedAtRoute("GetTasks", new { Controller = "Tasks", id = item.Id }, item);
        }

        // PUT api/tasks/
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]TaskModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = _tasksRepository.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            _tasksRepository.Update(item);
            return new NoContentResult();
        }

        // DELETE api/tasks/T2
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _tasksRepository.Remove(id);
        }
    }
}
