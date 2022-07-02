using API;
using API.DB;

public class CreateBookCommand
{
    public CreateBookViewModel Model { get; set; }
    private readonly Context _context;
    public CreateBookCommand(Context context)
    {
        _context = context;
    }

    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
        if (book is not null) throw new InvalidOperationException("Kitap zaten mevcut");
        book = new Book();
        book.Title = Model.Title;
        book.PublishDate = Model.PublishDate;
        book.PageCount = Model.PageCount;
        book.GenreId = Model.GenreId;
        _context.SaveChanges();

    }

    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}