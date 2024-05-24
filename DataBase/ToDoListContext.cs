using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
            ("Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=iluhahr_ToDoList;User ID=iluhahr_ToDoList;Password=1234; Trust Server Certificate=True;");
        //"data source=(localdb)\\MSSQLLocalDB;initial catalog=ToDoList;integrated security=True;MultipleActiveResultSets=true"
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<DataBase.Models.Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
