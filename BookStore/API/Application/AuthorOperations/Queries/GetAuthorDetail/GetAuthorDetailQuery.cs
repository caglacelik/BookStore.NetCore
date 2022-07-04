using API.DB;
using AutoMapper;

namespace API.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null) throw new InvalidOperationException("Böyle bir yazar bulunamadı");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }

        public class AuthorDetailViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }
}