using Calendar.DB;
using Calendar.Models;

namespace Calendar.Entity
{
    public interface IBaseRepository<T>
    {
        public TaskDBContext _appTaskDBContext { get; }

        public Task Create(TaskModel model);
        public Task Delete(long id);
       
        public IQueryable<T> GetAll(DateTime filter);
    }
}