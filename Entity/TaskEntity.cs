namespace Calendar.Entity
{
    [Serializable]
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set;}
        public bool Done { get; set;} 

    }
}
