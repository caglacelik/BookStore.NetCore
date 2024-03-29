using API.DB;


namespace API.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookViewModel Model { get; set; }
        public int BookId { get; set; }
        private readonly IContext _context;
        public UpdateBookCommand(IContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null) throw new InvalidOperationException("Kitap bulunamadı");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _context.SaveChanges();
        }

        public class UpdateBookViewModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}