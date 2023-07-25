
using Calendar.Entity;
using Calendar.Interfaces;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calendar.Controllers
{
    public class TaskController : Controller
    {

        private readonly ITaskService _app_service;

        public TaskController(ITaskService app_service)
        {
            _app_service = app_service;
        }

        public IActionResult Index()
        {
            return View();   
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            _app_service.Create(task);
            return Ok();
        }
        

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _app_service.Delete(id);
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> TaskHandler([FromBody] DateTime filter)
        {
            var responce = await _app_service.GetTasks(filter);

            return Json(new { data = responce});
        }
       
    }


    public class DateModel
    {
        public DateTime Date { get; set; }
    }
}


