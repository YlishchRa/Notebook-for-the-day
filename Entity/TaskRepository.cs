using Calendar.DB;
using Calendar.Interfaces;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml.Serialization;

namespace Calendar.Entity
{
    public class TaskRepository : IBaseRepository<TaskEntity>
    {
        public TaskDBContext _appTaskDBContext { get; set; }
        public TaskRepository(TaskDBContext _appTaskDBContext)
        {
            this._appTaskDBContext = _appTaskDBContext;
        }
        public async Task Create(TaskModel model)
        {
            var task = new TaskEntity
            {
                Name = model.Name,
                Description = model.Description.ToString(),
                Created = DateTime.Today,
                Done = false
            };
            try
            {


                await _appTaskDBContext.tasks.AddAsync(task);
                await _appTaskDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"HERE ---------------------------/n{ ex.Message}");
            }
            //Console.WriteLine(_appTaskDBContext.tasks.Select(t => t.Name == model.Name).ToList().LastOrDefault());
        }
        public async Task Delete(long id)
        {

            var task = _appTaskDBContext.tasks.Where(x => x.Id == id)
                .ToList()
                .LastOrDefault();

            _appTaskDBContext.tasks.Remove(task);
            await _appTaskDBContext.SaveChangesAsync();
        }


        IQueryable<TaskEntity> IBaseRepository<TaskEntity>.GetAll(DateTime filter)
        {
            DateTime dateOnlyFilter = filter.Date;
            return _appTaskDBContext.tasks.Where(x => x.Created.Date == dateOnlyFilter);
        }
    }
}
