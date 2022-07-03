using API.Common;
using AutoMapper;
using static CreateBookCommand;
using static GetBookDetailQuery;
using static GetBooksQuery;

namespace API.Common
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateBookViewModel, Book>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>()
            .ForMember(x => x.Genre, s => s.MapFrom(a => ((GenreEnum)a.GenreId).ToString())).ReverseMap();
            CreateMap<Book, BookViewModel>()
            .ForMember(x => x.Genre, s => s.MapFrom(a => ((GenreEnum)a.GenreId).ToString())).ReverseMap();


        }
    }
}

