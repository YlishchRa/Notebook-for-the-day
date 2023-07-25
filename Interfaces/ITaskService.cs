using Calendar.Entity;
using Calendar.Models;
using CalendarASP.Net.Entity;

namespace Calendar.Interfaces
{
    public interface ITaskService
    {
        public IBaseRepository<TaskModel> Repository { get; set; }
        Task Create(TaskModel model);
        Task Delete(long id);
        Task <IEnumerable<TaskViewModel>> GetTasks(DateTime filter);
    }
}
