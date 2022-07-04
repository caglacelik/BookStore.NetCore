using API;
using API.DB;
using API.Entities;
using AutoMapper;

namespace API.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set; }
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null) throw new InvalidOperationException("Tür zaten mevcut");

            _context.Genres.Add(_mapper.Map<Genre>(Model));
            _context.SaveChanges();
        }

        public class CreateGenreViewModel
        {
            public string Name { get; set; }
        }
    }
}
