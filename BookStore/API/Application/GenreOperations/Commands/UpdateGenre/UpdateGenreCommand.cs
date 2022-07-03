using API.DB;


namespace API.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreViewModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly Context _context;
        public UpdateGenreCommand(Context context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Tür bulunamadı");
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("İsim zaten mevcut");

            genre.Name = Model.Name.Trim() != default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }

        public class UpdateGenreViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;
        }
    }
}