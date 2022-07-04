using API.DB;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
            var books = _context.Books.Include(x => x.Genre).Include(x => x.Author).OrderBy(x => x.Id).ToList<Book>();
            return _mapper.Map<List<BookViewModel>>(books);
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
        }

    }
}