namespace BackendTodoList.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
