using API.DB;

namespace API.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }
        private readonly IContext _context;
        public DeleteBookCommand(IContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null) throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}