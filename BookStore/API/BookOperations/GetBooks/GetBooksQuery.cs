using API;
using API.Common;
using API.DB;

public class GetBooksQuery
{

    private readonly Context _context;
    public GetBooksQuery(Context context)
    {
        _context = context;
    }

    public List<BookViewModel> Handle()
    {
        var books = _context.Books.OrderBy(x => x.Id).ToList<Book>();
        List<BookViewModel> models = new List<BookViewModel>();
        foreach (var book in books)
        {
            models.Add(new BookViewModel()
            {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.ToShortDateString(),
                PageCount = book.PageCount
            });
        }
        return models;
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }

}