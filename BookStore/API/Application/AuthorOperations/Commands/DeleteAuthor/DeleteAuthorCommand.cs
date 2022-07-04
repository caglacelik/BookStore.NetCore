using API.DB;
using Microsoft.EntityFrameworkCore;

namespace API.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly Context _context;
        public DeleteAuthorCommand(Context context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == AuthorId);
            if (author is null) throw new InvalidOperationException("Böyle bir yazar bulunamadı");
            if (!author.Books.Any())
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            else throw new InvalidOperationException("Kitapları var olan bir yazarı silemezsiniz.");
        }
    }
}