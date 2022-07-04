using API.DB;
using API.Entities;
using AutoMapper;

namespace API.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Böyle bir tür bulunamadı");
            return _mapper.Map<GenreDetailViewModel>(genre);
        }

        public class GenreDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}