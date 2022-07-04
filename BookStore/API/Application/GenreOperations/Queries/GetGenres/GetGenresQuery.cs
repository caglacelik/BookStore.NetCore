using API.DB;
using API.Entities;
using AutoMapper;

namespace API.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.OrderBy(x => x.Id).ToList();
            return _mapper.Map<List<GenreViewModel>>(genres);
        }

        public class GenreViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}