using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public static class ToDoListHandle
    {
        public static async Task<List<Category>> GetCategoriesAsync()
        {
            using ToDoListContext db = new();
            return await db.Categories.ToListAsync();
        }
        public static async Task<List<Priority>> GetPrioritiesAsync()
        {
            using ToDoListContext db = new();
            return await db.Priorities.Include("Category").Include("Priority").Include("User").ToListAsync();
        }
        public static async Task<List<DataBase.Models.Task>> GetTasksAsync()
        {
            using ToDoListContext db = new();
            return await db.Tasks.Include("Category").Include("Priority").ToListAsync();
        }
        public static async Task<List<User>> GetUsersAsync()
        {
            using ToDoListContext db = new();
            return await db.Users.Include(x => x.Tasks).ToListAsync();
        }

        public static async System.Threading.Tasks.Task AddCategoryAsync(Category category)
        {
            using ToDoListContext db = new();
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }
        public static async System.Threading.Tasks.Task AddPriorityAsync(Priority priority)
        {
            using ToDoListContext db = new();
            db.Priorities.Add(priority);
            await db.SaveChangesAsync();
        }
        public static async System.Threading.Tasks.Task AddTaskAsync(DataBase.Models.Task task)
        {
            using ToDoListContext db = new();
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
        }
        public static async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            using ToDoListContext db = new();
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task DeleteCategoryAsync(Category category)
        {
            using ToDoListContext db = new();
            var categories = await GetCategoriesAsync();
            db.Categories.Remove(categories.First(x => x.ToString() == category.ToString()));
            await db.SaveChangesAsync();
        }
        public static async System.Threading.Tasks.Task DeletePriorityAsync(Priority priority)
        {
            using ToDoListContext db = new();
            var priorities = await GetPrioritiesAsync();
            db.Priorities.Remove(priorities.First(x => x.ToString() == priority.ToString()));
            await db.SaveChangesAsync();
        }
        public static async System.Threading.Tasks.Task DeleteTaskAsync(DataBase.Models.Task task)
        {
            using ToDoListContext db = new();
            var tasks = await GetTasksAsync();
            db.Tasks.Remove(tasks.First(x => x.ToString() == task.ToString()));
            await db.SaveChangesAsync();
        }
        public static async System.Threading.Tasks.Task DeleteUserAsync(User user)
        {
            using ToDoListContext db = new();
            var users = await GetUsersAsync();
            db.Users.Remove(users.First(x => x.ToString() == user.ToString()));
            await db.SaveChangesAsync();
        }
    }
}
