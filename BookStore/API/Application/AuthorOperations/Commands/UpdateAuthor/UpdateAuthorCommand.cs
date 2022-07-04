using API.DB;


namespace API.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorViewModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly IContext _context;
        public UpdateAuthorCommand(IContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null) throw new InvalidOperationException("Yazar bulunamadı");
            if (_context.Authors.Any(x => x.FirstName.ToLower() == Model.FirstName.ToLower() && x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("Yazar zaten mevcut");

            author.FirstName = Model.FirstName.Trim() != default ? Model.FirstName : author.FirstName;
            author.LastName = Model.LastName.Trim() != default ? Model.LastName : author.LastName;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;

            _context.SaveChanges();
        }

        public class UpdateAuthorViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
        }
    }
}