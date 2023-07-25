using System.ComponentModel.DataAnnotations;

namespace CalendarASP.Net.Entity
{
    public class TaskViewModel
    {
        [Display(Name = "id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Created")]
        public DateTime Created { get; set; }
        [Display(Name = "Done")]
        public bool Done { get; set; }
    }
}
