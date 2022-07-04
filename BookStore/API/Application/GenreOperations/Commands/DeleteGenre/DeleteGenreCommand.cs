using API.DB;

namespace API.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly IContext _context;
        public DeleteGenreCommand(IContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Böyle bir tür bulunamadı");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}