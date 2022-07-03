using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Books.Any()) return;
                context.Books.AddRange(new Book
                {
                    Title = "Lean Startup",
                    GenreId = 1, // Personel Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 6, 20)
                },
                new Book
                {
                    Title = "Herland",
                    GenreId = 2, // Science Fiction
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 5, 30)
                },
                new Book
                {
                    Title = "Dune",
                    GenreId = 2, // Science Fiction
                    PageCount = 1250,
                    PublishDate = new DateTime(2006, 12, 21)
                });
                context.SaveChanges();
            }
        }
    }
}