using Microsoft.EntityFrameworkCore;
using BackendTodoList.Model;

namespace BackendTodoList
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
