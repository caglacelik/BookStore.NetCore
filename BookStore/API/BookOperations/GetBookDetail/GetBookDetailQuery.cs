

using API.Common;
using API.DB;

public class GetBookDetailQuery
{
    private readonly Context _context;
    public int BookId { get; set; }
    public GetBookDetailQuery(Context context)
    {
        _context = context;
    }

    public BookDetailViewModel Handle()
    {
        var book = _context.Books.Where(x => x.Id == BookId).SingleOrDefault();
        if (book is null) throw new InvalidOperationException("Kitap bulunamadı");
        BookDetailViewModel bookDetailViewModel = new BookDetailViewModel();
        bookDetailViewModel.Title = book.Title;
        bookDetailViewModel.Genre = ((GenreEnum)book.GenreId).ToString();
        bookDetailViewModel.PageCount = book.PageCount;
        bookDetailViewModel.PublishDate = book.PublishDate.ToShortDateString();
        return bookDetailViewModel;
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}