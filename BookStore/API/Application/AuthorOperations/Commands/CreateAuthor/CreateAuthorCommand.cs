using API;
using API.DB;
using API.Entities;
using AutoMapper;

namespace API.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorViewModel Model { get; set; }
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (author is not null) throw new InvalidOperationException("Yazar zaten mevcut");

            _context.Add(_mapper.Map<Author>(Model));
            _context.SaveChanges();
        }

        public class CreateAuthorViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }

        }
    }
}
