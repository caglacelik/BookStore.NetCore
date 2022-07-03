using API;
using API.DB;
using AutoMapper;

namespace API.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookViewModel Model { get; set; }
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null) throw new InvalidOperationException("Kitap zaten mevcut");

            _context.Add(_mapper.Map<Book>(Model));
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
}
