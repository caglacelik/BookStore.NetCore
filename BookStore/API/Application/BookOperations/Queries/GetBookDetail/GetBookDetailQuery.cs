using API.Common;
using API.DB;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Application.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null) throw new InvalidOperationException("Kitap bulunamadı");
            return _mapper.Map<BookDetailViewModel>(book);

        }

        public class BookDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
        }
    }
}