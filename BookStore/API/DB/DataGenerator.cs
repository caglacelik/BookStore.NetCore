using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {

                context.Authors.AddRange(new Author
                {
                    FirstName = "Stefan",
                    LastName = "Zweig",
                    BirthDate = new DateTime(1881, 11, 28)
                },
                new Author
                {
                    FirstName = "Anthony",
                    LastName = "Burgess",
                    BirthDate = new DateTime(1917, 2, 25)
                },
                new Author
                {
                    FirstName = "Jack",
                    LastName = "London",
                    BirthDate = new DateTime(1876, 1, 12)
                });

                context.Genres.AddRange(new Genre
                {
                    Name = "Personel Growth"
                },
                new Genre
                {
                    Name = "Novel"
                },
                new Genre
                {
                    Name = "Story"
                });

                //if (context.Books.Any()) return;

                context.Books.AddRange(new Book
                {
                    Title = "Korku",
                    GenreId = 3, // Personel Growth
                    PageCount = 65,
                    PublishDate = new DateTime(2001, 6, 20),
                    AuthorId = 1
                },
                new Book
                {
                    Title = "Martin Eden",
                    GenreId = 2, // Science Fiction
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 5, 30),
                    AuthorId = 3
                },
                new Book
                {
                    Title = "Satranç",
                    GenreId = 3, // Science Fiction
                    PageCount = 45,
                    PublishDate = new DateTime(2006, 12, 21),
                    AuthorId = 1
                });

                context.SaveChanges();
            }
        }
    }
}