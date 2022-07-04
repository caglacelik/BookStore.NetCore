using API.DB;
using API.Entities;
using AutoMapper;

namespace API.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList();
            return _mapper.Map<List<AuthorViewModel>>(authors);
        }

        public class AuthorViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }
}