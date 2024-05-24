namespace DataBase.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime DueDate { get; set; }
        public Category? Category { get; set; }
        public Priority Priority { get; set; }

        public Task() { }
        public Task(string title, DateTime dueDate, Priority priority, Category? category = null, string? description = null)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Category = category;
            Priority = priority;
        }

        public override string ToString()
        {
            var result = $"Title: {Title}, DueDate: {DueDate}, Priority: {Priority.Type}";
            if (Category != null) result += $", Category: {Category}";
            if (Description != null) result += $", Description: {Description}";
            return result;
        }
    }
}
