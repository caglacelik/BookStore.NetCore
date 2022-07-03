using System.Reflection;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}




