using Calendar.Interfaces;
using Calendar.Models;
using CalendarASP.Net.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Calendar.Entity
{
    public class TaskService : ITaskService
    {
        public IBaseRepository<TaskEntity> Repository { get; set; }
        IBaseRepository<TaskModel> ITaskService.Repository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TaskService(IBaseRepository<TaskEntity> repository)
        {
            Repository = repository;
        }

        public async Task Create(TaskModel model)
        {
            await Repository.Create(model);
        }

        public async Task Delete(long id)
        {
            await Repository.Delete(id);
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasks(DateTime filter)
        {
            try
            {
                var tasks = await Repository.GetAll(filter)
                    .Select(x => new TaskViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Created = x.Created,
                        Done = x.Done
                    }).ToListAsync();


                return tasks;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.ToString());
            }
        }
    }
}
