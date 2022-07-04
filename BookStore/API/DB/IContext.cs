using System.Reflection;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public interface IContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        int SaveChanges();

    }
}

