using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }

    }
}




